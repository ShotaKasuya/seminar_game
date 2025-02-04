using System;
using Module.Serial;

namespace Domain.IView.OutGame.SerialTest
{
    public interface ISerialTestView
    {
        public Action<Packet> OnSend { get; set; }
    }
}