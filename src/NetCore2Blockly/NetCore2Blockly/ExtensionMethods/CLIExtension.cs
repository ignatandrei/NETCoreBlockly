using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Text;

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
                    var b = h.BlocklyTypesDefinition;
                    if (b != null)
                    {
                        var mem = new Memory<byte>(Encoding.UTF8.GetBytes(b));
                        await context.Response.BodyWriter.WriteAsync(mem);
                    }
                });
            });
            //TODO: duplicate function please refactor.
            app.Map("/BlocklyToolBoxValueDefinitions", app =>
            {
                var h = app.ApplicationServices.GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    var b = h.BlocklyToolBoxValueDefinition;
                    if (b != null)
                    {
                        var mem = new Memory<byte>(Encoding.UTF8.GetBytes(b));
                        await context.Response.BodyWriter.WriteAsync(mem);
                    }
                });
            });
            app.Map("/blocklyAPIFunctions", app =>
            {
                var h = app.ApplicationServices.GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    var b = h.BlocklyAPIFunctions;
                    if (b != null)
                    {
                        var mem = new Memory<byte>(Encoding.UTF8.GetBytes(b));
                        await context.Response.BodyWriter.WriteAsync(mem);
                    }
                });
            });
            
            app.Map("/BlocklyToolBoxFunctionDefinitions", app =>
            {
                var h = app.ApplicationServices.GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    var b = h.BlocklyToolBoxFunctionDefinition;
                    if (b != null)
                    {
                        var mem = new Memory<byte>(Encoding.UTF8.GetBytes(b));
                        await context.Response.BodyWriter.WriteAsync(mem);
                    }
                });
            });
            return app;
        }
    }
}
