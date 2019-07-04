using System;
using IDK.Game.Sessions;

namespace IDK.Game.Communication.Packets
{
    public interface IPacket {
        void Parse(Session session, Packet message);
    }
}