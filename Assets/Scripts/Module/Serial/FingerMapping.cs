using System.Collections.Generic;

namespace Module.Serial
{
    public static class FingerMapping
    {
        private static Dictionary<string, (HandType, FingerType)> _fingerPosition =
            new Dictionary<string, (HandType, FingerType)>()
            {
                { "Q", (HandType.Left, FingerType.Little) },
                { "q", (HandType.Left, FingerType.Little) },
                { "A", (HandType.Left, FingerType.Little) },
                { "a", (HandType.Left, FingerType.Little) },
                { "Z", (HandType.Left, FingerType.Little) },
                { "z", (HandType.Left, FingerType.Little) },
                { "W", 2 },
                { "w", 2 },
                { "S", 2 },
                { "s", 2 },
                { "X", 2 },
                { "x", 2 },
                { "E", 3 },
                { "e", 3 },
                { "D", 3 },
                { "d", 3 },
                { "C", 3 },
                { "c", 3 },
                { "R", 4 },
                { "r", 4 },
                { "F", 4 },
                { "f", 4 },
                { "V", 4 },
                { "v", 4 },
                { "T", 4 },
                { "t", 4 },
                { "G", 4 },
                { "g", 4 },
                { "B", 4 },
                { "b", 4 },
                { "Y", 5 },
                { "y", 5 },
                { "H", 5 },
                { "h", 5 },
                { "N", 5 },
                { "n", 5 },
                { "U", 5 },
                { "u", 5 },
                { "J", 5 },
                { "j", 5 },
                { "M", 5 },
                { "m", 5 },
                { "I", 6 },
                { "i", 6 },
                { "K", 6 },
                { "k", 6 },
                { "O", 7 },
                { "o", 7 },
                { "L", 7 },
                { "l", 7 },
                { "P", 8 },
                { "p", 8 }
            };
    }
}