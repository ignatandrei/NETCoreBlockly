using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore2Blockly.JavascriptGeneration
{
    public class JavascriptGenerator
    {

        BlocklyDefinitionGenerator _definitionGenerator = new BlocklyDefinitionGenerator();

        BlocklyFunctionDefinitionGenerator _functionDefinitionGenerator = new BlocklyFunctionDefinitionGenerator();

        BlocklyFunctionJSGenerator _functionJSGenerator = new BlocklyFunctionJSGenerator();

        BlocklyToolBoxFunctionDefinitionsGenerator _toolBoxFunctionDefinitionGenerator = new BlocklyToolBoxFunctionDefinitionsGenerator();

        BlocklyToolBoxJSGenerator _toolBoxJSGenerator = new BlocklyToolBoxJSGenerator();

        
        public JavascriptGenerator()
        {
           
        }

        public  string  GenerateBlocklyDefinition(Type type)
        {
            return _definitionGenerator.GenerateBlocklyDefinition(type);
        }

        public string GenerateBlocklyToolBoxValue(Type[] types)
        {
            return _toolBoxJSGenerator.GenerateBlocklyToolBoxValue(types);
        }

        public string GenerateBlocklyToolBoxFunctionDefinitions(List<ActionInfo> actionList)
        {
            return _toolBoxFunctionDefinitionGenerator.GenerateBlocklyToolBoxFunctionDefinitions(actionList);
        }
 

        public string GenerateFunctionJS(ActionInfo action)
        {
            return _functionJSGenerator.GenerateFunctionJS(action);
        }

        public string GenerateFunctionDefinition(ActionInfo action)
        {
            return _functionDefinitionGenerator.GenerateFunctionDefinition(action);
        }
    }
}
