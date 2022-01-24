using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;

namespace NetCore2BlocklyNew
{
    public static class Extensions
    {
        public static IEndpointRouteBuilder UseBlocklyAutomation(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapFallbackToFile("BlocklyAutomation/{*:nonfilename}", "BlocklyAutomation/index.html");
            return endpoints;
        }

    }
}
