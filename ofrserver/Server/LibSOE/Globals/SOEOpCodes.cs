namespace SOE
{
    public enum SOEOPCodes : ushort
    {
        SESSION_REQUEST = 0x01,
        SESSION_RESPONSE = 0x02,
        MULTI = 0x03,
        DISCONNECT = 0x05,
        PING = 0x06,

        NET_STATUS_REQUEST = 0x07,
        NET_STATUS_RESPONSE = 0x08,

        RELIABLE_DATA = 0x09,
        FRAGMENTED_RELIABLE_DATA = 0x0D,
        OUT_OF_ORDER_RELIABLE_DATA = 0x11,
        ACK_RELIABLE_DATA = 0x15,
        MULTI_MESSAGE = 0x19,

        FATAL_ERROR = 0x1D,
        FATAL_ERROR_RESPONSE = 0x1E
    }
}
