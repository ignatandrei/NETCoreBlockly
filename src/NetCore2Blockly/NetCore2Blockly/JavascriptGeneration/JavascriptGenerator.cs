using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore2Blockly.JavascriptGeneration
{
    /// <summary>
    /// javascript generator for blockly
    /// </summary>
    public class JavascriptGenerator
    {

        BlocklyDefinitionGenerator _definitionGenerator = new BlocklyDefinitionGenerator();

        BlocklyFunctionDefinitionGenerator _functionDefinitionGenerator = new BlocklyFunctionDefinitionGenerator();

        BlocklyFunctionJSGenerator _functionJSGenerator = new BlocklyFunctionJSGenerator();

        BlocklyToolBoxFunctionDefinitionsGenerator _toolBoxFunctionDefinitionGenerator = new BlocklyToolBoxFunctionDefinitionsGenerator();

        BlocklyToolBoxJSGenerator _toolBoxJSGenerator = new BlocklyToolBoxJSGenerator();




        /// <summary>
        /// Generates the blockly definition.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public string  GenerateBlocklyDefinition(TypeArgumentBase type)
        {
            return _definitionGenerator.GenerateBlocklyDefinition(type);
        }

        /// <summary>
        /// Generates the blockly tool box value.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="key">site key</param>
        /// <returns></returns>
        public string GenerateBlocklyToolBoxValue(TypeArgumentBase[] types, string key="")
        {
            return _toolBoxJSGenerator.GenerateBlocklyToolBoxValue(types,key);
        }

        /// <summary>
        /// Generates the blockly tool box function definitions.
        /// </summary>
        /// <param name="actionList">The action list.</param>
        /// <param name="key">The action list.</param>
        /// <returns></returns>
        public string GenerateBlocklyToolBoxFunctionDefinitions(ActionInfo[] actionList,string key)
        {
            return _toolBoxFunctionDefinitionGenerator.GenerateBlocklyToolBoxFunctionDefinitions(actionList,key);
        }


        /// <summary>
        /// Generates the function js.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="key">site key</param>
        /// <returns></returns>
        public string GenerateFunctionJS(ActionInfo action,string key)
        {
            return _functionJSGenerator.GenerateFunctionJS(action,key);
        }

        /// <summary>
        /// Generates the function definition.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public string GenerateFunctionDefinition(ActionInfo action,string key="")
        {
            return _functionDefinitionGenerator.GenerateFunctionDefinition(action,key);
        }
    }
}
