using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

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
                case "edm.int64":
                    return "math_number";

                case "edm.string":
                case "edm.guid":
                case "edm.datetimeoffset":
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
            var upperCaseFirst = id.First().ToString().ToUpper() + id.Substring(1);
            if (upperCaseFirst == "Integer")
                upperCaseFirst = "Number";
            return upperCaseFirst;
        }
    }
    class PropertyBaseOData : PropertyBase
    {
        internal readonly string typeOdata;

        public PropertyBaseOData(string name, string typeOdata):base()
        {
            this.Name = name;
            this.typeOdata = typeOdata;
        }
        public override bool IsArray => false;

        
    }
    class ListTypeToGenerateOData: List<TypeArgumentBase>
    {
        internal TypeArgumentBase FindAfterId(string id)
        {
            var ret= this.FirstOrDefault(it => it.id == id);
            if(ret == null)
            {
                ret = BlocklyTypeOdata.CreateValue(id);
                this.Add(ret);
            }
            return ret;
        }
    }
    class TypeToGenerateOData : TypeArgumentBase
    {
        PropertyBaseOData[] properties;
        internal string baseType;
        public string[] Keys;
        internal static TypeToGenerateOData CreateFromComplexType(XElement et, XDocument data)
        {
            var name = et.Attribute(XName.Get("Name")).Value;
            var id =  name;
            if(et.Parent?.Attribute("Namespace") != null)
                id= et.Parent.Attribute("Namespace").Value + "."+id;
            
            var t = new TypeToGenerateOData(id);
            t.Name = name;
            //see base type for more properties
            if(et.Attributes().Count(it=>it.Name == "BaseType")>0)
            {
                t.baseType = et.Attribute("BaseType").Value;
            }
            var props = new List<PropertyBaseOData>();
            foreach (var node in et.DescendantNodes())
            {
                if (!(node is XElement xe))
                    continue;

                var localNameProp = xe.Name.LocalName;
                if (!(localNameProp == "Property" || localNameProp == "NavigationProperty"))
                    continue;

                var nameProps = xe.Attribute("Name").Value;
                var typeProps = xe.Attribute("Type").Value;
                var prop = new PropertyBaseOData(nameProps, typeProps);
                props.Add(prop);
            }


            t.properties = props.ToArray();
            return t;

        }

        internal static TypeToGenerateOData CreateFromEntitySet(XElement et, XDocument data)
        {
            var t = new TypeToGenerateOData(et.Attribute(XName.Get("EntityType")).Value);
            t.Name = et.Attribute(XName.Get("Name")).Value;

            var props = new List<PropertyBaseOData>();
            string name = t.id.Split('.').Last();
            var els = data.Root.XPathSelectElement($"//*[local-name()='EntityType'][@Name='{name}']");
            //maybe verify namespace ?
            foreach (var node in els.DescendantNodes())
            {

                if (!(node is XElement xe))
                    continue;

                var localNameProp = xe.Name.LocalName;
                if(localNameProp == "Key")
                {
                    t.Keys = xe.DescendantNodes()
                        .ToArray()
                        .Where(it => it is XElement)
                        .Select(it => it as XElement)
                        .Select(it => it.Attribute("Name").Value)
                        .ToArray();
                        ;
                    continue;
                }

                if (!(localNameProp == "Property" || localNameProp == "NavigationProperty"))
                    continue;

                var nameProps = xe.Attribute("Name").Value;
                var typeProps = xe.Attribute("Type").Value;
                var prop = new PropertyBaseOData(nameProps, typeProps);
                props.Add(prop);
            }


            t.properties = props.ToArray();
            return t;
        }
        TypeToGenerateOData(string id):base(id)
        {
            
        }

        public override string FullName  => id;

        public override bool IsEnum {
            get
            {
                return false;
            }
        }
        public override string TypeNameForBlockly
        {
            get
            {
                return id.Replace(".", "_");
            }
        }

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
            return $"TranslateToBlocklyBlocksTypeODATA ; {id}";
        }

        public override string TranslateToBlocklyType()
        {
            return null;
        }

        public override string TranslateToNewTypeName()
        {
            return FullName;
        }
    }
}
