using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;



namespace NetCore2Blockly.GraphQL
{
    public class GraphQLTypeArgument : TypeArgumentBase
    {
        public GraphQLTypeArgument(string id) : base(id)
        {
            
        }

        /// <summary>
        /// Gets the OGT name. ie DepartmentOGT
        /// </summary>
        public override string FullName => id;

        public override bool IsEnum => false;

        public override string TypeNameForBlockly => FullName;

        public override bool IsValueType => false;

        public override bool ConvertibleToBlocklyType()
        {
            return false;
        }

        public override PropertyBase[] GetProperties()
        {
            return null;
        }

        public override Dictionary<string, object> GetValuesForEnum()
        {
            throw new NotImplementedException();
        }

        public override string TranslateToBlocklyBlocksType()
        {
            throw new NotImplementedException();
        }

        public override string TranslateToBlocklyType()
        {
            throw new NotImplementedException();
        }

        public override string TranslateToNewTypeName()
        {
            throw new NotImplementedException();
        }
    }
}
