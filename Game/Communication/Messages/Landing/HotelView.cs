namespace IDK.Game.Communication.Messages.Landing
{
    using IDK.Communication.Messages;

    class HotelView : ServerPacket
    {
        public override void Compose(Message msg)
        {
            
        }

        public override short GetHeader()
        {
            return Headers.HotelView;
        }
    }
}
