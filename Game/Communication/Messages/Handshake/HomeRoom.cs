namespace IDK.Game.Communication.Messages.Handshake
{
    using IDK.Communication.Messages;
    using System;

    class HomeRoom : ServerPacket
    {
        public override void Compose(Message msg)
        {
            msg.WriteInt(0);
            msg.WriteInt(0);
        }

        public override short GetHeader()
        {
            return Headers.NavigatorSettings;
        }
    }
}
