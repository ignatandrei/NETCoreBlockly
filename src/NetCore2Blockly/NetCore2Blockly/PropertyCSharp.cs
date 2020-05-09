using System.Collections;

namespace NetCore2Blockly
{
    class PropertyCSharp : PropertyBase
    {
        public override bool IsArray
        {
            get
            {
                var str = typeof(string).FullName;
                var arr = typeof(IEnumerable);
                return (!PropertyType.IsValueType)
                         &&
                         (PropertyType.FullName != str)
                         &&
                         arr.IsAssignableFrom((PropertyType as TypeToGenerateFromCSharp).t);
            }
        }
    }

}