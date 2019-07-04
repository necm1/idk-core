namespace IDK.Game.Communication.Packets.Misc {
    using IDK.Game.Communication.Messages.Handshake;
    using IDK.Game.Sessions;
    using IDK.Models.Repositories.User;

    public class Ticket : IPacket {
        public void Parse(Session session, Packet message) {
            string ticket = message.ReadString();

            UserRepository userRepo = new UserRepository();
            if(userRepo.GetByTicket(ticket).Count == 1)
            {
                session.SetHabbo(new Habbo.Habbo(userRepo.GetByTicket(ticket)));
                session.SendQueue(new AuthenthicationOK());
                session.SendQueue(new HomeRoom());
                session.Flush();
            } else
            {
                session.Dispose();
            }
        }
    }
}