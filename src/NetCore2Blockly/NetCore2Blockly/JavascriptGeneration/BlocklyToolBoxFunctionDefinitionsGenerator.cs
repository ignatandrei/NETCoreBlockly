using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    public class BlocklyToolBoxFunctionDefinitionsGenerator
    {
        public string GenerateBlocklyToolBoxFunctionDefinitions(List<ActionInfo> actionList)
        {
            string blockText = "var blockTextLocalSiteFunctions='';";
            foreach (var actionsGroupedByController in actionList.GroupBy(it => it.ControllerName))
            {
                var controllerName = actionsGroupedByController.Key;
                blockText += $"blockTextLocalSiteFunctions += '<category name=\"{controllerName}\">';";
                foreach (var action in actionsGroupedByController)
                {
                    blockText += $@"{Environment.NewLine}
                        blockTextLocalSiteFunctions += '<block type=""{action.GenerateCommandName()}"">';";
                    if (action.HasParams)
                    {
                        foreach (var param in action.Params)
                        {
                            var type = param.Value.type;
                            var blocklyParameterName = param.Key;
                            if (type.ConvertibleToBlocklyType())
                            {


                                var blockShadowType = type.TranslateToBlocklyBlocksType();
                                blockText += $@"{Environment.NewLine}
                                                 blockTextLocalSiteFunctions += '<value name=""val_{blocklyParameterName}""><shadow type=""{blockShadowType}"">{GenerateBlockShadowField(blockShadowType)}</shadow></value>';  
                                              ";


                            }
                            else
                            {
                                var typeWithoutBlocklyType = actionList.GetAllTypesWithNullBlocklyType().FirstOrDefault(x => x == type);
                                if (typeWithoutBlocklyType != null)
                                {
                                    var blockShadowType = type.TranslateToNewTypeName();
                                    blockText += $@"{Environment.NewLine}
                                                    blockTextLocalSiteFunctions += '<value name=""val_{blocklyParameterName}""><shadow type=""{blockShadowType}""></shadow></value>';                                                    
                                                   ";


                                }

                            }
                        }
                    }

                    blockText += "blockTextLocalSiteFunctions += '</block>';";
                }
                blockText += $"blockTextLocalSiteFunctions+='</category>';";

            }

            return blockText;
        }

        public string GenerateBlockShadowField(string blockShadowType)
        {
            switch (blockShadowType)
            {
                case "math_number":
                    
                    return $@"<field name=""NUM"">0</field>";

                case "text":

                    return $@"<field name=""TEXT"">This is a text</field>";

                default:
                    return "";
            }
        }
    }
}
