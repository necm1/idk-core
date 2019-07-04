namespace IDK.Game.Sessions
{
    using DotNetty.Transport.Channels;
    using IDK.Game.Communication.Messages;
    using IDK.Game.Habbo;
    using log4net;
    using System;

    public class Session : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SessionManager));

        private IChannel _channel;

        public string UniqueID { get; set; }
        public string Ticket { get; set; }

        private Habbo _habbo;

        public Session(IChannel channel)
        {
            this._channel = channel;
        }

        public void SetHabbo(Habbo habbo)
        {
            this._habbo = habbo;
        }

        public Habbo GetHabbo()
        {
            return this._habbo;
        }

        public void Send(ServerPacket packet)
        {
            this._channel.WriteAndFlushAsync(packet);
        }

        public void SendQueue(ServerPacket packet)
        {
            this._channel.WriteAsync(packet);
        }

        public void Flush()
        {
            this._channel.Flush();
        }

        public void Dispose()
        {
            this._channel.CloseAsync();
        }
    }
}
