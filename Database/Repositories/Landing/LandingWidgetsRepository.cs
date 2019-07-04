namespace IDK.Models.Repositories.Landing
{
    using IDK.Database.Models.Landing;
    using System.Collections.Generic;
    using System.Linq;

    public class LandingWidgetRepository : IRepository<LandingWidgets>
    {
        public List<LandingWidgets> GetAll()
        {
            return Emulator.Database().GetTable<LandingWidgets>().Select(users => users).ToList<LandingWidgets>();
        }
    }
}
