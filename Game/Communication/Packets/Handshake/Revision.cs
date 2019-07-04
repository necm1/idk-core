namespace IDK.Game.Communication.Packets.Handshake
{
    using System;
    using IDK.Game.Sessions;

    public class Revision : IPacket
    {
        public void Parse(Session session, Packet message)
        {
            string revision = message.ReadString();

            if(revision != Emulator.REVISION)
            {
                session.Dispose();
            }
        }
    }
}