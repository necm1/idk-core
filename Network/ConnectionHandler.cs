namespace IDK.Network
{
    using DotNetty.Buffers;
    using DotNetty.Transport.Channels;
    using IDK.Game.Communication.Packets;
    using IDK.Game.Sessions;
    using log4net;

    class ConnectionHandler : ChannelHandlerAdapter
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ConnectionHandler));
        private Session _session;


        public override void ChannelRegistered(IChannelHandlerContext context)
        {
            _session = new Session(context.Channel);

            if (!Emulator.GameEnvironment().GetSessionManager().Add(_session))
            {
                context.CloseAsync();
            }
        }

        public override void ChannelUnregistered(IChannelHandlerContext context)
        {
            context.CloseAsync();
        }

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            IByteBuffer buffer = message as IByteBuffer;
            Emulator.GameEnvironment().GetPacketManager().Execute(this._session, new Packet(buffer));
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            if(Emulator.GameEnvironment().GetSessionManager().Remove(_session))
            {
                context.Channel.DeregisterAsync();
            }
        }
    }
}
