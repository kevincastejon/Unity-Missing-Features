using UnityEngine;

namespace KevinCastejon.MissingFeatures.MissingAttributes
{
    /// <summary>
    /// Convenience color presets. It must be casted to 'int' when passed as a parameter in HeaderPlusAttribute constructor.
    /// </summary>
    public enum HeaderPlusColor
    {
        red,
        green,
        blue,
        white,
        black,
        yellow,
        cyan,
        magenta,
        gray,
        grey
    }
    /// <summary>
    /// Custom inspector property header that allows using an icon, a custom header label text and a custom header label color.
    /// </summary>
    public class HeaderPlusAttribute : PropertyAttribute
    {
        public string iconPath;
        public string text;
        public bool textIsNull;
        public bool colorIsNull;
        public Color color;
        public Color[] _colorPresets = new Color[]{
        Color.red,
        Color.green,
        Color.blue,
        Color.white,
        Color.black,
        Color.yellow,
        Color.cyan,
        Color.magenta,
        Color.gray,
        Color.grey
    };

        /// <summary>
        /// Custom inspector property header that allows using an icon, a custom header label text and a custom header label color.
        /// </summary>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        public HeaderPlusAttribute(string iconPath)
        {
            this.iconPath = iconPath;
            textIsNull = true;
            colorIsNull = true;
        }
        /// <summary>
        /// Custom inspector property header that allows using an icon, a custom header label text and a custom header label color.
        /// </summary>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="text">The custom header label text.</param>
        public HeaderPlusAttribute(string iconPath, string text)
        {
            this.iconPath = iconPath;
            this.text = text;
            colorIsNull = true;
        }
        /// <summary>
        /// Custom inspector property header that allows using an icon, a custom header label text and a custom header label color.
        /// </summary>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="text">The custom header label text.</param>
        /// <param name="colorElements">The custom header label color as an four elements array : three colors (RGB) and one alpha.</param>
        public HeaderPlusAttribute(string iconPath, string text, float[] colorElements)
        {
            this.iconPath = iconPath;
            this.text = text;
            color = new Color(colorElements[0], colorElements[1], colorElements[2], colorElements[3]);
        }
        /// <summary>
        /// Custom inspector property header that allows using an icon, a custom header label text and a custom header label color.
        /// </summary>
        /// <param name="iconPath">The relative path (starting from 'Assets/') to the icon you want to display in front of the property.</param>
        /// <param name="text">The custom header label text.</param>
        /// <param name="headerPlusColor">The custom header label color as an integer representing the HeaderPlusColor enum index of the desired color preset.</param>
        public HeaderPlusAttribute(string iconPath, string text, int headerPlusColor)
        {
            this.iconPath = iconPath;
            this.text = text;
            color = _colorPresets[headerPlusColor];
        }
    }
}