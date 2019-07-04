namespace IDK.Game.Communication.Messages
{
    using IDK.Communication.Messages;

    public abstract class ServerPacket
    {
        public abstract void Compose(Message msg);
        public abstract short GetHeader();
    }
}
