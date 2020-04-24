using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    public class BlocklyFunctionDefinitionGenerator
    {

        public string GeneratePropertyDefinitions(ActionInfo actionInfo)
        {
            string tooltip = $"{actionInfo.GenerateCommandName()} :";
            var strPropsDefinition = "";

            foreach (var param in actionInfo.Params)
            {
                var blocklyType = param.Value.type.TranslateToBlocklyType();
                var typeName = param.Key;

                strPropsDefinition += $@"
                    this.appendValueInput('val_{typeName}')
                    .setCheck('{blocklyType}')
                    .appendField('{typeName}'); ";

                tooltip += $"{typeName}: {blocklyType}";

            }
            tooltip += $" returns: {actionInfo.ReturnType.TranslateToBlocklyType()}";
            
            return strPropsDefinition + ";" + $" this.setTooltip('{tooltip}');";
        }

        // blockly block definition for action
        public string GenerateFunctionDefinition(ActionInfo actionInfo)
        {
            var strPropsDefinition = GeneratePropertyDefinitions(actionInfo);

            var returnType = $@"this.setOutput(true,'{actionInfo.ReturnType.TranslateToBlocklyType()}');";

            return $@"
                Blockly.Blocks['{actionInfo.GenerateCommandName()}'] = {{
                          init: function() {{
                            this.appendDummyInput()
                                .appendField('{actionInfo.CommandDisplayName()}');
                                {strPropsDefinition}
                                {returnType}
                                }}//init
                        }};//{actionInfo.ActionName}
                        ";
        }
    }
}
