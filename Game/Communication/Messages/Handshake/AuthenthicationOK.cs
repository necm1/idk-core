namespace IDK.Game.Communication.Messages.Handshake
{
    using IDK.Communication.Messages;
    using System;

    class AuthenthicationOK : ServerPacket
    {
        public override void Compose(Message msg)
        {

        }

        public override short GetHeader()
        {
            return Headers.AuthenthicatonOK;
        }
    }
}
