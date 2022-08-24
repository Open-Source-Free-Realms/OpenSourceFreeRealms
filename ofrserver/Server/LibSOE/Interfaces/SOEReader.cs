using System.IO;
using System.Text;
using System.Collections.Generic;

namespace SOE.Interfaces
{
    public class SOEReader
    {
        private readonly Stream Stream;

        public SOEReader(SOEPacket packet)
        {
            Stream = new MemoryStream(packet.GetRaw());

            // Skip the SOE OpCode
            ReadUInt16();
        }

        public SOEReader(SOEMessage message)
        {
            Stream = new MemoryStream(message.GetRaw());

            // Skip the message OpCode
            ReadHostInt16();
        }

        public SOEReader(byte[] rawPacket)
        {
            Stream = new MemoryStream(rawPacket);
        }

        public byte ReadByte()
        {
            byte[] buffer = ReadBytes(1);
            return buffer[0];
        }

        public bool ReadBoolean()
        {
            return ReadByte() == 0x01;
        }

        public byte[] ReadBytes(int length)
        {
            byte[] buffer = new byte[length];
            Stream.Read(buffer, 0, length);

            return buffer;
        }

        public ushort ReadUInt16()
        {
            byte[] buffer = ReadBytes(2);
            return (ushort)(buffer[0] << 8 | buffer[1]);
        }

        public uint ReadUInt32()
        {
            byte[] buffer = ReadBytes(4);
            return (uint)(buffer[0] << 24 | buffer[1] << 16 | buffer[2] << 8 | buffer[3]);
        }

        public uint ReadUInt64()
        {
            byte[] buffer = ReadBytes(8);
            return (uint)(buffer[0] << 56 | buffer[1] << 48 | buffer[2] << 40 | buffer[3] << 32 | buffer[4] << 24 | buffer[5] << 16 | buffer[6] << 8 | buffer[7]);
        }

        public short ReadInt16()
        {
            byte[] buffer = ReadBytes(2);
            return (short)(buffer[0] << 8 | buffer[1]);
        }

        public int ReadInt32()
        {
            byte[] buffer = ReadBytes(4);
            return buffer[0] << 24 | buffer[1] << 16 | buffer[2] << 8 | buffer[3];
        }

        public ushort ReadHostUInt16()
        {
            byte[] buffer = ReadBytes(2);
            return (ushort)(buffer[1] << 8 | buffer[0]);
        }

        public uint ReadHostUInt32()
        {
            byte[] buffer = ReadBytes(4);
            return (uint)(buffer[3] << 24 | buffer[2] << 16 | buffer[1] << 8 | buffer[0]);
        }

        public uint ReadHostUInt64()
        {
            byte[] buffer = ReadBytes(8);
            return (uint)(buffer[7] << 56 | buffer[6] << 48 | buffer[5] << 40 | buffer[4] << 32 | buffer[3] << 24 | buffer[2] << 16 | buffer[1] << 8 | buffer[0]);
        }

        public short ReadHostInt16()
        {
            byte[] buffer = ReadBytes(2);
            return (short)(buffer[1] << 8 | buffer[0]);
        }

        public int ReadHostInt32()
        {
            byte[] buffer = ReadBytes(4);
            return buffer[3] << 24 | buffer[2] << 16 | buffer[1] << 8 | buffer[0];
        }

        public string ReadNullTerminatedString()
        {
            List<byte> buffer = new List<byte> ();
            while (true)
            {
                byte b = ReadByte();
                if (b != (char)0x0)
                {
                    buffer.Add(b);
                    continue;
                }
                
                break;
            }

            return Encoding.ASCII.GetString(buffer.ToArray());
        }

        public string ReadASCIIString()
        {
            uint length = ReadHostUInt32();
            byte[] buffer = ReadBytes((int)length);

            return Encoding.ASCII.GetString(buffer);
        }

        public string ReadUnicodeString()
        {
            uint length = ReadHostUInt32();
            byte[] buffer = ReadBytes((int)length * 2);

            return Encoding.Unicode.GetString(buffer);
        }

        public byte[] ReadBlob()
        {
            uint length = ReadHostUInt32();
            return ReadBytes((int) length);
        }

        public byte[] ReadToEnd(uint exclude=0)
        {
            long length = (Stream.Length - exclude) - Stream.Position;
            return ReadBytes((int)length);
        }
    }
}
