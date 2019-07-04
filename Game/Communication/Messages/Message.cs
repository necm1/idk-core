namespace IDK.Communication.Messages
{
    using DotNetty.Buffers;
    using System;
    using System.Text;

    public class Message
    {
        private IByteBuffer _buffer;
        private short _header;

        public Message(short header, IByteBuffer buffer)
        {
            this._header = header;
            this._buffer = buffer;

            this._buffer.WriteInt(-1);
            this._buffer.WriteShort(header);
        }

        public void WriteString(string data)
        {
            if(string.IsNullOrEmpty(data))
            {
                data = "";
            }

            short length = Convert.ToInt16(data.Length);

            this._buffer.WriteShort(length);
            this._buffer.WriteBytes(Encoding.UTF8.GetBytes(data));
        }

        public void WriteInt(int data)
        {
            this._buffer.WriteInt(data);
        }

        public bool HasLength()
        {
            return (this._buffer.GetInt(0) > -1);
        }
    }
}
