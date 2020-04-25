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
        public string GenerateBlocklyDefinition(Type type)
        {

            if (type.ConvertibleToBlocklyType())
                return null;

            var strDef = GenerateDefinitionString(type);
            var strJS = GenerateJSstring(type);
            return strDef + strJS;
        }

        /// <summary>
        /// Generates the definition string.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public string GenerateDefinitionString(Type type)
        {
            if (type.IsEnum)
            {
                return GenerateDefinitionStringForEnum(type);
            }


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

        private string GenerateDefinitionStringForEnum(Type type)
        {
            if (!type.IsEnum)
                throw new ArgumentException($"type {type.Name} is not enum!");


            var names = Enum.GetNames(type);
            var opt = string.Join(",",
                names.Select(it => $"['{it}', '{ValueEnum(Enum.Parse(type, it))}']")
                );

            var def = $@"{Environment.NewLine}
 Blockly.Blocks['{type.TranslateToNewTypeName()}'] = {{
            init: function () {{
                this.appendDummyInput()
                    .appendField('{type.Name}')
                    .appendField(new Blockly.FieldDropdown([{opt}]), 'val_{type.Name}');
            this.setOutput(true, 'Number');

            this.setTooltip('Enumeration {type.Name}');
            //this.setHelpUrl('');
        }}
    }};                               
";
            return def;
            
        }

        private long ValueEnum(object o)
        {
            try
            {
                return (long)o;
            }
            catch 
            {

                return (int)o;
            }
            throw new ArgumentException("there is an enum that is not valid");
        }
        internal (string tooltip, string propsDef) GenerateTooltipAndPropDef(Type type)
        {
            string tooltip = $"{type.Name} with props:";
            string propsDef = "";
            
            var validProperties = type.GetProperties().Where(prop => prop.GetSetMethod() != null);
            
            

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
            var str = typeof(string).FullName;
            if (type.IsEnum)
            {
                return $@"
                Blockly.JavaScript['{type.TranslateToNewTypeName()}'] = function(block) {{

                    var dropdown_name = block.getFieldValue('val_{type.Name}');                    
                    code = dropdown_name;
                    return [code, Blockly.JavaScript.ORDER_ATOMIC];


                }}";
            };

            var arr = typeof(IEnumerable);
            var props = type.GetProperties()
                           .Select(prop => (prop, isArray:
                           (!prop.PropertyType.IsValueType)
                           &&
                           (prop.PropertyType.FullName != str)
                           &&
                           arr.IsAssignableFrom(prop.PropertyType)))
                        //.Select(it => (prop: it.prop, filter: (!it.isArray) ? "" : "+'.filter(it=>it !=null)'" ))
                        //TODO: previous line can filter empty arrays, e.g. post with empty elements
                        // however , raises an error in acorn. For the moment, not implemented
                        .Select(it => (prop: it.prop, filter: (!it.isArray) ? "" : ""))
                        .ToArray();

            
            var objectProperties =
               string.Join( Environment.NewLine, 
                           props
                           .Select(it =>
                           $"let val{it.prop.Name} = Blockly.JavaScript.valueToCode(block, \"val_{it.prop.Name}\", Blockly.JavaScript.ORDER_ATOMIC);"+
                           $"if(val{it.prop.Name} != ''){{" +
                           $"val{it.prop.Name} = val{it.prop.Name};"+
                           $"objPropString.push('\"{it.prop.Name}\":'+val{it.prop.Name}{it.filter});"+
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
