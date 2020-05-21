using System.Collections.Generic;

namespace NetCore2Blockly.OData
{
    class BlocklyTypeOdata : TypeArgumentBase
    {
        public BlocklyTypeOdata(string id) : base(id)
        {

        }

        public override string FullName => $"FullName=>{id}";

        public override bool IsEnum => false;

        public override string TypeNameForBlockly => $"TypeNameForBlockly=>{id}";

        public override bool IsValueType => true;

        internal static BlocklyTypeOdata CreateValue(string format)
        {
            return new BlocklyTypeOdata(format);
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
                { $"BlocklyType TranslateToBlocklyBlocksTypeOdata=>{id}",1 }
            };
        }

        public override string TranslateToBlocklyBlocksType()
        {
            switch (id?.ToLower())
            {
                case "edm.double":
                case "edm.int32":
                case "edm.int16":
                case "edm.int64":
                case "edm.byte":
                    return "math_number";

                case "edm.string":
                case "edm.guid":
                case "edm.datetimeoffset":
                case "edm.datetime":
                case "edm.stream":
                case "edm.geographypoint":
                    return "text";

                case "edm.boolean":
                    return "logic_boolean";

                case "array":
                    return "lists_create_with";



            }
            if(id?.StartsWith("Collection(")??false)
                return "lists_create_with";

            return $"TranslateToBlocklyBlocksTypeOdata=>{id}";
        }

        public override string TranslateToBlocklyType()
        {
            if (id == null)
                return null;
            return TranslateToNewTypeName();
        }

        public override string TranslateToNewTypeName()
        {
            switch (id?.ToLower())
            {
                case "edm.double":
                case "edm.int32":
                case "edm.int16":
                case "edm.int64":
                case "edm.byte":
                
                    return "Number";

                case "edm.string":
                case "edm.guid":
                case "edm.datetimeoffset":
                case "edm.stream":
                case "edm.datetime":
                case "edm.geographypoint":
                    return "String";

                case "edm.boolean":
                    return "Boolean";

                case "array":
                    return "Array";



            }
            if (id?.StartsWith("Collection(") ?? false)
                return "Array";

            return null;
        }
    }
}
