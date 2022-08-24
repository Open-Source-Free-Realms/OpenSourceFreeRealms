using System.Collections.Generic;
using System.IO;
using log4net;

using SOE.Interfaces;

namespace SOE.Core
{
    public class SOEDataChannel
    {
        // Components
        public SOEClient Client;
        public ILog Log;

        // Last client-sent reliable data
        private ushort LastReceivedSequenceNumber;

        // Server-sent reliable data
        // private int LastDataSendTime;
        private ushort NextSequenceNumber;

        // Fragmented
        private bool StartedFragmentedPacket;
        private ushort FragmentSequenceNumber;
        private uint ReceivedFragmentsSize;
        private byte[] FragmentedData;
        private byte FragmentsTillAck;

        private bool BusySendingFragmentedPacket;
        private Queue<SOEMessage> FragmentedQueue;

        public SOEDataChannel(SOEClient client)
        {
            // Associated client
            Client = client;

            // Defaults
            LastReceivedSequenceNumber = 0;
            // LastDataSendTime = 0;
            NextSequenceNumber = 0;
            StartedFragmentedPacket = false;
            FragmentSequenceNumber = 0;
            ReceivedFragmentsSize = 0;
            FragmentsTillAck = 6;
            BusySendingFragmentedPacket = false;
            FragmentedQueue = new Queue<SOEMessage>();

            Log = client.Server.Logger.GetLogger("SOEDataChannel");
        }

        private void Acknowledge(ushort sequenceNumber)
        {
            // Setup a writer
            SOEWriter writer = new SOEWriter((ushort)SOEOPCodes.ACK_RELIABLE_DATA);

            // Compressed? (Always false)
            writer.AddBoolean(false);

            // Add the sequence number
            writer.AddUInt16(sequenceNumber);

            // Send the packet
            SOEPacket packet = writer.GetFinalSOEPacket(Client, true, true);
            Client.SendPacket(packet);
        }

        private void ReceivedSequenceOutOfOrder(ushort sequenceNumber)
        {
            // Setup a writer
            SOEWriter writer = new SOEWriter((ushort)SOEOPCodes.OUT_OF_ORDER_RELIABLE_DATA);
            
            // Where abouts did the sending mess up?
            writer.AddUInt16(sequenceNumber);

            // Send the packet
            SOEPacket packet = writer.GetFinalSOEPacket(Client, true, true);
            Client.SendPacket(packet);
        }

        private void ReceiveFragment(SOEPacket packet)
        {
            // Setup a reader
            SOEReader reader = new SOEReader(packet);
            reader.ReadUInt16();

            // Have we already started a fragmented packet?
            if (StartedFragmentedPacket)
            {
                // One less fragment till we need to acknowledge!
                FragmentsTillAck--;

                // Get our sequence number
                uint previousFragmentSequenceNumber = FragmentSequenceNumber;
                FragmentSequenceNumber = reader.ReadUInt16();

                // Did we get a correct sequence number?
                if (FragmentSequenceNumber != previousFragmentSequenceNumber + 1)
                {
                    // Out of order!
                    ReceivedSequenceOutOfOrder(FragmentSequenceNumber);
                    return;
                }

                // Append the rest of the packet to the fragmented data
                for (int i = 4; i < FragmentedData.Length; i++)
                {
                    FragmentedData[ReceivedFragmentsSize] = reader.ReadByte();
                    ReceivedFragmentsSize++;
                }
            }
            else
            {
                // We're expecting the starting packet
                FragmentSequenceNumber = reader.ReadUInt16();
                uint totalSize = reader.ReadUInt32();

                // Is this a valid sequence number?
                if ((FragmentSequenceNumber != LastReceivedSequenceNumber + 1) && (FragmentSequenceNumber != 0))
                {
                    // Out of order!
                    ReceivedSequenceOutOfOrder(FragmentSequenceNumber);
                    return;
                }

                // Get the total size
                FragmentedData = new byte[totalSize];

                // How many fragments till we need to acknowledge
                FragmentsTillAck = 4;

                // Append the rest of the packet to the fragmented data
                for (int i = 8; i < FragmentedData.Length; i++)
                {
                    FragmentedData[ReceivedFragmentsSize] = reader.ReadByte();
                    ReceivedFragmentsSize++;
                }

                // Started a fragmented packet
                StartedFragmentedPacket = true;
            }

            // Are we finished with the fragmented data?
            if (ReceivedFragmentsSize >= FragmentedData.Length)
            {
                // Finish fragmented packet
                StartedFragmentedPacket = false;
                FragmentsTillAck = 0;

                // Handle the fragmented packet as a RELIABLE_DATA packet
                SOEWriter writer = new SOEWriter((ushort)SOEOPCodes.RELIABLE_DATA);
                writer.AddBytes(FragmentedData);

                SOEPacket wholePacket = writer.GetFinalSOEPacket(Client, false, false);

                // Receive this packet!
                Receive(wholePacket);
                return;
            }

            // Do we need to acknowledge?
            if (FragmentsTillAck == 0)
            {
                Acknowledge(FragmentSequenceNumber);
                FragmentsTillAck = 5;
            }
        }

        private void ReceiveMessage(SOEPacket packet)
        {
            SOEReader reader = new SOEReader(packet);

            // Have we received in order?
            ushort sequenceNumber = reader.ReadUInt16();
            if ((sequenceNumber != LastReceivedSequenceNumber + 1) && (sequenceNumber != 0))
            {
                ReceivedSequenceOutOfOrder(sequenceNumber);
                return;
            }

            // Acknowledge
            Acknowledge(sequenceNumber);
            LastReceivedSequenceNumber = sequenceNumber;

            // Get the SOEMessage
            byte[] data = reader.ReadToEnd();

            // Handle!
            Client.ReceiveMessage(data);
        }

        public void Receive(SOEPacket packet)
        {
            ushort opCode = packet.GetOpCode();
            if (opCode == (ushort)SOEOPCodes.FRAGMENTED_RELIABLE_DATA)
            {
                ReceiveFragment(packet);
            }
            else if (opCode == (ushort)SOEOPCodes.RELIABLE_DATA)
            {
                ReceiveMessage(packet);
            }
            else if (opCode == (ushort) SOEOPCodes.ACK_RELIABLE_DATA)
            {
                // File.WriteAllBytes(Path.GetRandomFileName(), packet.GetRaw());

                // TODO: Handle repeat-until-acknowledged and all that comes with it.
                Log.InfoFormat("(Client {0}) Data Ack", Client.GetClientID());
            }
            else
            {
                // Shrug ¯\_(ツ)_/¯
                Log.WarnFormat("(Client {0}) Received a packet that was not data or acknowledge! Discarding..", Client.GetClientID());
            }
        }

        private void SendFragmentedMessage(SOEMessage message)
        {
            // Are we already busy?
            if (BusySendingFragmentedPacket)
            {
                // The already-busy thread will pick up our message..
                FragmentedQueue.Enqueue(message);
                return;
            }

            // Set that we're busy IMMEDIATELY! (thread-safe)
            BusySendingFragmentedPacket = true;

            // Setup the for loop
            SOEWriter writer;
            SOEPacket packet;
            ushort sequenceNumber;
            bool sentInitial = false;

            // The rest aren't any different
            for (int i = 0; i < message.GetFragmentCount(); i++)
            {
                // Setup a new writer
                writer = new SOEWriter((ushort)SOEOPCodes.FRAGMENTED_RELIABLE_DATA);

                // BUG: Fixed Fragmented Packets. (01/04/2018)

                // Sequence number
                sequenceNumber = GetNextSequenceNumber();
                writer.AddUInt16(sequenceNumber);

                // Are we the first packet?
                if (!sentInitial)
                {
                    // Add the total message length
                    writer.AddUInt32((uint)message.GetLength());
                    sentInitial = true;
                }

                // Add the message fragment
                writer.AddBytes(message.GetFragment(i));

                // Get the final packet and send it!
                packet = writer.GetFinalSOEPacket(Client, true, true);
                Client.SendPacket(packet);
            }

            // Did any other thread add a fragmented packet?
            if (FragmentedQueue.Count > 0)
            {
				//BUG: Fixed Frgamented Packets. (04/10/2018)
                BusySendingFragmentedPacket = true;
				
                SendFragmentedMessage(FragmentedQueue.Dequeue());
            }
			else
			{
				//BUG: Fixed Fragmented Packets. (04/10/2018)
				BusySendingFragmentedPacket = false;
			}
		}

        private void SendMessage(SOEMessage message)
        {
            // Setup a writer
            SOEWriter writer = new SOEWriter((ushort)SOEOPCodes.RELIABLE_DATA);

            // Sequence number
            ushort sequenceNumber = GetNextSequenceNumber();
            writer.AddUInt16(sequenceNumber);

            // Add the message
            writer.AddMessage(message);

            // Get the final packet and send it!
            SOEPacket packet = writer.GetFinalSOEPacket(Client, true, true);
            Client.SendPacket(packet);

            // TODO repeat-till-acknowledged
        }

        public void Send(SOEMessage message)
        {
            if (message.IsFragmented)
            {
                SendFragmentedMessage(message);
            }
            else
            {
                SendMessage(message);
            }
        }

        public ushort GetNextSequenceNumber()
        {
            ushort sequenceNumber = NextSequenceNumber;
            if (NextSequenceNumber == 0xFFFF)
            {
                NextSequenceNumber = 0;
            }
            else
            {
                NextSequenceNumber++;
            }

            return sequenceNumber;;
        }
    }
}
