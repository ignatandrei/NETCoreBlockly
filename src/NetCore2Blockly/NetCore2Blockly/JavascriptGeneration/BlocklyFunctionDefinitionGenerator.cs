using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    /// <summary>
    /// generates blockly functions
    /// </summary>
    public class BlocklyFunctionDefinitionGenerator
    {

        /// <summary>
        /// Generates the property definitions.
        /// </summary>
        /// <param name="actionInfo">The action information.</param>
        /// <returns></returns>
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
            if(actionInfo.ReturnType.id != null)
            tooltip += $" returns: {actionInfo.ReturnType.TranslateToBlocklyType()}";
            
            return strPropsDefinition + ";" + $" this.setTooltip('{tooltip}');";
        }


        /// <summary>
        /// Generates the function definition.
        /// blockly block definition for action
        /// </summary>
        /// <param name="actionInfo">The action information.</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public string GenerateFunctionDefinition(ActionInfo actionInfo,string key)
        {
            var strPropsDefinition = GeneratePropertyDefinitions(actionInfo);
            var returnType = "";
            if (actionInfo.ReturnType.id != null)
                returnType = $@"this.setOutput(true,'{actionInfo.ReturnType.TranslateToBlocklyType()}');";
            else
                returnType = $@"this.setOutput(true,'');";
            var actionHash  = actionInfo.CustomGetHashCode();

            var blockColor = BlocklyStringToColor.ConvertToHue(actionHash);
            return $@"
                Blockly.Blocks['{actionInfo.GenerateCommandName()}'] = {{
                          init: function() {{
                            this.setColour({blockColor});
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
