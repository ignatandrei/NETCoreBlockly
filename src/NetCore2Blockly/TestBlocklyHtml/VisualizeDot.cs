using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestBlocklyHtml
{
    public static class DotMiddlewareExtensions
    {
        public static IEndpointConventionBuilder MapGraph(
            this IEndpointRouteBuilder endpoints, string pattern)
        {

            var pipeline = endpoints
                .CreateApplicationBuilder()
                .UseMiddleware<VisualizeDot>()
                .Build();

            return endpoints.Map(pattern, pipeline).WithDisplayName("Graph");
        }
    }
    public class VisualizeDot : IMiddleware
    {
        private readonly DfaGraphWriter graphWriter;
        private readonly EndpointDataSource endpointData;

        public VisualizeDot(DfaGraphWriter graphWriter,EndpointDataSource endpointData)
        {
            this.graphWriter = graphWriter;
            this.endpointData = endpointData;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/plain";

            await using (var sw = new StringWriter())
            {
                graphWriter.Write(endpointData, sw);
                var data = sw.ToString();
                await context.Response.WriteAsync(data);
            }
        }
    }
}
