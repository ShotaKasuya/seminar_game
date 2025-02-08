using System.Collections.Generic;

namespace Module.Serial
{
    public static class FingerMapping
    {
        public static (HandType, FingerType) GetFinger(char c)
        {
            return FingerPosition[c];
        }
        
        private static readonly Dictionary<char, (HandType, FingerType)> FingerPosition =
            new ()
            {
                { 'Q', (HandType.Left, FingerType.Little) },
                { 'q', (HandType.Left, FingerType.Little) },
                { 'A', (HandType.Left, FingerType.Little) },
                { 'a', (HandType.Left, FingerType.Little) },
                { 'Z', (HandType.Left, FingerType.Little) },
                { 'z', (HandType.Left, FingerType.Little) },
                { 'W', (HandType.Left, FingerType.Ring) },
                { 'w', (HandType.Left, FingerType.Ring) },
                { 'S', (HandType.Left, FingerType.Ring) },
                { 's', (HandType.Left, FingerType.Ring) },
                { 'X', (HandType.Left, FingerType.Ring) },
                { 'x', (HandType.Left, FingerType.Ring) },
                { 'E', (HandType.Left, FingerType.Middle) },
                { 'e', (HandType.Left, FingerType.Middle) },
                { 'D', (HandType.Left, FingerType.Middle) },
                { 'd', (HandType.Left, FingerType.Middle) },
                { 'C', (HandType.Left, FingerType.Middle) },
                { 'c', (HandType.Left, FingerType.Middle) },
                { 'R', (HandType.Left, FingerType.Index) },
                { 'r', (HandType.Left, FingerType.Index) },
                { 'F', (HandType.Left, FingerType.Index) },
                { 'f', (HandType.Left, FingerType.Index) },
                { 'V', (HandType.Left, FingerType.Index) },
                { 'v', (HandType.Left, FingerType.Index) },
                { 'T', (HandType.Left, FingerType.Index) },
                { 't', (HandType.Left, FingerType.Index) },
                { 'G', (HandType.Left, FingerType.Index) },
                { 'g', (HandType.Left, FingerType.Index) },
                { 'B', (HandType.Left, FingerType.Index) },
                { 'b', (HandType.Left, FingerType.Index) },
                { 'Y', (HandType.Left, FingerType.Thumb) },
                { 'y', (HandType.Left, FingerType.Thumb) },
                { 'H', (HandType.Left, FingerType.Thumb) },
                { 'h', (HandType.Left, FingerType.Thumb) },
                { 'N', (HandType.Left, FingerType.Thumb) },
                { 'n', (HandType.Left, FingerType.Thumb) },
                { 'U', (HandType.Left, FingerType.Thumb) },
                { 'u', (HandType.Left, FingerType.Thumb) },
                { 'J', (HandType.Left, FingerType.Thumb) },
                { 'j', (HandType.Left, FingerType.Thumb) },
                { 'M', (HandType.Left, FingerType.Thumb) },
                { 'm', (HandType.Left, FingerType.Thumb) },
                { 'I', (HandType.Right, FingerType.Thumb) },
                { 'i', (HandType.Right, FingerType.Thumb) },
                { 'K', (HandType.Right, FingerType.Thumb) },
                { 'k', (HandType.Right, FingerType.Thumb) },
                { 'O', (HandType.Right, FingerType.Index) },
                { 'o', (HandType.Right, FingerType.Index) },
                { 'L', (HandType.Right, FingerType.Index) },
                { 'l', (HandType.Right, FingerType.Index) },
                { 'P', (HandType.Right, FingerType.Middle) },
                { 'p', (HandType.Right, FingerType.Middle) }
            };
    }
}