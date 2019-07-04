namespace IDK.Game.Communication.Packets.Handshake {
    using System;
    using IDK.Game.Sessions;

    public class UniqueID : IPacket {
        public void Parse(Session session, Packet message) {
            string junkString = message.ReadString();
            string machineId = message.ReadString();
            string os = message.ReadString();

            if(string.IsNullOrEmpty(session.UniqueID)) {
                session.UniqueID = machineId;
            } else {
                session.Dispose();
            }
        }
    }
}