using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace NetCore2Blockly.OData
{
    class TypeToGenerateOData : TypeArgumentBase
    {
        PropertyBaseOData[] properties;
        internal string baseType;
        public string[] Keys;
        internal static TypeToGenerateOData CreateFromEnumType(XElement et, XDocument data)
        {
            var name = et.Attribute(XName.Get("Name")).Value;
            var id = name;
            if (et.Parent?.Attribute("Namespace") != null)
                id = et.Parent.Attribute("Namespace").Value + "." + id;

            var t = new TypeToGenerateOData(id);
            t.properties=new PropertyBaseOData[0];
            t.Name = name;
            t.isEnum = true;
            t.enumValues = new Dictionary<string, object>(); 
            var props = new List<PropertyBaseOData>();
            foreach (var node in et.DescendantNodes())
            {
                if (!(node is XElement xe))
                    continue;

                
                var nameProps = xe.Attribute("Name").Value;
                var typeProps = xe.Attribute("Value").Value;
                t.enumValues.Add(nameProps, typeProps);
                
            }


            
            return t;

        }
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
        internal static TypeToGenerateOData CreateFromEntityType(XElement et, XDocument data)
        {
            var name = et.Attribute("Name").Value;
            var schema = et.Parent?.Attribute("Namespace")?.Value;
            if (!string.IsNullOrWhiteSpace(schema))
            {
                name = $"{schema}.{name}";
            }
            var t = new TypeToGenerateOData(name);
            t.Name = et.Attribute(XName.Get("Name")).Value;
            return AddPropsFromEntityType(t, et, data);

        }

        internal static TypeToGenerateOData CreateFromEntitySet(XElement et, XDocument data)
        {
            var t = new TypeToGenerateOData(et.Attribute(XName.Get("EntityType")).Value);
            t.Name = et.Attribute(XName.Get("Name")).Value;
            t.AddDefinitions.Add("@odata.type", t.id);

            string name = t.id.Split('.').Last();
            var els = data.Root.XPathSelectElement($"//*[local-name()='EntityType'][@Name='{name}']");
            //maybe verify namespace ?
            return AddPropsFromEntityType(t,els,data);
        }
        static TypeToGenerateOData AddPropsFromEntityType(TypeToGenerateOData t,XElement els,XDocument data) 
        {
            var props = new List<PropertyBaseOData>();

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
                var type = xe.Attributes().FirstOrDefault(it => it.Name == "Type");
                string typeProps = "";
                if (type != null)//v4
                {
                    typeProps = xe.Attribute("Type").Value;
                }
                else//v3
                {
                    var relationship = xe.Attribute("Relationship").Value;
                    var toRole = xe.Attribute("ToRole").Value;
                    var assoc = data
                        .Root
                        .XPathSelectElements($"//*[local-name()='Association'][@Name='{relationship}']")
                        .ToArray();
                    if(assoc.Length != 1)
                    {
                        relationship = relationship.Split('.',StringSplitOptions.RemoveEmptyEntries).Last();
                        assoc = data
                        .Root
                        .XPathSelectElements($"//*[local-name()='Association'][@Name='{relationship}']")
                        .ToArray();
                    }
                    var asociation = assoc.First();
                    foreach (var endrole in asociation.Descendants())
                    {
                        if (endrole.Attribute("Role")?.Value != toRole)
                            continue;

                        var mult = endrole.Attribute("Multiplicity").Value;
                        var toRoleObj = endrole.Attribute("Type").Value;
                        if (mult == "*")
                        {
                            typeProps = $"Collection({toRoleObj})";
                        }
                        else
                        {
                            typeProps = toRoleObj;
                        }
                    }
                }
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
        private bool isEnum=false;
        public override bool IsEnum {
            get
            {
                return isEnum;
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
        private Dictionary<string, object> enumValues;
        public override Dictionary<string, object> GetValuesForEnum()
        {
            return enumValues;
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
