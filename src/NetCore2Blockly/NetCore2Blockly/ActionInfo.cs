using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2Blockly
{

    /// <summary>
    /// generator
    /// </summary>

    class ActionInfo : IActionInfo
    {

        /// <summary>
        /// Gets or sets the name of the controller.
        /// </summary>
        /// <value>
        /// The name of the controller.
        /// </value>
        public string ControllerName { get; set; }

        /// <summary>
        /// Gets or sets the type of the return.
        /// </summary>
        /// <value>
        /// The type of the return.
        /// </value>
        public Type ReturnType { get; set; }

        /// <summary>
        /// Gets or sets the name of the action.
        /// </summary>
        /// <value>
        /// The name of the action.
        /// </value>
        public string ActionName { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the relative request URL.
        /// </summary>
        /// <value>
        /// The relative request URL.
        /// </value>
        public string RelativeRequestUrl { get; set; }
        /// <summary>
        /// Gets or sets the verb.
        /// </summary>
        /// <value>
        /// The verb.
        /// </value>
        public string Verb { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CustomGetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Host?.GetHashCode() ?? 0;
            hash = (hash * 7) + ControllerName.GetHashCode();

            return hash;
        }

        public Dictionary<string, (Type type, BindingSourceDefinition bs)> Params { get; set; }
        internal bool HasParams => (Params?.Count ?? 0) > 0;
        private BindingSourceDefinition ConvertFromBindingSource(BindingSource bs)
        {
            return bs switch
            {
                var x when x == BindingSource.Body => BindingSourceDefinition.Body,
                var x when x == BindingSource.Custom => BindingSourceDefinition.Custom,
                var x when x == BindingSource.Form => BindingSourceDefinition.Form,
                var x when x == BindingSource.FormFile => BindingSourceDefinition.FormFile,
                var x when x == BindingSource.Header => BindingSourceDefinition.Header,

                var x when x == BindingSource.ModelBinding => BindingSourceDefinition.ModelBinding,

                var x when x == BindingSource.Path => BindingSourceDefinition.Path,

                var x when x == BindingSource.Query => BindingSourceDefinition.Query,

                var x when x == BindingSource.Services => BindingSourceDefinition.Services,

                var x when x == BindingSource.Special => BindingSourceDefinition.Special,


                _ => throw new ArgumentException($"not know {bs.DisplayName}")

            };
        }
        Dictionary<string, (Type type, BindingSourceDefinition bs)> GetParameters(ApiParameterDescription[] parameterDescriptions)
        {
            var desc = new Dictionary<string, (Type type, BindingSourceDefinition bs)>();

            if (parameterDescriptions?.Length == 0)
                return desc;

            var okBindingSource = new[]
           {
                BindingSource.Body,
                BindingSource.Form,
                BindingSource.Path,
                BindingSource.Query,
                null // for the items that have not binding source, assume are query string
            };

            parameterDescriptions
            .Where(parameterDescription => parameterDescription != null)
            .Select(parameterDescription => parameterDescription.ParameterDescriptor)
            .Where(parameterDescriptor => parameterDescriptor != null && okBindingSource.Contains(parameterDescriptor.BindingInfo?.BindingSource))
            .Distinct()
            .ToList()
            .ForEach(x => desc.Add(x.Name, (x.ParameterType, ConvertFromBindingSource(x.BindingInfo?.BindingSource ?? BindingSource.Query))));

            if (parameterDescriptions.Length > desc.Count)
            {
                Debug.Assert(false, " should not have more parameters");

            }

            return desc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionInfo"/> class.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        public ActionInfo(ApiDescription apiDescription)
        {

            ActionName = apiDescription.RelativePath;
            Verb = apiDescription.HttpMethod ?? "GET";
            RelativeRequestUrl = apiDescription.RelativePath;
            Params = GetParameters(apiDescription.ParameterDescriptions.ToArray());
            var actionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
            ReturnType = actionDescriptor?.MethodInfo?.ReturnType;


            if (ReturnType != null && ReturnType.IsGenericType)
            {
                if (ReturnType.IsSubclassOf(typeof(Task)))
                {
                    ReturnType = ReturnType.GetGenericArguments()[0];//TODO: get all

                }
            }
            ControllerName = actionDescriptor?.ControllerName;

        }


    }
}