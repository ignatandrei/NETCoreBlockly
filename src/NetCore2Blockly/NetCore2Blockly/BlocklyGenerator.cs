using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NetCore2Blockly
{
    /// <summary>
    /// generator
    /// </summary>
    [DebuggerDisplay("{NameCommand} {Verb}")]
    public class BlocklyGenerator
    {
        /// <summary>
        /// Gets or sets the name of the controller.
        /// </summary>
        /// <value>
        /// The name of the controller.
        /// </value>
        public string ControllerName { get; set; }
        /// <summary>
        /// Gets or sets the type of the return.
        /// </summary>
        /// <value>
        /// The type of the return.
        /// </value>
        public Type ReturnType { get; set; }
        /// <summary>
        /// Gets or sets the name command.
        /// </summary>
        /// <value>
        /// The name command.
        /// </value>
        public string NameCommand { get; set; }
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets the relative request URL.
        /// </summary>
        /// <value>
        /// The relative request URL.
        /// </value>
        public string RelativeRequestUrl { get; set; }
        /// <summary>
        /// Gets or sets the verb.
        /// </summary>
        /// <value>
        /// The verb.
        /// </value>
        public string Verb { get; set; }
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string ContentType { get; set; } = "application/json";
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Dictionary<string, (Type type, BindingSource bs)> Params { get; internal set; }


        internal string nameCommand()
        {
            var nameCommand = NameCommand.Replace("/", "_");
            nameCommand = nameCommand.Replace("{", "_").Replace("}", "_");
            return $"{nameCommand}_{Verb}";

        }
        internal string returnFunction()
        {
            if (ReturnType == typeof(void))
            {
                return "Boolean";
                //return $"this.setOutput(true, 'Boolean');";
                //return @" 
                //    this.setPreviousStatement(true, null);
                //    this.setNextStatement(true, null);";
            }
            else
            {
                //return $"this.setOutput(true, {ListOfBlockly.nameType(ReturnType)});";
                return ListOfBlockly.nameType(ReturnType);
            }
        }
        internal string propsDefinitionFunction()
        {
            string tooltip = $"{this.nameCommand()} :";
            var strPropsDefinition = "";
            if (Params != null)
                foreach (var param in Params)
                {
                    strPropsDefinition += $@"
                    this.appendValueInput('val_{param.Key}')
                    .setCheck('{ListOfBlockly.nameType(param.Value.type)}')
                    .appendField('{param.Key}'); ";

                    tooltip += $"{param.Key}: {ListOfBlockly.nameType(param.Value.type)}";

                }
            tooltip += $" returns: {returnFunction()}";
            return strPropsDefinition + ";"+ $" this.setTooltip('{tooltip}');";
        }
        internal string CommandDisplayName()
        {
            
            return this.Verb + " " + NameCommand;
        }
        internal string FunctionDefinition()
        {
            var strPropsDefinition = propsDefinitionFunction();

            var returnType = $"this.setOutput(true,'{returnFunction()}');";

            return $@"
                Blockly.Blocks['{nameCommand()}'] = {{
  init: function() {{
    this.appendDummyInput()
        .appendField('{CommandDisplayName()}');
        {strPropsDefinition}
        {returnType}
        }}//init
}};//{NameCommand}
";
        }
        internal bool ExistsParams => (this.Params?.Count ?? 0) > 0;
        string GenerateGet()
        {
            string paramsFunction = "";
            if (ExistsParams)
            {
                paramsFunction += string.Join(",", Params.Select(it => it.Key));
            }
            var paramsXHR = "strUrl";
            bool existBody = false;
            if (paramsFunction.Length > 0)
            {
                foreach(var item in Params){
                    if (item.Value.bs != BindingSource.Body)
                        continue;
                    existBody = true;
                    paramsXHR += $",JSON.stringify({item.Key})";
                }
            }
            if(ExistsParams && existBody)
            {
                paramsFunction += ",bodyRequest";
            }
            var str = $@"function({paramsFunction}){{
                var strUrl =  '{this.RelativeRequestUrl}';      
                ";
            if (ExistsParams)                            
            foreach(var param in Params)
            {
                if(param.Value.bs == BindingSource.Path || param.Value.bs == BindingSource.Query)
                    str += $@"strUrl = strUrl.replace('{{{param.Key}}}',{param.Key});";
                
            }

            var functionXHR = Verb.ToLower();
            //if(functionXHR == "post")
            //{
            //    if(ReturnType == typeof(void))
            //    {
            //        functionXHR = "postVoid";
            //    }
            //}
           
            str += $"return {functionXHR}Xhr({paramsXHR});}}";
            return str;
        }
        internal string FunctionJSGenerator()
        {
            var paramsStr = "";
            var paramsBodyStr = "";
            string argsXHR = "";
            string[] argsBody = null;
            if (ExistsParams)
            {
                argsBody = Params.Where(it => it.Value.bs == BindingSource.Body)
                    .Select(it=>it.Key)
                    .ToArray() ;
                if (argsBody.Length > 0)
                {
                    paramsBodyStr = string.Join(Environment.NewLine,
                       argsBody.Select(it => $"objBody['val_{it}'] =obj['val_{it}'];"));
                }
                paramsStr =string.Join(Environment.NewLine,
                    Params.Select(param=>
                    $@"
                    obj['val_{param.Key}'] = Blockly.JavaScript.valueToCode(block, 'val_{param.Key}', Blockly.JavaScript.ORDER_ATOMIC);"
                    
                    ));
                argsXHR = string.Join(",", Params.Select(param => $@"${{obj['val_{param.Key}']}}"));
            }
            
            if (argsBody?.Length > 0)
            {
                argsXHR += ",${JSON.stringify(objBody)}";
            }
            var returnValue = "";
            if (ReturnType == typeof(void))
            {
                returnValue = " return code;";
                returnValue = " return [code, Blockly.JavaScript.ORDER_NONE];";

            }
            else
            {
                returnValue = " return [code, Blockly.JavaScript.ORDER_NONE];";
            }
            
            return $@"
Blockly.JavaScript['{nameCommand()}'] = function(block) {{
var obj={{}};//{RelativeRequestUrl}
var objBody={{}};
{paramsStr}
{paramsBodyStr}
//console.log('{Verb} {RelativeRequestUrl}');
//console.log(obj);
//console.log(objBody);
var code =`{GenerateGet()}({argsXHR})`;

{returnValue}
}};
";
        }
    }
}