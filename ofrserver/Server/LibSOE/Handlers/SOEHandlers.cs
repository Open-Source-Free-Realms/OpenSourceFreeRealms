using SOE.Interfaces;

namespace SOE.Core
{
    public partial class SOEProtocol
    {
        public void HandleSessionRequest(SOEClient sender, SOEPacket packet)
        {
            // Setup a reader
            SOEReader reader = new SOEReader(packet);

            // Get the data from the packet
            uint crcLength = reader.ReadUInt32();
            uint sessionID = reader.ReadUInt32();
            uint udpBufferSize = reader.ReadUInt32();
            string protocol = reader.ReadNullTerminatedString();

            // Is the client using the correct protocol?
            string ourProtocol = Configuration["ProtocolString"];
            if (ourProtocol == protocol)
            {
                // Can we encrypt/compress?
                bool encryptable = false;
                bool compressable = true;

                // Start the session and manage the client
                sender.StartSession(crcLength, sessionID, udpBufferSize);
                sender.SetCompressable(compressable);
                sender.SetEncryptable(encryptable);

                if (Server.ConnectionManager.AddNewClient(sender))
                {
                    // Setup a writer
                    SOEWriter writer = new SOEWriter((ushort) SOEOPCodes.SESSION_RESPONSE);

                    // Write a response
                    writer.AddUInt32(sessionID);
                    writer.AddUInt32(sender.GetCRCSeed());
                    writer.AddByte((byte) crcLength);
                    writer.AddBoolean(compressable);
                    writer.AddBoolean(encryptable);
                    writer.AddUInt32(udpBufferSize);
                    writer.AddUInt32(3);

                    // Get the response
                    SOEPacket response = writer.GetFinalSOEPacket(sender, false, false);

                    // Send the response!
                    sender.SendPacket(response);
                }
            }
            else
            {
                // They aren't using the right protocol...
                Log.ErrorFormat("Got connection request from client with incorrect protocol. Client: {0}, Server: {1}", protocol, ourProtocol);
            }
        }

        public void HandleDisconnect(SOEClient sender, SOEPacket packet)
        {
            // Setup a reader
            SOEReader reader = new SOEReader(packet);

            // Get the data from the packet
            uint sessionID = reader.ReadUInt32();
            ushort reason = reader.ReadUInt16();

            // Handle
            if (sessionID == sender.GetSessionID())
            {
                Server.ConnectionManager.DisconnectClient(sender, reason, true);
            }
        }

        public void HandlePing(SOEClient sender)
        {
            // Setup a writer
            SOEWriter writer = new SOEWriter((ushort)SOEOPCodes.PING);
            SOEPacket pong = writer.GetFinalSOEPacket(sender, false, false);

            // Send a pong!
            sender.SendPacket(pong);
        }

        public void HandleMultiData(SOEClient sender, SOEPacket packet)
        {
            // Setup a reader and skip the OpCode
            SOEReader reader = new SOEReader(packet);
            int offset = 2;

            // Get the data length
            int dataLength = packet.GetLength();

            // Get the packets
            while (offset < dataLength)
            {
                // Message size
                int MessageSize = reader.ReadByte();

                // Read the Message data from the size
                var opCode = reader.ReadUInt16();
                byte[] data = reader.ReadBytes(MessageSize - 2);

                // Handle the Message
                HandlePacket(sender, new SOEPacket(opCode, data));

                // Move along
                offset += MessageSize + 1;
            }
        }
    }
}
