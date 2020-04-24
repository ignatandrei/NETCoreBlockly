using System;
using System.Collections;
using System.Linq;

namespace NetCore2Blockly
{
    public static class TypeExtensions
    {

    
        internal static string TranslateToBlocklyBlocksType(this Type t)
        {
            if (t == typeof(int))
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

        public static string TranslateToBlocklyType(this Type t)
        {
            if (t == typeof(int))
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

        public static string TranslateToNewTypeName(this Type t)
        {
            return t.TranslateToBlocklyType() ?? t.FullName.Replace(".", "_");
        }

        public static bool ConvertibleToBlocklyType(this Type type)
        {
            return type.TranslateToBlocklyType() != null; 
        }

        
    }
}
