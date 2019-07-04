namespace IDK.Game.Communication.Packets
{
    using DotNetty.Buffers;
    using System;
    using System.Text;

    public class Packet {
        public int Header { get; set; }
        public int Length { get; set; }

        private IByteBuffer _buffer;

        public Packet(IByteBuffer buffer) {
            this._buffer = buffer;

            this.Header = buffer.ReadShort();
        }

        public string ReadString()
        {
            try
            {
                int length = this._buffer.ReadShort();
                byte[] data = this.ReadBytes(length);

                return Encoding.UTF8.GetString(data);
            } catch(Exception)
            {
                return null;
            }
        }

        public byte[] ReadBytes(int length)
        {
            try
            {
                byte[] data = new byte[length];
                this._buffer.ReadBytes(data);

                return data;
            } catch(Exception)
            {
                return null;
            }
        }

    }
}