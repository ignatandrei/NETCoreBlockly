using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO.Pipelines;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    /// <summary>
    /// extension to register to the startup
    /// </summary>
    public static class CLIExtension
    {
        static CLIExtension()
        {
            var assName = Assembly.GetExecutingAssembly().GetName();
            Console.WriteLine($"{assName.Name} version:{assName.Version.ToString()}");

        }
        /// <summary>
        /// Adds the blockly to startup
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns></returns>
        public static IServiceCollection AddBlockly(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<GenerateBlocklyFilesHostedService>();
            serviceCollection.AddHostedService(p => p.GetService<GenerateBlocklyFilesHostedService>());

            return serviceCollection;
        }
        /// <summary>
        ///  use blockly
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlockly(this IApplicationBuilder app)
        {

            var service = app.ApplicationServices.GetService<GenerateBlocklyFilesHostedService>();
            service.app = app;
            //TODO: put correct  JAVASCRIPT mime type
            app.Map("/blocklyDefinitions", app =>
            {
                var h = app.ApplicationServices.GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    await GetBlocklyFilesHostedServices(context, h.BlocklyTypesDefinition);
                });
            });

            app.Map("/BlocklyToolBoxValueDefinitions", app =>
            {
                var blocklyFilesHostedService = app.ApplicationServices
                .GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    await GetBlocklyFilesHostedServices(context, blocklyFilesHostedService.BlocklyToolBoxValueDefinition);
                });
            });

            app.Map("/blocklyAPIFunctions", app =>
            {
                var blocklyFilesHostedService = app.ApplicationServices
                .GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    await GetBlocklyFilesHostedServices(context, blocklyFilesHostedService.BlocklyAPIFunctions);
                });
            });
            
            app.Map("/BlocklyToolBoxFunctionDefinitions", app =>
            {
                var blocklyFilesHostedService = app.ApplicationServices
                .GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    await GetBlocklyFilesHostedServices(context, blocklyFilesHostedService.BlocklyToolBoxFunctionDefinition);
                });
            });
            return app;
        }

        private static async Task GetBlocklyFilesHostedServices(Microsoft.AspNetCore.Http.HttpContext context, string blocklyDefinitions)
        {
            if (blocklyDefinitions == null)
            {
                throw new Exception("blocklyDefinitions is null");
            }
            var mem = new Memory<byte>(Encoding.UTF8.GetBytes(blocklyDefinitions));
            await context.Response.BodyWriter.WriteAsync(mem);
        }
    }
}
