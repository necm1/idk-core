namespace IDK.Game {
    using IDK.Game.Communication;
    using IDK.Game.Landing;
    using IDK.Game.Sessions;

    public class GameEnvironment {
        private SessionManager _sessionManager;
        private PacketManager _packetManager;
        private LandingManager _landingManager;

        public GameEnvironment()
        {
            this._sessionManager = new SessionManager();
            this._packetManager = new PacketManager();
            this._landingManager = new LandingManager();
        }

        public SessionManager GetSessionManager()
        {
            return _sessionManager;
        }

        public PacketManager GetPacketManager()
        {
            return this._packetManager;
        }

        public LandingManager GetLandingManager()
        {
            return this._landingManager;
        }
    }
}