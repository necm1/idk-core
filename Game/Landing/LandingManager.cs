namespace IDK.Game.Landing
{
    using IDK.Models.Repositories.Landing;
    using log4net;
    using System;
    using System.Collections.Generic;

    public class LandingManager : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LandingManager));

        private LandingWidgetRepository _landingWidgetRepo;
        private Dictionary<int, LandingWidget> _widgets;

        public LandingManager()
        {
            this._landingWidgetRepo = new LandingWidgetRepository();
            this._widgets = new Dictionary<int, LandingWidget>();

            this.LoadWidgets();
            log.Info("LandingManager wurde geladen");
        }

        public void LoadWidgets()
        {
            if(this._widgets.Count > 0)
            {
                this._widgets.Clear();
            }

            this._landingWidgetRepo.GetAll().ForEach((widget) =>
            {
                this._widgets.Add(Convert.ToInt32(widget.ID), new LandingWidget(widget));
            });
        }

        public Dictionary<int, LandingWidget> GetWidgets()
        {
            return this._widgets;
        }

        public void Dispose()
        {
            this._widgets.Clear();
        }
    }
}
