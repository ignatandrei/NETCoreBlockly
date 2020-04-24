using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly
{
    public static class ActionListExtensions
    {
        

        public static Type[] GetAllTypesWithNullBlocklyType(this List<ActionInfo> list)
        {
            return  list

                .SelectMany(it => it.Params)
                .Select(param => param.Value.type)
                .Distinct()
                .Where(type => type.TranslateToBlocklyType()==null)
                
                .ToArray();
        }

    }
}
