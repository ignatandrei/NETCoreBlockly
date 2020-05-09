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
        public string  GenerateBlocklyDefinition(Type type)
        {
            return _definitionGenerator.GenerateBlocklyDefinition(type);
        }

        /// <summary>
        /// Generates the blockly tool box value.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public string GenerateBlocklyToolBoxValue(Type[] types)
        {
            return _toolBoxJSGenerator.GenerateBlocklyToolBoxValue(types);
        }

        /// <summary>
        /// Generates the blockly tool box function definitions.
        /// </summary>
        /// <param name="actionList">The action list.</param>
        /// <returns></returns>
        public string GenerateBlocklyToolBoxFunctionDefinitions(List<IActionInfo> actionList)
        {
            return _toolBoxFunctionDefinitionGenerator.GenerateBlocklyToolBoxFunctionDefinitions(actionList);
        }


        /// <summary>
        /// Generates the function js.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public string GenerateFunctionJS(IActionInfo action)
        {
            return _functionJSGenerator.GenerateFunctionJS(action);
        }

        /// <summary>
        /// Generates the function definition.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public string GenerateFunctionDefinition(IActionInfo action)
        {
            return _functionDefinitionGenerator.GenerateFunctionDefinition(action);
        }
    }
}
