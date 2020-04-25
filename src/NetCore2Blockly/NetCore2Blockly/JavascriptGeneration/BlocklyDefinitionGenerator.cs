using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    /// <summary>
    /// generates blockly definition for a type
    /// </summary>
    public class BlocklyDefinitionGenerator
    {
        /// <summary>
        /// Generates the blockly definition.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public string  GenerateBlocklyDefinition(Type type)
        {

            if (type.ConvertibleToBlocklyType())
                return  null;

            var strDef = GenerateDefinitionString(type);
            var strJS = GenerateJSstring(type);

            return  strDef + strJS;
        }

        /// <summary>
        /// Generates the definition string.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
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

        internal (string tooltip, string propsDef) GenerateTooltipAndPropDef(Type type)
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

        /// <summary>
        /// Generates the javascript string.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public string GenerateJSstring(Type type)
        {
            bool isArray = type.IsSubclassOf(typeof(IEnumerable));
            string filterNull = (isArray) ? ".filter(it=>it !=null)" : "";
            var objectProperties =
               string.Join( Environment.NewLine, 
                           type.GetProperties().Select(prop =>
                           $"let val{prop.Name} = Blockly.JavaScript.valueToCode(block, \"val_{prop.Name}\", Blockly.JavaScript.ORDER_ATOMIC);"+
                           $"if(val{prop.Name} != ''){{" +
                           $"val{prop.Name} = val{prop.Name}.filter(it=>it != null);"+
                           $"objPropString.push('\"{prop.Name}\":'+val{prop.Name});"+
                           $"}}")
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
