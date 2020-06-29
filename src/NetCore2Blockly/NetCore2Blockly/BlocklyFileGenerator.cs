using NetCore2Blockly.JavascriptGeneration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore2Blockly
{
    /// <summary>
    /// all blockly that should be generated
    /// </summary>
    /// 
    public class BlocklyFileGenerator 
    {
        JavascriptGenerator _jsGenerator;
        internal List<ActionInfo> _actionList;


        /// <summary>
        /// Initializes a new instance of the <see cref="BlocklyFileGenerator"/> class.
        /// </summary>
        /// <param name="actionList">The action list.</param>
        public BlocklyFileGenerator(List<ActionInfo> actionList)
        {
            _jsGenerator = new JavascriptGenerator();
            _actionList = actionList;
        }
       
        /// <summary>
        /// Generates types of Blockly
        /// </summary>
        /// <returns></returns>
        public string GenerateNewBlocklyTypesDefinition()
        {
            var newBlocklyTypes = _actionList.GetAllTypesWithNullBlocklyType()                
                .Select(x => _jsGenerator.GenerateBlocklyDefinition(x))
                .ToArray();

            var blocklyTypeDefinitions = string.Join(Environment.NewLine, newBlocklyTypes);

            return blocklyTypeDefinitions;
        }
       
        
        /// <summary>
        /// Generates the blocks definition.
        /// </summary>
        /// <returns></returns>
        public string GenerateBlocklyToolBoxValueDefinitionFile(string key="")
        {
            
            var types = _actionList.GetAllTypesWithNullBlocklyType()
                               
                .ToArray();
            var blocklyToolboxValue =  _jsGenerator.GenerateBlocklyToolBoxValue(types,key);

            return blocklyToolboxValue;
        }



        /// <summary>
        /// Functions blocklyAPIFunctions to be generated.
        /// </summary>
        /// <returns></returns>
        public string GenerateBlocklyAPIFunctions(string key = "")
        {
            var allDefs = "";
            _actionList.Sort((a, b) =>
            {
                var res = a.ControllerName.CompareTo(b.ControllerName);
                if (res != 0)
                    return res;

                res = a.Verb.CompareTo(b.Verb);
                if (res != 0)
                    return res;

                return a.ActionName.CompareTo(b.ActionName);

            });
            foreach (var action in _actionList)
            {

                allDefs += Environment.NewLine + _jsGenerator.GenerateFunctionDefinition(action, key);
                allDefs += Environment.NewLine + _jsGenerator.GenerateFunctionJS(action, key);
            }
            return allDefs;
        }
       
        internal string GenerateBlocklyToolBoxFunctionDefinitionFile(string key="")
        {
            var blocklyToolBoxFuncDef = _jsGenerator.GenerateBlocklyToolBoxFunctionDefinitions(_actionList, key);
       
            return blocklyToolBoxFuncDef;

        }


    }
}
