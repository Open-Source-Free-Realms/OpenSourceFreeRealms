using System.Collections.Generic;

namespace SOE.Interfaces
{
    public class SOEMessage
    {
        private ushort OpCode;
        private byte[] Raw;

        private readonly List<byte[]> Fragments;
        public bool IsFragmented;

        public SOEMessage(ushort opCode, byte[] rawMessage)
        {
            OpCode = opCode;
            Raw = rawMessage;

            Fragments = new List<byte[]>();
            IsFragmented = false;
        }

        public ushort GetOpCode()
        {
            return OpCode;
        }

        public byte[] GetRaw()
        {
            return Raw;
        }

        public int GetLength()
        {
            return Raw.Length;
        }

        public int GetFragmentCount()
        {
            return Fragments.Count;
        }

        public byte[] GetFragment(int i)
        {
            if (IsFragmented)
            {
                if (i < Fragments.Count)
                {
                    return Fragments[i];
                }
            }

            return new byte[0];
        }

        public void AddFragment(byte[] fragment)
        {
            if (!IsFragmented)
            {
                IsFragmented = true;
            }

            Fragments.Add(fragment);
        }
    }
}
