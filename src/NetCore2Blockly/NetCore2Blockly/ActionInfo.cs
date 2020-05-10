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

    class ActionInfoFromNetAPI : ActionInfo
    {

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
        Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)> GetParameters(ApiParameterDescription[] parameterDescriptions)
        {
            var desc = new Dictionary<string, (TypeArgumentBase type, BindingSourceDefinition bs)>();

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
            .ForEach(x => desc.Add(x.Name, (new TypeToGenerateFromCSharp( x.ParameterType), ConvertFromBindingSource(x.BindingInfo?.BindingSource ?? BindingSource.Query))));

            if (parameterDescriptions.Length > desc.Count)
            {
                Debug.Assert(false, " should not have more parameters");

            }

            return desc;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionInfoFromNetAPI"/> class.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        public ActionInfoFromNetAPI(ApiDescription apiDescription)
        {

            ActionName = apiDescription.RelativePath;
            Verb = apiDescription.HttpMethod ?? "GET";
            RelativeRequestUrl = apiDescription.RelativePath;
            Params = GetParameters(apiDescription.ParameterDescriptions.ToArray());
            var actionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;
            var ret= ( actionDescriptor?.MethodInfo?.ReturnType);


            if (ret != null && ret.IsGenericType)
            {
                if (ret.IsSubclassOf(typeof(Task)))
                {
                    ret= ret.GetGenericArguments()[0];//TODO: get all

                }
            }
            ReturnType = new TypeToGenerateFromCSharp(ret);
            ControllerName = actionDescriptor?.ControllerName;

        }


    }
}