namespace IDK.Database.Models.User
{
    using LinqToDB.Mapping;

    [Table(Name = "users")]
    public class User
    {
        [PrimaryKey, Identity]
        public object ID { get; set; }

        [Column(Name = "username"), NotNull]
        public object Username { get; set; }

        [Column(Name = "auth_ticket"), NotNull]
        public object AuthTicket { get; set; }

        [Column(Name = "rank"), NotNull]
        public object Rank { get; set; }

        [Column(Name = "look"), NotNull]
        public object Look { get; set; }

        [Column(Name = "gender"), NotNull]
        public object Gender { get; set; }
    }
}
