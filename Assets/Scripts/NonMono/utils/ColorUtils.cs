using System.Collections.Generic;
using UnityEngine;

public static class ColorUtils
{
    private static readonly Dictionary<ColorType, string> colorHexCodes = new()
    {
        { ColorType.ResourceText, "#FF5733" },
    };

    public static Color GetColor(ColorType colorType)
    {
        if (colorHexCodes.TryGetValue(colorType, out string hexCode))
        {
            if (ColorUtility.TryParseHtmlString(hexCode, out Color color))
            {
                return color;
            }
        }

        Debug.LogError("Invalid hex code or color type");
        return Color.white;
    }
}
