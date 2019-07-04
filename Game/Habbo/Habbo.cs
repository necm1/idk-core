namespace IDK.Game.Habbo
{
    using IDK.Database.Models.User;
    using System;
    using System.Collections.Generic;

    public class Habbo
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Ticket { get; set; }
        public int Rank { get; set; }
        public string Look { get; set; }
        public string Gender { get; set; }

        public Habbo(List<User> data)
        {
            foreach(var habbo in data)
            {
                this.ID = Convert.ToInt32(habbo.ID);
                this.Username = habbo.Username.ToString();
                this.Ticket = habbo.AuthTicket.ToString();
                this.Rank = Convert.ToInt32(habbo.Rank);
                this.Look = habbo.Look.ToString();
                this.Gender = habbo.Gender.ToString();
            }
        }
    }
}
