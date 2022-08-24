namespace SOE.Interfaces
{
    public class SOEPacket
    {
        private ushort OpCode;
        private byte[] Raw;

        public SOEPacket(ushort opCode, byte[] rawMessage)
        {
            OpCode = opCode;
            Raw = rawMessage;
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
    }
}
