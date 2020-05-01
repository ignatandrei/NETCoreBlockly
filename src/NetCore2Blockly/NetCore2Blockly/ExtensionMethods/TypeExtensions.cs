using System;
using System.Collections;
using System.Linq;

namespace NetCore2Blockly
{
    /// <summary>
    /// extension to generate blockly from type
    /// </summary>
    public static class TypeExtensions
    {


        /// <summary>
        /// Translates the type to blockly blocks.
        /// </summary>
        /// <param name="type">The t.</param>
        /// <returns></returns>
        internal static string TranslateToBlocklyBlocksType(this Type type)
        {
            var t = Nullable.GetUnderlyingType(type) ?? type;
            if (t == typeof(int))
                return "math_number";

            if (t == typeof(long))
                return "math_number";

            if (t == typeof(double))
                return "math_number";

            if (t == typeof(float))
                return "math_number";

            if (t == typeof(string))
                return "text";

            if (t == typeof(bool))
                return "logic_boolean";

            if (typeof(IEnumerable).IsAssignableFrom(t))
                return "lists_create_with";
            //what to do with Array ?

            return null;

        }

        /// <summary>
        /// Translates the type to blockly.
        /// </summary>
        /// <param name="type">The t.</param>
        /// <returns></returns>
        public static string TranslateToBlocklyType(this Type type)
        {
            var t = Nullable.GetUnderlyingType(type) ?? type;
            if (t == typeof(int))
                return "Number";
            if (t == typeof(long))
                return "Number";
            if (t == typeof(float))
                return "Number";

            if (t == typeof(double))
                return "Number";

            if (t == typeof(string))
                return "String";

            if (t == typeof(bool))
                return "Boolean";

            if (t == typeof(void))
                return "Boolean";

            if (typeof(IEnumerable).IsAssignableFrom(t))
                return "Array";

            return null;
            //what to do with Array ?
           
        }

        /// <summary>
        /// Translates type to new type, if necessary.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public static string TranslateToNewTypeName(this Type t)
        {
            return t.TranslateToBlocklyType() ?? t.FullName.Replace(".", "_");
        }

        /// <summary>
        /// see if the type is blockly default type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static bool ConvertibleToBlocklyType(this Type type)
        {
            return type.TranslateToBlocklyType() != null; 
        }

        
    }
}
