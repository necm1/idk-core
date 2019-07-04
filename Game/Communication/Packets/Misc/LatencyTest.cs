namespace IDK.Communication.Packets.Misc
{
    using IDK.Communication.Messages.Misc;
    using IDK.Game.Communication.Packets;
    using IDK.Game.Sessions;

    class LatencyTest : IPacket
    {
        public void Parse(Session session, Packet message)
        {
            session.Send(new Ping());
        }
    }
}
