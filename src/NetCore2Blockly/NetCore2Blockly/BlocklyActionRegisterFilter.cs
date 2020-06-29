using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    public class BlocklyActionRegisterFilter : IActionFilter
    {
        private readonly GenerateBlocklyFilesHostedService hosted;

        public BlocklyActionRegisterFilter(GenerateBlocklyFilesHostedService hosted)
        {
            this.hosted = hosted;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var req = context.HttpContext.Request;
            var url = req.Path.Value;
            var m = req.Method.ToUpper();
            var ad = context.ActionDescriptor as ControllerActionDescriptor;

            var rv = context.ActionArguments;
            
            var possibleCandidatesMethod =
                hosted
                .blocklyFileGeneratorWebAPI?
                ._actionList
                .Where(it => it.Verb?.ToUpper() == m)
                .Select(it=>it as ActionInfoFromNetAPI)
                .Where(it => ad.ControllerName.ToUpper() == it.ControllerName.ToUpper())
                .ToArray();
            if (url.StartsWith("/"))
                url = url.Substring(1);
            ActionInfo ai = null;
            foreach(var item in possibleCandidatesMethod)
            {
                var urlFromRoute = item.RelativeRequestUrl;
                foreach(var kv in rv)
                {
                    urlFromRoute = urlFromRoute.Replace("{" + kv.Key + "}", kv.Value.ToString());
                }
                if(urlFromRoute.StartsWith("/"))
                    url = url.Substring(1);
                if (url.ToLower() == urlFromRoute.ToLower())
                {
                    ai = item;
                    break;
                }
            }
            // Generate blocks from ai
            //string x = possibleCandidatesMethod.Length.ToString();
            

        }
    }
    //class BlocklyRegisterMiddleware : IMiddleware
    //{
       
    //    private readonly GenerateBlocklyFilesHostedService hosted;

    //    public BlocklyRegisterMiddleware(GenerateBlocklyFilesHostedService hosted)
    //    {
    //        this.hosted = hosted;
    //    }
    //    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    //    {

    //        var req = context.Request;
    //        var m = req.Method.ToUpper();
    //        var url = req.Path.Value;

    //        var possibleCandidatesMethod =
    //            hosted
    //            .blocklyFileGeneratorWebAPI?
    //            ._actionList
    //            .Where(it => it.Verb?.ToUpper() == m)
    //            .ToArray();

    //        var possibleCandidates= possibleCandidatesMethod
    //            .Where(it => url.Contains(it.RelativeRequestUrl, StringComparison.InvariantCultureIgnoreCase))
    //            .ToArray();

    //        if(1 != possibleCandidates.Length)
    //        {
    //            string x = possibleCandidates.Length.ToString();
    //        }
    //        await next(context);
    //    }
    //}
}
