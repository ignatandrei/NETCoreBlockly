using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Blockly.ExtensionMethods
{
    public static class ActionInfoExtensions
    {
        public static string GenerateCommandName(this ActionInfo actionInfo)
        {
            var nameCommand = actionInfo.ActionName.Replace("/", "_");
            nameCommand = nameCommand.Replace("{", "_").Replace("}", "_");
            return $"{nameCommand}_{actionInfo.Verb}";

        }

        public static string CommandDisplayName(this ActionInfo actionInfo)
        {

            return actionInfo.Verb + " " + actionInfo.ActionName;
        }
    }
}
