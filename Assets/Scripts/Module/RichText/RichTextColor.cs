using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Module.RichText
{
    public class RichTextColor
    {
        private static readonly Dictionary<TextColorType, string> ColorMap = new ()
        {
            { TextColorType.Red, "#FF0000" },
            { TextColorType.Green, "#00FF00" },
            { TextColorType.Blue, "#0000FF" },
            { TextColorType.Yellow, "#FFFF00" },
            { TextColorType.Cyan, "#00FFFF" },
            { TextColorType.Magenta, "#FF00FF" },
            { TextColorType.White, "#FFFFFF" },
            { TextColorType.Black, "#000000" },
            { TextColorType.Orange, "#FFA500" },
            { TextColorType.Purple, "#800080" }
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string ApplyColor(string text, TextColorType color)
        {
            if (ColorMap.TryGetValue(color, out string hexColor))
            {
                return $"<color={hexColor}>{text}</color>";
            }
            return text;
        } 
    }
}