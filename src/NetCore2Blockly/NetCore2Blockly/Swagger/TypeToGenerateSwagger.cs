using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace NetCore2Blockly.Swagger
{
    class TypeToGenerateSwagger : TypeArgumentBase
    {

        private bool _isEnum;
        Dictionary<string, object> enumValues;
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
            this._isEnum = schema.Value.Enum?.Count > 0;
            if (_isEnum)
            {
                enumValues = new Dictionary<string, object>();
                foreach(var item in schema.Value.Enum)
                {
                    if(item.AnyType == AnyType.Primitive)
                    {
                        if(item is OpenApiInteger intg)
                        {
                            enumValues.Add($"{Name}_{intg.Value}", intg.Value);
                        }
                        if (item is OpenApiLong lng)
                        {
                            enumValues.Add($"{Name}_{lng.Value}", lng.Value);
                        }
                        if(item is OpenApiString str)
                        {
                            enumValues.Add($"{Name}_{str.Value}", str.Value);
                        }
                        //TODO: enumerate other types here...
                    }
                    
                }
            }


        }
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
        internal static string Prefix(string site)
        {
            {
                return site
                    .Replace("http://", "")
                    .Replace("https://", "")
                    .Replace(".", "_")
                    .Replace("/", "");
            }
        }

        public override string FullName =>  $"{Site} ; {Name} ";

        public override bool IsEnum
        {
            get
            {
                return _isEnum;
            }
        }

        public override string TypeNameForBlockly
        {
            get
            {
                return $"{Prefix(Site)}_{Name}";
            }
        }

        public override bool IsValueType => false;

   
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
            return $"TranslateToBlocklyBlocksType ; {id}";
        }

        public override string TranslateToNewTypeName()
        {
            return $"{Prefix(Site)}_{Name}";
        }

        public override PropertyBase[] GetProperties()
        {
            return this.properties;
        }

        public override Dictionary<string, object> GetValuesForEnum()
        {
            return enumValues;

        }
    }
}
