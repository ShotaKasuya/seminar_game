using Domain.IModel.InGame;
using Module.Serial;

namespace Domain.UseCase.InGame
{
    public class MissTypeCase
    {
        public MissTypeCase
        (
            IFailEventModel onFailEvent,
            IPortWritable portWritable,
            IElectricTimeModel electricTime
        )
        {
            FailEventModel = onFailEvent;
            PortWritable = portWritable;
            ElectricTimeModel = electricTime;

            onFailEvent.OnFailEvent += OnFailEvent;
        }

        private void OnFailEvent(char c)
        {
            var finger = FingerMapping.GetFinger(c);
            // var (hand, finger) = FingerMapping.GetFinger(c);
            var time = ElectricTimeModel.AttackTime;
            
            var packet = new Packet(finger.Item1, finger.Item2, time);
            // var packet = new Packet(hand, finger, time);
            PortWritable.Write(packet);
        }

        private IFailEventModel FailEventModel { get; }
        private IPortWritable PortWritable { get; }
        private IElectricTimeModel ElectricTimeModel { get; }
    }
}