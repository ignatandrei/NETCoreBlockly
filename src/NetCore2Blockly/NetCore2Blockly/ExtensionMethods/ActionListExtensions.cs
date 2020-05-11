using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore2Blockly
{
    /// <summary>
    /// extension to generate types
    /// </summary>
    static class ActionListExtensions
    {


        /// <summary>
        /// Gets the type with null blockly default types.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        internal static TypeArgumentBase[] GetAllTypesWithNullBlocklyType(this List<ActionInfo> list)
        {
            var types= list

                .SelectMany(it => it.Params)
                .Select(param => param.Value.type)
                .Distinct()
                .Where(type => type.TranslateToBlocklyType()==null)
                
                .ToArray();


            var ids = types.Select(it => it.id).ToArray();
            // see the inner properties if contains another types
            var propsExtra =
                 types.SelectMany(it => it.GetProperties())
                .Where(it => it != null && it.PropertyType != null)
                .Where(it => it.PropertyType.TranslateToBlocklyType() == null)
                .Select(it => it.PropertyType)
                .ToArray();

            var remaining = propsExtra.Where(it => !ids.Contains(it.id)).ToArray();
            if (remaining.Length > 0)
                types = types.Union(remaining).ToArray();

            return types;

        }

    }
}
