using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace NetCore2Blockly.Swagger
{
    class TypeToGenerateSwagger : TypeArgumentBase
    {


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
                p.PropertyType = null;//TODO: find WHAT!! prop.Value.Type;
                l.Add(p);
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
        //        public string GenerateBlocksValueDefinition()
        //        {
        //            var type = this;
        //            var globalVars = $"workspace.createVariable('var_{type.Name}', '{nameType(type.Name)}');";
        //            var blockText = $@"{Environment.NewLine}

        //                var blockText_{type.Name} = '<block type=""{nameType(type.Name)}"">';";
        //            blockText += $"blockText_{type.Name} += '</block>';";
        //            blockText += $@"block_{type.Name} = Blockly.Xml.textToDom(blockText_{type.Name});
        //                xmlList.push(block_{type.Name});";
        //            blockText += ";";

        //            blockText += $@"var block_{type.Name}Set='<block type=""variables_set""><field name=""VAR"">var_{type.Name}</field></block>';";
        //            blockText += $@"block_{type.Name}Set = Blockly.Xml.textToDom(block_{type.Name}Set);
        //                xmlList.push(block_{type.Name}Set);";

        //            var strDef = $@"
        // var registerValues = function() {{
        //        var xmlList = [];
        //        {blockText}

        //return xmlList;
        //              }};  ";
        //            globalVars += "}";
        //            strDef += globalVars;
        //            return strDef;


        //        }
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

        public override bool IsEnum => throw new NotImplementedException();

        public override string TypeNameForBlockly => throw new NotImplementedException();

        public override bool IsValueType => throw new NotImplementedException();

        //        public string GenerateBlocklyFromType()
        //        {
        //            var name = BSHelpers.BlocklyTypeTranslator(this.Type);
        //            if (name != null)
        //                return null;
        //            name = Prefix + "_" + name;
        //            var t = this;
        //            string tooltip = $"{t.Name} with props:";
        //            string propsDef = "";
        //            string prodCode = "";

        //            foreach (var prop in t.Properties)
        //            {
        //                tooltip += $"{prop.Name}: {Prefix} {nameType(prop.Type)};";
        //                propsDef += $@"{Environment.NewLine}
        //                this.appendValueInput('val_{prop.Name}')
        //                        .setCheck('{nameType(prop.Type)}')
        //                        .appendField('{prop.Name}')
        //                        ;";

        //                prodCode += $@"{Environment.NewLine}
        //                obj['{prop.Name}'] = Blockly.JavaScript.valueToCode(block, 'val_{prop.Name}', Blockly.JavaScript.ORDER_ATOMIC);
        //                ";


        //            }

        //            var prodCodeSimple =
        //                string.Join("\r\n", t.Properties.Select(prop =>

        //                 $"objPropString.push('\"{prop.Name}\":'+Blockly.JavaScript.valueToCode(block, \"val_{prop.Name}\", Blockly.JavaScript.ORDER_ATOMIC));"));

        //            var strDef = $@"{Environment.NewLine}
        //                    Blockly.Blocks['{Prefix}_{nameType(t.Name)}'] = {{
        //                    init: function() {{
        //                        this.appendDummyInput()
        //                            .appendField('{t.Name}');
        //                        {propsDef}
        //                        this.setTooltip('{tooltip}');
        //                        this.setOutput(true, '{nameType(t.Name)}');
        //                            }}  
        //                    }};";

        //            strDef += $@"{Environment.NewLine}
        //    Blockly.Blocks['var_{Prefix}_{nameType(t.Name)}'] = {{
        //  init: function() {{
        //    this.setTooltip('{t.Name}');
        //    this.appendDummyInput()
        //      .appendField('variable:')
        //      .appendField(new Blockly.FieldVariable(
        //          'var_{t.Name}',
        //          '{nameType(t.Name)}'
        //      ), 'FIELDNAME');
        //  }}
        //}};";

        //            var strJS = $@"
        //                Blockly.JavaScript['{Prefix}_{nameType(t.Name)}'] = function(block) {{
        //                var obj={{}};
        //                {prodCode}
        //                var code = JSON.stringify(obj);
        //                code =`(function(){{
        //                        var json = JSON.parse('${{code}}');
        //                var objNew = {{}};

        //                for (var key in json) {{

        //                    objNew[key] = eval(json[key]);

        //                }};

        //                  return  (objNew);}})()`;     


        //                console.log(code);
        //                return [code, Blockly.JavaScript.ORDER_NONE];
        //                }};";

        //            strJS = $@"
        //                Blockly.JavaScript['{Prefix}_{nameType(t.Name)}'] = function(block) {{
        //                console.log(block);
        //                var objPropString=[];
        //                {prodCodeSimple}
        //                console.log(objPropString);
        //                var code ='{{ '+ objPropString.join(',') +' }}';
        //                console.log(code);
        //                return [code, Blockly.JavaScript.ORDER_NONE];
        //                }};";
        //            return strDef + strJS;

        //        }

        public override string TranslateToBlocklyType()
        {
            throw new NotImplementedException();
        }

        public override bool ConvertibleToBlocklyType()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override Dictionary<string, long> GetValuesForEnum()
        {
            throw new NotImplementedException();
        }
    }
}
