using NetCore2Blockly.ExtensionMethods;
using System;

namespace NetCore2Blockly
{
    /// <summary>
    /// 
    /// </summary>
    public class BlocklyStringToColor
    {

        /// <summary>
        /// Convert to hue given the controller name
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ConvertToHue(int value)
        {
            var hexColor = ToHexColor(value);
            var rgbColor = ConvertFromHexToRgb(Convert.ToInt32(hexColor, 16));
            var (h, s, v) = ConvertFromRgbToHue(rgbColor);
            return (int)h; //cast to int because we want the integer part
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static string ToHexColor(int i)
        {
            return ((i >> 24) & 0xFF).ToHex()
               + ((i >> 16) & 0xFF).ToHex()
               + ((i >> 8) & 0xFF).ToHex()
               + (i & 0xFF).ToHex();
        }

        private static (int r, int g, int b) ConvertFromHexToRgb(int hexColor)
        {
            int r = (hexColor & 0xFF0000) >> 16;
            int g = (hexColor & 0xFF00) >> 8;
            int b = hexColor & 0xFF;

            return (r, g, b);
        }

        //http://www.kourbatov.com/faq/rgb2hsv.htm
        /// <summary>
        /// Generate hsv color space from rgb colors
        /// </summary>
        /// <param name="rgbColor"></param>
        /// <returns></returns>
        private static (double h, double s, double v) ConvertFromRgbToHue((int R, int G, int B) rgbColor)
        {
            var r = rgbColor.R / 255.00;
            var g = rgbColor.G / 255.00;
            var b = rgbColor.B / 255.00;

            var maxRGB = Math.Max(r, Math.Max(g, b));
            var minRGB = Math.Min(r, Math.Min(g, b));


            double computedV;
            if (minRGB == maxRGB)
            {
                computedV = minRGB;
                return (0, 0, computedV);
            }

            // Colors other than black-gray-white:
            var d = (r == minRGB) ? g - b : ((b == minRGB) ? r - g : b - r);
            var h = (r == minRGB) ? 3 : ((b == minRGB) ? 1 : 5);

            double computedH = 60 * (h - d / (maxRGB - minRGB));
            double computedS = (maxRGB - minRGB) / maxRGB;
            computedV = maxRGB;

            return (computedH, computedS, computedV);

        }
    }
}
