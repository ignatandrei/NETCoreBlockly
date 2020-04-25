﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    public class BlocklyDefinitionGenerator
    {
        public  string  GenerateBlocklyDefinition(Type type)
        {

            if (type.ConvertibleToBlocklyType())
                return  null;

            var strDef = GenerateDefinitionString(type);
            var strJS = GenerateJSstring(type);

            return  strDef + strJS;
        }

        public string GenerateDefinitionString(Type type)
        {
            var tooltipAndpropsDef = GenerateTooltipAndPropDef(type);
            var blocklyTypeName = type.TranslateToNewTypeName();
            var typeName = type.Name;

            var definitionString = $@"
                                Blockly.Blocks['{blocklyTypeName}'] = {{
                                init: function() {{
                                    this.appendDummyInput()
                                        .appendField('{typeName}');
                                    {tooltipAndpropsDef.propsDef}
                                    this.setTooltip('{tooltipAndpropsDef.tooltip}');
                        
                                    this.setOutput(true, '{blocklyTypeName}');
                                        }}  
                                }};

                                Blockly.Blocks['var_{blocklyTypeName}'] = {{
                                                          init: function() {{
                                                            this.setTooltip('{type.FullName}');
                                                            this.appendDummyInput()
                                                              .appendField('variable:')
                                                              .appendField(new Blockly.FieldVariable(
                                                                  'var_{typeName}',
                                                                  '{blocklyTypeName}'
                                                              ), 'FIELDNAME');
                                                          }}
                                                        }};
                             ";
            return definitionString;
        }

        public (string tooltip, string propsDef) GenerateTooltipAndPropDef(Type type)
        {
            var validProperties = type.GetProperties().Where(prop => prop.GetSetMethod() != null);
            
            string tooltip = $"{type.Name} with props:";
            string propsDef = "";

            foreach (var property in validProperties)
            {

                tooltip += $"{property.Name}: {property.PropertyType.TranslateToNewTypeName()};";
                propsDef += $@"{Environment.NewLine}
                                this.appendValueInput('val_{property.Name}')
                                        .setCheck('{property.PropertyType.TranslateToNewTypeName()}')
                                        .appendField('{property.Name}')
                                        ;
                              ";

            }

            return (tooltip, propsDef);
        }

        public string GenerateJSstring(Type type)
        {
            var objectProperties =
               string.Join( Environment.NewLine, 
                           type.GetProperties().Select(prop =>

                           $"objPropString.push('\"{prop.Name}\":'+Blockly.JavaScript.valueToCode(block, \"val_{prop.Name}\", Blockly.JavaScript.ORDER_ATOMIC));")
               );

            var strJS = $@" Blockly.JavaScript['{type.TranslateToNewTypeName()}'] = function(block) {{
                            console.log(block);
                            var objPropString=[];
                            {objectProperties}
                            console.log(objPropString);
                            var code ='{{ '+ objPropString.join(',') +' }}';
                            console.log(code);
                            return [code, Blockly.JavaScript.ORDER_NONE];
                            }};";

            return strJS;
        }
    }
}