using System.Collections.Generic;
using System.Text;

namespace NetCore2Blockly.Swagger
{

    class ActionInfoSwagger : ActionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionInfoSwagger"/> class.
        /// </summary>
        public ActionInfoSwagger()
        {
            Params = new Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)>();
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
