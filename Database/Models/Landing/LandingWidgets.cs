namespace IDK.Database.Models.Landing
{
    using LinqToDB.Mapping;

    [Table(Name = "landing_widgets")]
    public class LandingWidgets
    {
        [PrimaryKey, Identity]
        public object ID { get; set; }

        [Column(Name = "title"), NotNull]
        public object Title { get; set; }

        [Column(Name = "message"), NotNull]
        public object Message { get; set; }

        [Column(Name = "button_text"), NotNull]
        public object ButtonText { get; set; }

        [Column(Name = "button_link"), NotNull]
        public object ButtonLink { get; set; }

        [Column(Name = "image"), NotNull]
        public object Image { get; set; }
    }
}
