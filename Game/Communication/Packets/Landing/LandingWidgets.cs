namespace IDK.Communication.Packets.Landing
{
    using IDK.Communication.Messages.Landing;
    using IDK.Game.Communication.Packets;
    using IDK.Game.Sessions;

    class LandingWidgets : IPacket
    {
        public void Parse(Session session, Packet message)
        {
            session.Send(new WidgetItem(Emulator.GameEnvironment().GetLandingManager().GetWidgets()));
        }
    }
}
