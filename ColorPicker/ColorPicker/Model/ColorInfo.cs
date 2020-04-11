using System.Drawing;

namespace ColorPicker.Model
{
    internal sealed class ColorInfo
    {
        #region Constructors
        public ColorInfo(Color color)
        {
            Color = color;
        }
        #endregion

        #region Properties
        private Color Color { get; set; }
        public (byte, byte, byte) RGBComponents => (Color.R, Color.G, Color.B);
        public string RGB => $"{Color.R}, {Color.G}, {Color.B}";
        public string HEX => string.Format("{0:X2}{1:X2}{2:X2}", Color.R, Color.G, Color.B);
        #endregion
    }
}
