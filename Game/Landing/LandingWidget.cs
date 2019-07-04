namespace IDK.Game.Landing
{
    using IDK.Database.Models.Landing;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LandingWidget
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public string Image { get; set; }

        public LandingWidget(LandingWidgets widget)
        {
            this.ID = Convert.ToInt32(widget.ID);
            this.Title = widget.Title.ToString();
            this.Message = widget.Message.ToString();
            this.ButtonText = widget.ButtonText.ToString();
            this.ButtonLink = widget.ButtonLink.ToString();
            this.Message = widget.Message.ToString();
        }
    }
}
