using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace NetCore2Blockly.OData
{
    class PropertyBaseOData : PropertyBase
    {
        private readonly string typeOdata;

        public PropertyBaseOData(string name, string typeOdata):base()
        {
            this.Name = name;
            this.typeOdata = typeOdata;
        }
        public override bool IsArray => false;

        
    }
    class TypeToGenerateOData : TypeArgumentBase
    {
        PropertyBaseOData[] properties;
        public TypeToGenerateOData(XElement et, XDocument data):base(et.Attribute(XName.Get("EntityType")).Value)
        {
            Name = et.Attribute(XName.Get("Name")).Value;

            var props = new List<PropertyBaseOData>();
            string name = id.Split('.').Last();
            var els= data.Root.XPathSelectElement($"//*[local-name()='EntityType'][@Name='{name}']");
            //maybe verify namespace ?
            foreach(var node in els.DescendantNodes())
            {
                if (!(node is XElement xe))
                    continue;

                var nameProp = xe.Name.LocalName;
                if (!(nameProp == "Property" || nameProp == "NavigationProperty"))
                    continue;

                var nameProps = xe.Attribute("Name").Value;
                var typeProps = xe.Attribute("Type").Value;
                var prop = new PropertyBaseOData(nameProp, typeProps);
                props.Add(prop);
            }
            

            properties = props.ToArray();
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
