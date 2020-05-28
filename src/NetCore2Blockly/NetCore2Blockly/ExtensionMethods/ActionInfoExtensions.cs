using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly.ExtensionMethods
{
    /// <summary>
    /// extnesion to generate names from ActionInfo
    /// </summary>
    public static class ActionInfoExtensions
    {
        /// <summary>
        /// Generates the name of the command.
        /// </summary>
        /// <param name="actionInfo">The action information.</param>
        /// <returns></returns>
        public static string GenerateCommandName(this ActionInfo actionInfo)
        {
            var siteHost = (actionInfo.Site + actionInfo.Host) ??"";
            siteHost = siteHost
                .Replace("https://", "")
                .Replace("http://", "")
                ;
            if (siteHost.Length > 0)
                siteHost += "_";

            var nameCommand = siteHost+ actionInfo.RelativeRequestUrl;
            if (nameCommand.IndexOf("/(S(") > 0)//session in url
            {
                nameCommand = string.Join('/',
                    nameCommand
                    .Split('/', StringSplitOptions.RemoveEmptyEntries)
                    .Where(it => !it.StartsWith("(S("))
                    .ToArray());

            }
            if (actionInfo.Params?.Count > 0)
            {
                bool addPath = !nameCommand.Contains("{");
                var query = actionInfo
                    .Params
                    .Where(it => 
                    it.Value.bs == BindingSourceDefinition.Query
                    ||
                    ( addPath &&
                    it.Value.bs ==
                    BindingSourceDefinition.Path)
                    )
                    .ToArray();
                if (query.Length > 0)
                {
                    var str = string.Join("_", query.Select(it => it.Key));
                    nameCommand += "_" + str;
                }
            }
            nameCommand = nameCommand
                .Replace("/", "_")
                .Replace("{", "_")
                .Replace("}", "_")
                .Replace("$", "_")
                .Replace("'", "_")
                .Replace(".", "_")
                .Replace(")", "_")
                .Replace("(", "_")
                .Replace(@"\", "_")
                
                ;
            return $"{nameCommand}_{actionInfo.Verb}";

        }

        /// <summary>
        /// Commands the display name.
        /// </summary>
        /// <param name="actionInfo">The action information.</param>
        /// <param name="withVerb">display with verb</param>
        /// <returns></returns>
        public static string CommandDisplayName(this ActionInfo actionInfo, bool withVerb )
        {

            return (withVerb? actionInfo.Verb + " ":"") + actionInfo.ActionName;
        }
    }
}
