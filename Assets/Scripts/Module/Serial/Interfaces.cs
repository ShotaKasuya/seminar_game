namespace Module.Serial
{
    public interface IPortWritable
    {
        public void Write(Packet packet);
    }

    public interface IPortInitializable
    {
        public void InitializePort(string portName);
    }

    public struct Packet
    {
        public Packet
        (
            HandType hand,
            FingerType finger,
            float duration
        )
        {
            Hand = hand;
            Finger = finger;
            Duration = (int)(duration * 10);
        }

        private Packet
        (
            HandType hand,
            FingerType finger,
            int duration
        )
        {
            Hand = hand;
            Finger = finger;
            Duration = duration;
        }

        private HandType Hand { get; }
        private FingerType Finger { get; }
        private int Duration { get; }

        public byte Serialize()
        {
            byte value = 0;
            value |= (byte)((byte)Hand << 7);
            value |= (byte)((byte)Finger << 4);
            value |= (byte)Duration;

            return value;
        }

        public static Packet Deserialize(byte packet)
        {
            var hand = (HandType)(packet >> 7);
            var finger = (FingerType)((packet >> 4) & 0b0111);
            var duration = packet & 0b_1111;

            return new Packet(hand, finger, duration);
        }

        public override string ToString()
        {
            return $"Hand: {Hand}, Finger: {Finger}, Duration: {(float)Duration / 10}";
        }
    }

    public enum HandType
    {
        Left = 0b_0,
        Right = 0b_1,
    }

    /// <summary>
    /// 手の指を表す列挙型。
    /// </summary>
    public enum FingerType
    {
        /// <summary>
        /// 親指。
        /// </summary>
        Thumb = 0b_0001,

        /// <summary>
        /// 人差し指。
        /// </summary>
        Index = 0b_0010,

        /// <summary>
        /// 中指。
        /// </summary>
        Middle = 0b_0011,

        /// <summary>
        /// 薬指。
        /// </summary>
        Ring = 0b_0100,

        /// <summary>
        /// 小指。
        /// </summary>
        Little = 0b_0101,
    }
}