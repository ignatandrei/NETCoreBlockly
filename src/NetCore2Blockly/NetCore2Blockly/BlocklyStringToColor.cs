using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NetCore2Blockly
{
    /// <summary>
    /// 
    /// </summary>
    public class BlocklyStringToColor
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public static int ConvertToHue(string controllerName)
        {
            //Sum of characters beacuse the hashcode is changing
            var asciiArraySum = controllerName.ToCharArray()
                .Select(it => (int)it)
                .Sum();
            var rgbColor = (Color)new ColorConverter().ConvertFromString($"#{ToHexColor(controllerName.GetHashCode())}");
            //var x = ConvertFromHexToRgb(ToHexColor(asciiArraySum));
            //Console.WriteLine(x.b);
            return (int)rgbColor.GetHue(); //cast to int because we want the integer part
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

        private static (int r , int g, int b) ConvertFromHexToRgb(string hexColor)
        {
            int[] ret = new int[3];
            for(int i = 0; i < 3; i++)
            {
                ret[i] = HexToInt(hexColor.ElementAt(i * 2), hexColor.ElementAt(i * 2 + 1));
            }

            return (ret[0], ret[1], ret[2]);
        }

        private static int HexToInt(char a, char b)
        {
            int x = a < 65 ? a - 48 : a - 55;
            int y = b < 65 ? b - 48 : b - 55;
            return x * 16 + y;
        }
    }
}
