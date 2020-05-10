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

        public override Dictionary<string, long> GetValuesForEnum()
        {
            return new Dictionary<string, long>(){
                { $"TranslateToBlocklyBlocksType=>{id}",1 }
            };
        }

        public override string TranslateToBlocklyBlocksType()
        {
            return $"TranslateToBlocklyBlocksType=>{id}";
        }

        public override string TranslateToBlocklyType()
        {
            return "TranslateToBlocklyType=>" + this.id;
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
