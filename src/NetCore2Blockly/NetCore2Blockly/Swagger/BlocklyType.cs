using System.Collections.Generic;
using System.Diagnostics;

namespace NetCore2Blockly.Swagger
{
    [DebuggerDisplay("Blocky {id}")]
    class BlocklyType : TypeArgumentBase
    {
        public BlocklyType(string id) : base(id)
        {

        }

        public override string FullName => throw new System.NotImplementedException();

        public override bool IsEnum => throw new System.NotImplementedException();

        public override string TypeNameForBlockly => throw new System.NotImplementedException();

        public override bool IsValueType => throw new System.NotImplementedException();

        internal static BlocklyType CreateValue(string format)
        {
            return new BlocklyType(format);
        }

        public override bool ConvertibleToBlocklyType()
        {
            throw new System.NotImplementedException();
        }

        public override PropertyBase[] GetProperties()
        {
            throw new System.NotImplementedException();
        }

        public override Dictionary<string, long> GetValuesForEnum()
        {
            throw new System.NotImplementedException();
        }

        public override string TranslateToBlocklyBlocksType()
        {
            throw new System.NotImplementedException();
        }

        public override string TranslateToBlocklyType()
        {
            return "this is a TranslateToBlocklyType :" + this.id;
        }

        public override string TranslateToNewTypeName()
        {
            throw new System.NotImplementedException();
        }
    }
}
