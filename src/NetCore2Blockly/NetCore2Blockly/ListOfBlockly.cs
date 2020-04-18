using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NetCore2Blockly
{
    /// <summary>
    /// all blockly that should be generated
    /// </summary>
    /// 
    public class ListOfBlockly : List<BlocklyGenerator>
    {
        /// <summary>
        /// all types
        /// </summary>
        /// <returns></returns>
        private Tuple<Type, string>[] Types()
        {
            return this
                .Where(it => it.Params != null)
                .SelectMany(it => it.Params)
                .Select(it => it.Value.type)
                .Distinct()
                .Select(it => Tuple.Create(it, BlocklyTypeTranslator(it)))
                .ToArray();
        }
        internal static string BlocklyTypeBlocks(Type t)
        {
            if (t == typeof(int))
                return "math_number";

            if (t == typeof(string))
                return "text";
            if (t == typeof(bool))
                return "logic_boolean";

            if (typeof(IEnumerable).IsAssignableFrom(t))
                return "lists_create_with";
            //what to do with Array ?
            return null;
        }
        internal static  string BlocklyTypeTranslator(Type t)
        {
            if (t == typeof(int))
                return "Number";
                
            if (t == typeof(string))
                return "String";
            if (t == typeof(bool))
                return "Boolean";

            if (typeof(IEnumerable).IsAssignableFrom(t))
                return "Array";
            //what to do with Array ?
            return null;
        }
        internal Tuple<Type,string>[] TypesGenerateArray()
        {
            return this.Types()
                .Where(it => it.Item2 == null)
                .ToArray();
        }
        /// <summary>
        /// Generates types of Blockly
        /// </summary>
        /// <returns></returns>
        public string TypesToBeGenerated()
        {
            var types = this.TypesGenerateArray()                
                .Select(it => GenerateBlocklyFromType(it.Item1))
                .Select(it => it.descType)
                .ToArray();

            return string.Join(Environment.NewLine, types);
        }
        internal static  string nameType(Type t)
        {
            return BlocklyTypeTranslator(t) ?? t.FullName.Replace(".", "_");
        }
        
        /// <summary>
        /// Generates the blocks definition.
        /// </summary>
        /// <returns></returns>
        public string GenerateBlocksValueDefinition()
        {
            var globalVars = "var glbVar=function(workspace){";
            var types = this.Types()
                .Where(it => it.Item2 == null)
                .Select(it => it.Item1)
                .ToArray();
            string blockText = "";
            foreach (var type in types)
            {

                globalVars += $"workspace.createVariable('var_{type.Name}', '{nameType(type)}');";
                blockText += $@"{Environment.NewLine}
                
                var blockText_{type.Name} = '<block type=""{nameType(type)}"">';";
                foreach (var item in type.GetProperties())
                {
                    if (item.GetSetMethod() == null)
                        continue;
                    var typeProp = item.PropertyType;
                    var existing = ListOfBlockly.BlocklyTypeTranslator(typeProp);
                    if (existing == null)
                        continue;

                    var blockShadow = ListOfBlockly.BlocklyTypeBlocks(typeProp);
                    blockText += $@"{Environment.NewLine}
 var blockTextLocalSiteFunctions = '<value name=""val_{item.Name}"">';
blockTextLocalSiteFunctions += '<shadow type=""{blockShadow}"">';";
                    blockText += generateShadow(blockShadow);
                    blockText += $@"
 blockTextLocalSiteFunctions += '</shadow></value>';
 ";
                    blockText += $"blockText_{type.Name} += blockTextLocalSiteFunctions;";
                }
                blockText += $"blockText_{type.Name} += '</block>';";

                blockText += $@"block_{type.Name} = Blockly.Xml.textToDom(blockText_{type.Name});
                xmlList.push(block_{type.Name});";
                blockText += ";";

                blockText += $@"var block_{type.Name}Set='<block type=""variables_set""><field name=""VAR"">var_{type.Name}</field></block>';";
                blockText += $@"block_{type.Name}Set = Blockly.Xml.textToDom(block_{type.Name}Set);
                xmlList.push(block_{type.Name}Set);";
            }            
            var strDef = $@"
 var registerValues = function() {{
        var xmlList = [];
        {blockText}
                
return xmlList;
              }};  ";
            globalVars += "}";
            strDef += globalVars;
            return strDef;

        }
        private (string nameType, string descType) GenerateBlocklyFromType(Type t)
        {
            var item = BlocklyTypeTranslator(t);
            if (item != null)
                return (item, null);
            string tooltip = $"{t.Name} with props:";
            string propsDef = "";
            string prodCode = "";
            
            foreach (var prop in t.GetProperties())
            {
                if (prop.GetSetMethod() == null)
                    continue;
                tooltip += $"{prop.Name}: {nameType(prop.PropertyType)};";
                propsDef += $@"{Environment.NewLine}
                this.appendValueInput('val_{prop.Name}')
                        .setCheck('{nameType(prop.PropertyType)}')
                        .appendField('{prop.Name}')
                        ;";

                prodCode += $@"{Environment.NewLine}
                obj['{prop.Name}'] = Blockly.JavaScript.valueToCode(block, 'val_{prop.Name}', Blockly.JavaScript.ORDER_ATOMIC);
                ";


            }

            var prodCodeSimple =
                string.Join("\r\n", t.GetProperties().Select(prop =>

                 $"objPropString.push('\"{prop.Name}\":'+Blockly.JavaScript.valueToCode(block, \"val_{prop.Name}\", Blockly.JavaScript.ORDER_ATOMIC));"));
           
            var strDef = $@"
                    Blockly.Blocks['{nameType(t)}'] = {{
                    init: function() {{
                        this.appendDummyInput()
                            .appendField('{t.Name}');
                        {propsDef}
                        this.setTooltip('{tooltip}');
                        this.setOutput(true, '{nameType(t)}');
                            }}  
                    }};";

            strDef += $@"Blockly.Blocks['var_{nameType(t)}'] = {{
  init: function() {{
    this.setTooltip(' please open advanced / variables to add the variable');
    this.appendDummyInput()
      .appendField('variable:')
      .appendField(new Blockly.FieldVariable(
          'var_{t.Name}',
          '{nameType(t)}'
      ), 'FIELDNAME');
  }}
}};";

            var strJS = $@"
                Blockly.JavaScript['{nameType(t)}'] = function(block) {{
                var obj={{}};
                {prodCode}
                var code = JSON.stringify(obj);
                code =`(function(){{
                        var json = JSON.parse('${{code}}');
                var objNew = {{}};
                
                for (var key in json) {{
                    
                    objNew[key] = eval(json[key]);
                    
                }};
                
                  return  (objNew);}})()`;     
                   
               
                console.log(code);
                return [code, Blockly.JavaScript.ORDER_NONE];
                }};";

            strJS = $@"
                Blockly.JavaScript['{nameType(t)}'] = function(block) {{
                console.log(block);
                var objPropString=[];
                {prodCodeSimple}
                console.log(objPropString);
                var code ='{{ '+ objPropString.join(',') +' }}';
                console.log(code);
                return [code, Blockly.JavaScript.ORDER_NONE];
                }};";
            return (t.FullName, strDef + strJS);
        }
        /// <summary>
        /// Functions blocklyAPIFunctions to be generated.
        /// </summary>
        /// <returns></returns>
        public string FunctionsToBeGenerated()
        {
            var allDefs = "";
            foreach (var cmd in this)
            {
                allDefs +=Environment.NewLine+ cmd.FunctionDefinition();
                allDefs += Environment.NewLine + cmd.FunctionJSGenerator();
            }
            return allDefs;
        }
        private string generateShadow(string blockShadow)
        {
            switch (blockShadow)
            {
                case "math_number":
                    return $@"
                                    blockTextLocalSiteFunctions += '<field name=""NUM"">10</field>';
                                    ";
                    
                case "text":

                    return $@"
                                    blockTextLocalSiteFunctions += '';
                                    blockTextLocalSiteFunctions += '<field name=""TEXT"">abc</field>';
                                    ";
                    
                default:
                    return "";
            }
        }
        internal string GenerateBlocksFunctionsDefinition()
        {
            string blockText = "var blockTextLocalSiteFunctions='';";
            foreach (var cmdAll in this.GroupBy(it => it.ControllerName))
            {
                var key = cmdAll.Key;
                blockText += $"blockTextLocalSiteFunctions += '<category name=\"{key}\">';";
                foreach (var cmd in cmdAll)
                {
                    blockText += $@"{Environment.NewLine}
                        blockTextLocalSiteFunctions += '<block type=""{cmd.nameCommand()}"">';";
                    if(cmd.ExistsParams)
                    foreach(var param in cmd.Params)
                    {
                            var type = param.Value.type;
                        var existing = ListOfBlockly.BlocklyTypeTranslator(type);
                        if(existing == null)
                        {
                            var tuple = TypesGenerateArray().FirstOrDefault(it => it.Item1 == type);
                            if(tuple != null)
                            {
                                    var blockShadow = nameType(type);
                                    blockText += $@"{Environment.NewLine}
 blockTextLocalSiteFunctions += '<value name=""val_{param.Key}"">';
blockTextLocalSiteFunctions += '<shadow type=""{blockShadow}"">';";
                                    //blockText += generateShadow(blockShadow);
                                    blockText += $@"
 blockTextLocalSiteFunctions += '</shadow></value>';
 ";
                                }


                        }
                        if(existing != null)
                        {
                                var blockShadow = ListOfBlockly.BlocklyTypeBlocks(type);
                                blockText += $@"{Environment.NewLine}
 blockTextLocalSiteFunctions += '<value name=""val_{param.Key}"">';
blockTextLocalSiteFunctions += '<shadow type=""{blockShadow}"">';";
                                blockText += generateShadow(blockShadow);
                                blockText += $@"
 blockTextLocalSiteFunctions += '</shadow></value>';
 ";
                        }
                    }
                    blockText += "blockTextLocalSiteFunctions += '</block>';";
                }
                blockText+=$"blockTextLocalSiteFunctions+='</category>';";
                //blockText += $"blockText_{key} +='</category>';";
                //blockText += $"xmlList.push(Blockly.Xml.textToDom(blockText_{key}));";

            }
            //blockText += $"console.log(blockTextLocalSiteFunctions);";

            return blockText;

//            var strDef = $@"
// var registerFunctions = function() {{
//        var xmlList = [];
//        {blockText}
                
//return xmlList;
//              }}  ";
//            return strDef;

        }


    }
}
