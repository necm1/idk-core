namespace IDK.Network
{
    using System;
    using System.Threading.Tasks;
    using System.Net;
    using log4net;
    using DotNetty.Transport.Bootstrapping;
    using DotNetty.Transport.Channels;
    using DotNetty.Transport.Libuv;
    using DotNetty.Buffers;
    using IDK.Network.Codec;

    public class Server : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Server));

        private IEventLoopGroup _bossGroup;
        private IEventLoopGroup _workerGroup;

        private ServerBootstrap _bootstrap;
        private IChannel _channel;

        private string _host;
        private int _port;

        public Server()
        {
            this._host = Emulator.Config().GetValue("idk.emulator.host");
            this._port = Convert.ToInt32(Emulator.Config().GetValue("idk.emulator.port"));

            this._bootstrap = new ServerBootstrap();

            var dispatcher = new DispatcherEventLoopGroup();
            this._bossGroup = dispatcher;
            this._workerGroup = new WorkerEventLoopGroup(dispatcher);
        }

        public ServerBootstrap GetBoostrap()
        {
            return this._bootstrap;
        }

        public async Task Listen()
        {
            this._bootstrap
                .Group(this._bossGroup, this._workerGroup)
                .Channel<TcpServerChannel>()
                .Option(ChannelOption.SoBacklog, Convert.ToInt32(Emulator.Config().GetValue("idk.emulator.connections")))
                .ChildOption(ChannelOption.SoKeepalive, true)
                .ChildOption(ChannelOption.TcpNodelay, true)
                .ChildOption(ChannelOption.SoRcvbuf, 8192)
                .ChildOption(ChannelOption.RcvbufAllocator, new FixedRecvByteBufAllocator(8192))
                .ChildOption(ChannelOption.Allocator, new UnpooledByteBufferAllocator(true))
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                {
                    channel.Pipeline.AddLast(new MessageDecoder());
                    channel.Pipeline.AddLast(new MessageEncoder());
                    channel.Pipeline.AddLast(new ConnectionHandler());
                }));

            try
            {
                this._channel = await this._bootstrap.BindAsync(new IPEndPoint(IPAddress.Parse(_host), _port));
            }
            catch(ChannelException e)
            {
                log.Error($"Konnte keine Verbindung öffnen ({this._host}:{this._port}): {e.ToString()}");
            }

            log.Info($"Socket Server wurde auf {this._host}:{this._port} gestartet!");
        }

        public async void Dispose()
        {
            await Task.WhenAll(
                this._bossGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)),
                this._workerGroup.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1)));
        }
    }
}
