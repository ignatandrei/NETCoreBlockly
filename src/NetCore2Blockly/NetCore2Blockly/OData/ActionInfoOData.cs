using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore2Blockly.OData
{
    class ActionInfoOdata : ActionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionInfoOdata"/> class.
        /// </summary>
        public ActionInfoOdata()
        {
            Params = new Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)>();
        }
        static internal string GenerateActionName(string relativeRequest)
        {
            var arr = relativeRequest.Split("/");
            for (var i = arr.Length; i > 0; i--)
            {
                if (arr[i - 1].Contains("{"))
                    continue;

                return arr[i - 1];
            }
            return "unknown";
        }
        static internal string GenerateControllerName(string relativeRequest)
        {
            string controllerName = relativeRequest;
            if (controllerName.ToLowerInvariant().StartsWith("/api/"))
                controllerName = controllerName.Substring(5);

            var index = controllerName.IndexOf("/");
            if (index > 0)
                controllerName = controllerName.Substring(0, index - 1);

            return controllerName;
        }
    }
}
