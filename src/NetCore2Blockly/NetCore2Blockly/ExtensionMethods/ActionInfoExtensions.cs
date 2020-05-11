using System;
using System.Collections.Generic;
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
            var nameCommand = actionInfo.ActionName.Replace("/", "_");
            nameCommand = nameCommand.Replace("{", "_").Replace("}", "_");
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
