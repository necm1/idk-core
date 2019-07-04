namespace IDK.Models.Repositories.User
{
    using IDK.Database.Models.User;
    using System.Collections.Generic;
    using System.Linq;

    class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            return Emulator.Database().GetTable<User>().Select(users => users).ToList<User>();
        }

        public List<User> GetByTicket(string ticket)
        {
            return Emulator.Database().GetTable<User>().Where(user => (string) user.AuthTicket == ticket).ToList();
        }
    }
}
