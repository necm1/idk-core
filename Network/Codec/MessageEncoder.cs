namespace IDK.Network.Codec
{
    using System;
    using System.Collections.Generic;
    using DotNetty.Buffers;
    using DotNetty.Codecs;
    using DotNetty.Transport.Channels;
    using IDK.Communication.Messages;
    using IDK.Game.Communication.Messages;
    using log4net;

    class MessageEncoder : MessageToMessageEncoder<ServerPacket>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MessageEncoder));

        protected override void Encode(IChannelHandlerContext context, ServerPacket packet, List<object> output)
        {
            IByteBuffer buffer = Unpooled.Buffer();

            Message msg = new Message(packet.GetHeader(), buffer);
            packet.Compose(msg);

            log.Debug($"{packet.GetHeader()} wurde abgeschickt");

            if (!msg.HasLength())
            {
                buffer.SetInt(0, buffer.WriterIndex - 4);
            }

            output.Add(buffer);
        }
    }
}
