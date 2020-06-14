using NetCore2Blockly.Swagger;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;

namespace NetCore2Blockly.GraphQL
{
    class GraphQLTypeArgument : TypeArgumentBase
    {
        private JsonElement it;
        private PropertyBase[] properties;

        public GraphQLTypeArgument(JsonElement it):base(it.GetProperty("name").GetString())
        {
            List<PropertyBase> props = new List<PropertyBase>();
            this.it = it;
            var fields = it.GetProperty("fields");
            var l=fields.GetArrayLength();
            for(var i = 0; i < l; i++)
            {
                var current = fields[i];
                var prop = new GraphQLPropertyBase();
                prop.Name = current.GetProperty("name").GetString();
                //put here real name
                prop.PropertyType = BlocklyType.CreateValue(null);

                props.Add(prop);
            }
            properties = props.ToArray();
        }

        /// <summary>
        /// Gets the OGT name. ie DepartmentOGT
        /// </summary>
        public override string FullName => it.GetProperty("name").GetString();

        public override bool IsEnum => false;

        public override string TypeNameForBlockly => FullName;

        public override bool IsValueType => false;

        public override bool ConvertibleToBlocklyType()
        {
            return false;
        }

        public override PropertyBase[] GetProperties()
        {
            return properties;
        }

        public override Dictionary<string, object> GetValuesForEnum()
        {
            throw new NotImplementedException();
        }

        public override string TranslateToBlocklyBlocksType()
        {
            return $"TranslateToBlocklyBlocksType=>{id}";
        }

        public override string TranslateToBlocklyType()
        {
            return $"TranslateToBlocklyType=>{id}";
        }

        public override string TranslateToNewTypeName()
        {
            return $"TranslateToNewTypeName=>{id}";
        }
    }
}
