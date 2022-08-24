using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using SOE.Core;

namespace SOE.Interfaces
{
    public class SOEWriter
    {
        // Message details
        private ushort OpCode;
        private bool IsMessage;

        // Message
        private List<byte> Data;

        public SOEWriter()
        {
            // Message information
            Data = new List<byte>();
            OpCode = 0;

            // We're some kinda data, not a message or packet..
            IsMessage = false;
        }

        public SOEWriter(ushort opCode, bool isMessage=false)
        {
            // Message information
            Data = new List<byte>();
            IsMessage = isMessage;
            OpCode = opCode;

            // Add our OpCode
            if (IsMessage)
            {
                AddHostUInt16(opCode);
            }
            else
            {
                AddUInt16(opCode);
            }
        }

        public SOEWriter(SOEPacket packet)
        {
            // Message information
            Data = new List<byte>(packet.GetRaw());
            OpCode = packet.GetOpCode();

            // We're a packet, not a message
            IsMessage = false;
        }

        public SOEWriter(SOEMessage message)
        {
            // Message information
            Data = new List<byte>(message.GetRaw());
            OpCode = message.GetOpCode();

            // We're a message!
            IsMessage = true;
        }

        public void AddByte(byte value)
        {
            Data.Add(value);
        }

        public void AddBytes(byte[] value)
        {
            foreach (byte b in value)
            {
                Data.Add(b);
            }
        }

        public void AddUInt16(ushort value)
        {
            byte[] Message = BitConverter.GetBytes(value).Reverse().ToArray();
            AddBytes(Message);
        }

        public void AddUInt32(uint value)
        {
            byte[] Message = BitConverter.GetBytes(value).Reverse().ToArray();
            AddBytes(Message);
        }

        public void AddUInt64(ulong value)
        {
            byte[] Message = BitConverter.GetBytes(value).Reverse().ToArray();
            AddBytes(Message);
        }

        public void AddInt16(short value)
        {
            byte[] Message = BitConverter.GetBytes(value).Reverse().ToArray();
            AddBytes(Message);
        }

        public void AddInt32(int value)
        {
            byte[] Message = BitConverter.GetBytes(value).Reverse().ToArray();
            AddBytes(Message);
        }

        public void AddInt64(long value)
        {
            byte[] Message = BitConverter.GetBytes(value).Reverse().ToArray();
            AddBytes(Message);
        }

        public void AddHostUInt16(ushort value)
        {
            byte[] Message = BitConverter.GetBytes(value).ToArray();
            AddBytes(Message);
        }

        public void AddHostUInt32(uint value)
        {
            byte[] Message = BitConverter.GetBytes(value).ToArray();
            AddBytes(Message);
        }

        public void AddHostUInt64(ulong value)
        {
            byte[] Message = BitConverter.GetBytes(value).ToArray();
            AddBytes(Message);
        }

        public void AddNullTerminatedString(string value)
        {
            value += (char)0x0;
            byte[] Message = Encoding.ASCII.GetBytes(value);
            AddBytes(Message);
        }

        public void AddASCIIString(string value)
        {
            byte[] Message = Encoding.ASCII.GetBytes(value);
            AddHostUInt32((uint)value.Length);
            AddBytes(Message);
        }

        public void AddUnicodeString(string value)
        {
            byte[] Message = Encoding.Unicode.GetBytes(value);
            AddHostUInt32((uint)value.Length);
            AddBytes(Message);
        }

        public void AddBoolean(bool value)
        {
            byte v = (byte)(value ? 0x1 : 0x0);
            AddByte(v);
        }

        public void AddFloat(float value)
        {
            byte[] Message = BitConverter.GetBytes(value).ToArray();
            AddBytes(Message);
        }

        public void AddMessage(SOEMessage message)
        {
            if (IsMessage)
            {
                // Handle multi messages
                if (OpCode == (ushort)SOEOPCodes.MULTI_MESSAGE)
                {
                    if (message.GetOpCode() == (ushort)SOEOPCodes.MULTI_MESSAGE)
                    {
                        // Setup a reader
                        SOEReader reader = new SOEReader(message);

                        // Get the messages and add them
                        byte[] messages = reader.ReadToEnd();
                        AddBytes(messages);
                    }
                    else
                    {
                        // Get the size of the message
                        int size = message.GetLength();

                        // Is the size bigger than 255?
                        if (size > 0xFF)
                        {
                            // Do the stupid >255 thing
                            AddByte(0xFF);
                            size -= 0xFF;
                            
                            // Get how many bytes to add
                            byte toAdd = (byte)((size / 0xFF) + (size % 0xFF) & 0xFF);
                            AddByte(toAdd);

                            // Add sizes until we're at a value of 0
                            while (size > 0)
                            {
                                // Do we not want to add 0xFF?
                                if (size < 0xFF)
                                {
                                    // Add the rest of the size
                                    AddByte((byte)size);
                                    size = 0;
                                }
                                else
                                {
                                    // Add 0xFF
                                    AddByte(0xFF);
                                    size -= 0xFF;
                                }
                            }
                        }
                        else
                        {
                            // Just do the regular size adding
                            AddByte((byte)(size & 0xFF));
                        }

                        // Add the actual message
                        AddBytes(message.GetRaw());
                    }
                }
            }
            else
            {
                // Just add the message
                AddBytes(message.GetRaw());
            }
        }

        public SOEPacket GetFinalSOEPacket(SOEClient client, bool compressed, bool appendCRC)
        {
            // Data
            byte[] originalPacket = GetRaw();
            byte[] rawData = new byte[Data.Count - 2];
            byte[] newPacket;

            // Fail-safe
            ushort originalOpCode = 0;

            // Are we a message?
            if (IsMessage)
            {
                // Yes, so we'll try make a data packet.
                // Can we fit into one packet?
                SOEMessage message = GetFinalSOEMessage(client);
                if (message.IsFragmented)
                {
                    // We're gonna have to fragment, so we can't handle this gracefully...
                    client.Server.Log.Fatal("Tried to handle 'GetFinalSOEPacket' call on written SOEMessage gracefully but failed due to fragmentation.");
                    Environment.Exit(0);
                }

                // Make the new packet
                Data = new List<byte>();
                AddUInt16(client.GetNextSequenceNumber());
                AddBytes(originalPacket);

                // Set our raw data
                rawData = GetRaw();

                // Change our OpCode so that we're a reliable data packet
                originalOpCode = OpCode;
                OpCode = (ushort)SOEOPCodes.RELIABLE_DATA;

                // Because we're reliable data, take compression into consideration and append a CRC
                compressed = true;
                appendCRC = true;

                // We handled it gracefully! :)
                client.Server.Log.Info("Handled 'GetFinalSOEPacket' call on written SOEMessage gracefully.");
            }
            else
            {
                // Get just the data for this packet. (Remove the OP Code)
                byte[] completeRawData = GetRaw();
                for (int i = 2; i < completeRawData.Length; i++)
                {
                    rawData[i - 2] = completeRawData[i];
                }
            }

            // Start a new packet
            Data = new List<byte>();
            AddUInt16(OpCode);

            // Are we compressable?
            if (client.IsCompressable())
            {
                if (compressed)
                {
                    AddBoolean(rawData.Length > 100);
                    if (rawData.Length > 100)
                    {
                        rawData = client.Compress(rawData);
                    }
                }
            }

            // Are we encrypted?
            if (client.IsEncrypted())
            {
                //  Encrypt the SOE Packet
                rawData = client.Encrypt(rawData);
            }

            // Add the raw data
            AddBytes(rawData);

            // Appended CRC32?
            if (appendCRC)
            {
                AddBytes(client.GetAppendedCRC32(GetRaw()));
            }

            // Set our new packet
            newPacket = GetRaw();

            // Get our old message before compression/encryption
            Data = new List<byte>(originalPacket);

            // If we are a message, set our OpCode back
            if (IsMessage)
            {
                // Set our OpCode back too..
                OpCode = originalOpCode;
            }

            // Return the compressed/encrypted packet
            return new SOEPacket(OpCode, newPacket);
        }

        public SOEMessage GetFinalSOEMessage(SOEClient client)
        {
            // Are we a packet?
            if (!IsMessage)
            {
                // Yes, and there really isn't a nice way to deal with this..
                client.Server.Log.Fatal("Tried Calling 'GetFinalSOEMessage' on written SOEPacket.");
                Environment.Exit(0);
            }

            // Make our message
            SOEMessage message = new SOEMessage(OpCode, GetRaw());

            // Does this message have to be fragmented?
            if (Data.Count > client.GetBufferSize())
            {
                // Setup a reader and keep track of our size
                SOEReader reader = new SOEReader(GetRaw());
                int size = message.GetLength();

                // While there are fragments to be added..
                while (size > 0)
                {
                    // Store the next fragment
                    byte[] raw;

                    // Is this fragment going to be smaller than the buffer size?
                    if (size < client.GetBufferSize())
                    {
                        raw = reader.ReadBytes(size);
                        size = 0;
                    }
                    else
                    {
                        raw = reader.ReadBytes((int)client.GetBufferSize());
                        size -= (int)client.GetBufferSize();
                    }
                    
                    // Add the finalized fragment
                    message.AddFragment(raw);
                }
            }

            // Return the message we made
            return message;
        }

        public byte[] GetRaw()
        {
            return Data.ToArray();
        }
    }
}
