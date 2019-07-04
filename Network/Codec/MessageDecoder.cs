namespace IDK.Network.Codec
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DotNetty.Buffers;
    using DotNetty.Codecs;
    using DotNetty.Transport.Channels;

    class MessageDecoder : ByteToMessageDecoder
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer buffer, List<object> output)
        {
            buffer.MarkReaderIndex();

            if(buffer.ReadableBytes < 4)
            {
                return;
            }

            byte delimiter = buffer.ReadByte();
            buffer.ResetReaderIndex();

            if(delimiter == 60)
            {
                context.WriteAndFlushAsync(Unpooled.CopiedBuffer(Encoding.UTF8.GetBytes("<?xml version=\"1.0\"?>\r\n" +
                    "<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\r\n" +
                    "<cross-domain-policy>\r\n" +
                    "<allow-access-from domain=\"*\" to-ports=\"*\" />\r\n" +
                    "</cross-domain-policy>\x0")))
                    .ContinueWith(delegate {
                        context.CloseAsync();
                    });
            }

            buffer.MarkReaderIndex();
            int len = buffer.ReadInt();

            if(buffer.ReadableBytes < len || len < 0)
            {
                buffer.ResetReaderIndex();
                return;
            }

            output.Add(buffer.ReadBytes(len));
        }
    }
}
