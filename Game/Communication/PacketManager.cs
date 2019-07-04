namespace IDK.Game.Communication {
    using System.Collections.Generic;
    using log4net;
    using IDK.Game.Sessions;
    using IDK.Game.Communication.Packets;
    using IDK.Game.Communication.Packets.Handshake;
    using IDK.Game.Communication.Packets.Misc;
    using IDK.Communication.Packets.Landing;
    using IDK.Communication.Packets.Misc;

    public class PacketManager {
        private static readonly ILog log = LogManager.GetLogger(typeof(PacketManager));

        private Dictionary<int, IPacket> _messages;

        public PacketManager() {
            this._messages = new Dictionary<int, IPacket>();
            
            this.HandleHandshake();
            this.HandleMisc();
            this.HandleLanding();

            log.Info($"{this._messages.Count} Packet(s) wurden geladen!");
        }

        private void HandleHandshake() {
            this._messages.Add(Headers.Revision, new Revision());
            this._messages.Add(Headers.UniqueID, new UniqueID());
            this._messages.Add(Headers.Ticket, new Ticket());
        }

        private void HandleMisc() {
            this._messages.Add(Headers.ExternalVariables, new ExternalVariables());
            this._messages.Add(Headers.MemoryPerfomance, new MemoryPerfomance());
            this._messages.Add(Headers.LatencyTest, new LatencyTest());
        }

        private void HandleLanding()
        {
            this._messages.Add(Headers.LandingWidgets, new LandingWidgets());
        }

        public void Execute(Session session, Packet message) {
            if(this._messages.ContainsKey(message.Header)) {
                this._messages[message.Header].Parse(session, message);
            } else {
                log.Warn($"Packet [{message.Header}] konnte nicht ausgeführt werden.");
            }
        }
    }
}