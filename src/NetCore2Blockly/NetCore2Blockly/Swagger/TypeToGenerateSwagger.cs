using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace NetCore2Blockly.Swagger
{
    class TypeToGenerateSwagger : TypeArgumentBase
    {

        private bool _isEnum;
        PropertyBaseSwagger[] properties;
        public TypeToGenerateSwagger(KeyValuePair<string, OpenApiSchema> schema) : base(schema.Value.Reference.ReferenceV2 + "_" + schema.Value.Reference.ReferenceV3)
        {
            Name = schema.Key;
            Type = schema.Value.Type;
            var l = new List<PropertyBaseSwagger>();
            foreach (var prop in schema.Value.Properties)
            {
                var p = new PropertyBaseSwagger();
                p.Name = prop.Key;
                p.propertyTypeSchema = prop.Value;
                p.PropertyType = null;
                l.Add(p);
                _isEnum = (schema.Value.Enum?.Count >0);                    
            }
            l.Sort((x, y) => x.Name.CompareTo(y.Name));
            properties = l.ToArray();


        }
        public string Site { get; set; }
        public string Type { get; internal set; }
        internal static string nameType(string t)
        {
            if (t == "integer")
                return "Number";

            if (t == "string")
                return "String";

            if (t == "boolean")
                return "Boolean";

            if (t == "array")
                return "Array";

            return null;
        }
        string Prefix
        {
            get
            {
                return this.Site
                    .Replace("http://", "")
                    .Replace("https://", "")
                    .Replace(".", "_")
                    .Replace("/", "");
            }
        }

        public override string FullName => throw new NotImplementedException();

        public override bool IsEnum
        {
            get
            {
                return _isEnum;
            }
        }

        public override string TypeNameForBlockly => throw new NotImplementedException();

        public override bool IsValueType => throw new NotImplementedException();

   
        public override string TranslateToBlocklyType()
        {
            return null;
        }

        public override bool ConvertibleToBlocklyType()
        {
            return false;
        }

        public override string TranslateToBlocklyBlocksType()
        {
            throw new NotImplementedException();
        }

        public override string TranslateToNewTypeName()
        {
            throw new NotImplementedException();
        }

        public override PropertyBase[] GetProperties()
        {
            return this.properties;
        }

        public override Dictionary<string, long> GetValuesForEnum()
        {
            throw new NotImplementedException();
        }
    }
}
