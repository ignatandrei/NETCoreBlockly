using System;
using System.Collections.Generic;

namespace NetCore2Blockly
{
    public interface IActionInfo
    {
        string ActionName { get; set; }
        string ControllerName { get; set; }
        string Host { get; set; }
        string RelativeRequestUrl { get; set; }
        Type ReturnType { get; set; }
        string Verb { get; set; }

        int CustomGetHashCode();
        Dictionary<string, (Type type, BindingSourceDefinition bs)> Params { get; set; }

        bool HasParams => (Params?.Count > 0);
    }
}