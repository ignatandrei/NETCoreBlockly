using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    /// <summary>
    /// generator
    /// </summary>
    
    public class ActionInfo
    {
        
        public string ControllerName { get; set; }
       
        public Type ReturnType { get; set; }
       
        public string ActionName { get; set; }
        
        public string Host { get; set; }
      
        public string RelativeRequestUrl { get; set; }
       
        public string Verb { get; set; }
        
        public virtual Dictionary<string, (Type type, BindingSource bs)> Params {  get; internal set; }
        internal bool HasParams => (Params?.Count ?? 0) > 0;


        public ActionInfo()
        {

        }

        Dictionary<string, (Type type, BindingSource bs)> GetParameters(ApiParameterDescription[] parameterDescriptions)
        {
            var desc = new Dictionary<string, (Type type, BindingSource bs)>();

            if (parameterDescriptions?.Length == 0)
                return desc;

            var okBindingSource = new[]
           {
                BindingSource.Body,
                BindingSource.Form,
                BindingSource.Path,
                BindingSource.Query
            };

                parameterDescriptions
                .Where(parameterDescription => parameterDescription != null)
                .Select(parameterDescription => parameterDescription.ParameterDescriptor)
                .Where(parameterDescriptor => parameterDescriptor != null && okBindingSource.Contains(parameterDescriptor.BindingInfo?.BindingSource))
                .Distinct()
                .ToList()
                .ForEach(x => desc.Add(x.Name, (x.ParameterType, x.BindingInfo.BindingSource)));
         
           

            return desc;
        }

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