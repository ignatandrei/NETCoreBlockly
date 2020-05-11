using NetCore2Blockly.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    /// <summary>
    /// generates js for seeing blocks in toolbox
    /// </summary>
    public class BlocklyToolBoxJSGenerator
    {

        /// <summary>
        /// Generates the blockly tool box value.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="key">site key.</param>
        /// <returns></returns>
        public string GenerateBlocklyToolBoxValue(TypeArgumentBase[] types,string key="")
        {
            string blockText = "";
            var globalVars = $"var glbVar{key}=function(workspace){{";
            var sort = types.OrderBy(it => it.Name).ToArray();
            
            foreach (var type in sort)
            {
                
                var typeName = type.TypeNameForBlockly;
                var newTypeName = type.TranslateToNewTypeName(); 

                globalVars += $"workspace.createVariable('var_{typeName}', '{newTypeName}');";
                blockText += $@"{Environment.NewLine}
                                var blockText_{typeName} = '<block type=""{newTypeName}"">';
                              ";
                blockText = GenerateToolBoxCodeForAllPropertiesOfAType(blockText, type);


                blockText += $@"{Environment.NewLine}blockText_{typeName} += '</block>';{Environment.NewLine}
                                var block_{typeName} = Blockly.Xml.textToDom(blockText_{typeName});
                                xmlList.push(block_{typeName});
                                var block_{typeName}Set='<block type=""variables_set""><field name=""VAR"">var_{typeName}</field></block>';
                                block_{typeName}Set = Blockly.Xml.textToDom(block_{typeName}Set);
                                xmlList.push(block_{typeName}Set);
                                ";

            }

            var strDef = $@"
                         var registerValues{key} = function() {{
                                var xmlList = [];
                                {blockText}
                
                        return xmlList;
              }};  ";

            globalVars += "}";
            strDef += globalVars;
            return strDef;

        }

        /// <summary>
        /// Generates tool box code for all properties of a type.
        /// </summary>
        /// <param name="blockText">The block text.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public string GenerateToolBoxCodeForAllPropertiesOfAType(string blockText, TypeArgumentBase type)
        {
            var validProperties = type.GetProperties();

            foreach (var property in type.GetProperties())
            {
                var propertyType = property.PropertyType;
                if (!propertyType.ConvertibleToBlocklyType())
                    continue;

                var typeName = type.TypeNameForBlockly;

                blockText += createBlockShadowDef(property.Name, propertyType.TranslateToBlocklyBlocksType());

                blockText += $"blockText_{typeName} += blockTextLocalSiteFunctions;";
            }

            return blockText;
        }

        string createBlockShadowDef(string name, string blockShadowType)
        {
            return $@"{Environment.NewLine}
                      var blockTextLocalSiteFunctions = '<value name=""val_{name}""><shadow type=""{blockShadowType}""></shadow></value>';
                      ";


        }

    }
}
