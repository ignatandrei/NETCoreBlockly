using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetCore2Blockly.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly.JavascriptGeneration
{
    /// <summary>
    /// generates function to translate blockly to JS
    /// </summary>
    public class BlocklyFunctionJSGenerator
    {

        
        /// <summary>
        /// blockly javascript code for action.
        /// </summary>
        /// <param name="actionInfo">The action information.</param>
        /// <returns></returns>
        public string GenerateFunctionJS(ActionInfo actionInfo)
        {
            var paramsStr = "";
            var paramsBodyStr = "";
            string argsXHR = "";
            string[] argsBody = null;

            if (actionInfo.HasParams)
            {
                argsBody = actionInfo.Params.Where(it => it.Value.bs == BindingSource.Body)
                    .Select(it => it.Key)
                    .ToArray();

                if (argsBody.Length > 0)
                {
                    paramsBodyStr = string.Join(Environment.NewLine,
                       argsBody.Select(it => $"objBody['val_{it}'] =obj['val_{it}'];"));
                }

                paramsStr = string.Join(Environment.NewLine,
                    actionInfo.Params.Select(param =>

                        $@" 
                        obj['val_{param.Key}'] = Blockly.JavaScript.valueToCode(block, 'val_{param.Key}', Blockly.JavaScript.ORDER_ATOMIC);"
                                             )
                    );
                
                
                    argsXHR = string.Join(",", actionInfo.Params.Select(param => $@"${{obj['val_{param.Key}']}}"));
            }

            if (argsBody?.Length > 0)
            {
                argsXHR += ",${JSON.stringify(objBody)}";
            }

            var returnValue = " return [code, Blockly.JavaScript.ORDER_NONE];";

            return $@"
                        Blockly.JavaScript['{actionInfo.GenerateCommandName()}'] = function(block) {{
                        var obj={{}};
                        var objBody={{}};
                        {paramsStr}
                        {paramsBodyStr}
                        var code =`{GenerateGet(actionInfo)}({argsXHR})`;
                        {returnValue}
                        }};
                    ";
        }

        internal string GenerateGet(ActionInfo actionInfo)
        {
            var paramsXHR = "strUrl";
            bool existBody = false;
            var strQueryString = "";
            var paramsQuery = actionInfo.Params.Where(it => it.Value.bs == BindingSource.Query)?.ToArray();
            if (paramsQuery?.Count()>0)
            {
                strQueryString = string.Join("&",
                    paramsQuery.Select(it => it.Key)
                    .Select(it => $"&{it}={{{it}}}"));
            }
            if (strQueryString.Length > 0)
                strQueryString = $"?{strQueryString}";
            string paramsFunction = "";
            if (actionInfo.HasParams)
            {
                paramsFunction += string.Join(",", actionInfo.Params.Select(it => it.Key));
            }
          
            if (paramsFunction.Length > 0)
            {
                foreach (var item in actionInfo.Params)
                {
                    if (item.Value.bs != BindingSource.Body)
                        continue;
                    existBody = true;
                    paramsXHR += $",JSON.stringify({item.Key})";
                }
            }
            if (actionInfo.HasParams && existBody)
            {
                paramsFunction += ",bodyRequest";
            }

            var str = $@"function({paramsFunction}){{
                var strUrl =  '{actionInfo.RelativeRequestUrl}{strQueryString}';      
                ";
            if (actionInfo.HasParams)
                foreach (var param in actionInfo.Params)
                {
                    if (param.Value.bs == BindingSource.Path || param.Value.bs == BindingSource.Query)
                        str += $@"strUrl = strUrl.replace('{{{param.Key}}}',{param.Key});";

                }

            var functionXHR = actionInfo.Verb.ToLower();

            str += $"return {functionXHR}Xhr({paramsXHR});}}";
            return str;
        }
    }
}
