namespace IDK.Communication.Messages.Misc
{
    using IDK.Game.Communication.Messages;
    class Ping : ServerPacket
    {
        public override void Compose(Message msg)
        {
            msg.WriteInt(0);
        }

        public override short GetHeader()
        {
            return Headers.Ping;
        }
    }
}
