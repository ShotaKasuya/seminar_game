using System.Collections.Generic;
using UnityEngine;

namespace Module.KeyMap
{
    public static class InputCharMapper
    {
        public static readonly Dictionary<KeyCode, char> KeyToCharMap = new Dictionary<KeyCode, char>
        {
            { KeyCode.A, 'a' }, { KeyCode.B, 'b' }, { KeyCode.C, 'c' },
            { KeyCode.D, 'd' }, { KeyCode.E, 'e' }, { KeyCode.F, 'f' },
            { KeyCode.G, 'g' }, { KeyCode.H, 'h' }, { KeyCode.I, 'i' },
            { KeyCode.J, 'j' }, { KeyCode.K, 'k' }, { KeyCode.L, 'l' },
            { KeyCode.M, 'm' }, { KeyCode.N, 'n' }, { KeyCode.O, 'o' },
            { KeyCode.P, 'p' }, { KeyCode.Q, 'q' }, { KeyCode.R, 'r' },
            { KeyCode.S, 's' }, { KeyCode.T, 't' }, { KeyCode.U, 'u' },
            { KeyCode.V, 'v' }, { KeyCode.W, 'w' }, { KeyCode.X, 'x' },
            { KeyCode.Y, 'y' }, { KeyCode.Z, 'z' },

            { KeyCode.Alpha0, '0' }, { KeyCode.Alpha1, '1' }, { KeyCode.Alpha2, '2' },
            { KeyCode.Alpha3, '3' }, { KeyCode.Alpha4, '4' }, { KeyCode.Alpha5, '5' },
            { KeyCode.Alpha6, '6' }, { KeyCode.Alpha7, '7' }, { KeyCode.Alpha8, '8' },
            { KeyCode.Alpha9, '9' },

            { KeyCode.Space, ' ' }, { KeyCode.Period, '.' }, { KeyCode.Comma, ',' },
            { KeyCode.Semicolon, ';' }, { KeyCode.Colon, ':' }, { KeyCode.Exclaim, '!' },
            { KeyCode.Question, '?' }, { KeyCode.Minus, '-' }, { KeyCode.Equals, '=' },
            { KeyCode.LeftBracket, '[' }, { KeyCode.RightBracket, ']' },
            { KeyCode.Backslash, '\\' }, { KeyCode.Slash, '/' }, { KeyCode.Quote, '\'' }
        };

        public static bool TryGetChar(KeyCode key, out char result)
        {
            return KeyToCharMap.TryGetValue(key, out result);
        }
    }
}