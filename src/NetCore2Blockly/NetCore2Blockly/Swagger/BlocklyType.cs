using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NetCore2Blockly.Swagger
{
    [DebuggerDisplay("Blocky {id}")]
    class BlocklyType : TypeArgumentBase
    {
        public BlocklyType(string id) : base(id)
        {

        }

        public override string FullName => $"FullName=>{id}";

        public override bool IsEnum => false;

        public override string TypeNameForBlockly => $"TypeNameForBlockly=>{id}";

        public override bool IsValueType => true;

        internal static BlocklyType CreateValue(string format)
        {
            return new BlocklyType(format);
        }

        public override bool ConvertibleToBlocklyType()
        {
            return true;
        }

        public override PropertyBase[] GetProperties()
        {
            throw new System.NotImplementedException();
        }

        public override Dictionary<string, object> GetValuesForEnum()
        {
            return new Dictionary<string, object>(){
                { $"BlocklyType TranslateToBlocklyBlocksType=>{id}",1 }
            };
        }

        public override string TranslateToBlocklyBlocksType()
        {
            switch (id)
            {
                case "integer":
                        return "math_number";

                case "string":
                        return "text";

                case "bool"://TODO: add controller with boolean
                        return "logic_boolean";

                case "array": 
                        return "lists_create_with";

               

            }
            return $"TranslateToBlocklyBlocksType=>{id}";
        }

        public override string TranslateToBlocklyType()
        {
            return TranslateToNewTypeName();
        }

        public override string TranslateToNewTypeName()
        {
            var upperCaseFirst = id.First().ToString().ToUpper() + id.Substring(1);
            if (upperCaseFirst == "Integer")
                upperCaseFirst = "Number";
            return upperCaseFirst;
        }
    }
}
