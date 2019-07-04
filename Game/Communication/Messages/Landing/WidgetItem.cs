namespace IDK.Communication.Messages.Landing
{
    using IDK.Game.Communication.Messages;
    using IDK.Game.Landing;
    using System;
    using System.Collections.Generic;

    class WidgetItem : ServerPacket
    {
        private Dictionary<int, LandingWidget> _landingWidgets;

        public WidgetItem(Dictionary<int, LandingWidget> landingWidgets)
        {
            this._landingWidgets = landingWidgets;
        }

        public override void Compose(Message msg)
        {
            msg.WriteInt(this._landingWidgets.Count);

            foreach (LandingWidget widget in this._landingWidgets.Values)
            {
                msg.WriteInt(widget.ID);
                msg.WriteString(widget.Title);
                msg.WriteString(widget.Message);
                msg.WriteString(widget.ButtonText);
                msg.WriteString(widget.ButtonText);
                msg.WriteInt(0); // Button Type
                msg.WriteString(widget.ButtonLink);
                msg.WriteString(widget.Image);
            }
        }

        public override short GetHeader()
        {
            return Headers.LandingWidget;
        }
    }
}
