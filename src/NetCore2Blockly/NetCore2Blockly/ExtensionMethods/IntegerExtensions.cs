using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Blockly.ExtensionMethods
{   
    /// <summary>
    /// 
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHex(this int value)
        {
            return value.ToString("X");
        }
    }
}
