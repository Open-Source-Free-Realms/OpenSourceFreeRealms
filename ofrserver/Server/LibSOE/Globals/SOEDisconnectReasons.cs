namespace SOE
{
    public enum SOEDisconnectReason : ushort
    {
        None,
        IcmpError,
        Timeout,
        OtherSideTerminated,
        ManagerDeleted,
        ConnectFail,
        Application,
        UnreachableConnection,
        UnacknowledgedTimeout,
        NewConnectionAttempt,
        ConnectionRefused,
        ConnectError,
        ConnectingToSelf,
        ReliableOverflow,
        ApplicationReleased,
        CorruptPacket,
        ProtocolMismatch
    }
}
