using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly
{
    /// <summary>
    /// extension to generate types
    /// </summary>
    public static class ActionListExtensions
    {


        /// <summary>
        /// Gets the type with null blockly default types.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static TypeArgumentBase[] GetAllTypesWithNullBlocklyType(this List<ActionInfo> list)
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
