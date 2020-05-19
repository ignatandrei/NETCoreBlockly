using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
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
        /// Uses the blockly swagger.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="name">The name.</param>
        /// <param name="endPoint">The end point.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlocklyOData(this IApplicationBuilder app, string name, string endPoint)
        {
            var blocklyFilesHostedService = app.
ApplicationServices
.GetService<GenerateBlocklyFilesHostedService>();
            var t= blocklyFilesHostedService.AddOdata(name, endPoint);
            t.GetAwaiter().GetResult();
            return app;
        }
        /// <summary>
        /// Uses the blockly swagger.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="name">The name.</param>
        /// <param name="endPoint">The end point.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlocklySwagger(this IApplicationBuilder app, string name, string endPoint)
        {
            var blocklyFilesHostedService =app.
    ApplicationServices
    .GetService<GenerateBlocklyFilesHostedService>();
            blocklyFilesHostedService.AddSwagger(name, endPoint).ConfigureAwait(false).GetAwaiter().GetResult();
            return app;
        }
        /// <summary>
        ///  use blockly
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlockly(this IApplicationBuilder app)
        {

            MapJS(app, "/blocklyDefinitions", b => b.BlocklyTypesDefinition);
            MapJS(app, "/BlocklyToolBoxValueDefinitions", b => b.BlocklyToolBoxValueDefinition);
            MapJS(app, "/blocklyAPIFunctions", b => b.BlocklyAPIFunctions);
            MapJS(app, "/BlocklyToolBoxFunctionDefinitions", b => b.BlocklyToolBoxFunctionDefinition);
            MapJS(app, "/BlocklySwaggers", b => b.SwaggersDictionaryJS);
            MapJS(app, "/BlocklyODatas", b => b.ODataDictionaryJS);
            //var blocklyFilesHostedService =
            //    app.
            //        ApplicationServices
            //        .GetService<GenerateBlocklyFilesHostedService>();

            //foreach (var item in blocklyFilesHostedService.KeySwaggers())
            {
                MapJS(app, "/BlocklyDefinitionsSwagger" , b => b.SwaggerBlocklyTypesDefinition());
                MapJS(app, "/BlocklyToolBoxValueDefinitionsSwagger" , b => b.SwaggerBlocklyToolBoxValueDefinition());
                MapJS(app, "/blocklyAPIFunctionsSwagger" , b => b.SwaggerBlocklyAPIFunctions());
                MapJS(app, "/BlocklyToolBoxFunctionDefinitionsSwagger" , b => b.SwaggerBlocklyToolBoxFunctionDefinition());

            }

            {
                MapJS(app, "/BlocklyDefinitionsOData", b => b.ODataBlocklyTypesDefinition());
                MapJS(app, "/BlocklyToolBoxValueDefinitionsOData", b => b.ODataBlocklyToolBoxValueDefinition());
                MapJS(app, "/blocklyAPIFunctionsOData", b => b.ODataBlocklyAPIFunctions());
                MapJS(app, "/BlocklyToolBoxFunctionDefinitionsOData", b => b.ODataBlocklyToolBoxFunctionDefinition());

            }

            return app;
        }

        private static void MapJS(IApplicationBuilder app, string url, Func<GenerateBlocklyFilesHostedService, string> content)
        {
            app.Map(url, app =>
            {
                var blocklyFilesHostedService =
                app.
                    ApplicationServices
                    .GetService<GenerateBlocklyFilesHostedService>();
                app.Run(async context =>
                {
                    await GetBlocklyFilesHostedServices(context, content(blocklyFilesHostedService));
                });
            });
        }
        private static async Task GetBlocklyFilesHostedServices(HttpContext context, string blocklyDefinitions)
        {
            if (blocklyDefinitions == null)
            {
                throw new Exception("blocklyDefinitions is null");
            }
            var mem = new Memory<byte>(Encoding.UTF8.GetBytes(blocklyDefinitions));
            await context.Response.BodyWriter.WriteAsync(mem);
        }
        private static void mapFile(string dirName, IFileProvider provider, IApplicationBuilder appBuilder)
        {
            var folder = provider.GetDirectoryContents(dirName);
            foreach (var item in folder)
            {
                if (item.IsDirectory)
                {
                    mapFile(dirName + "/" + item.Name, provider, appBuilder);
                    continue;
                }
                string map = (dirName + "/" + item.Name).Substring("blocklyFiles".Length);
                appBuilder.Map(map, app =>
                {
                    var f = item;

                    app.Run(async cnt =>
                    {
                        //TODO: find from extension
                        //cnt.Response.ContentType = "text/html";
                        using var stream = new MemoryStream();
                        using var cs = f.CreateReadStream();
                        byte[] buffer = new byte[2048]; // read in chunks of 2KB
                        int bytesRead;
                        while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                        byte[] result = stream.ToArray();
                        // TODO: do something with the result
                        var m = new Memory<byte>(result);
                        await cnt.Response.BodyWriter.WriteAsync(m);
                    });
                });
            }

        }
        /// <summary>
        /// Uses the cli.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        /// <param name="options">The application builder.</param>
        public static void UseBlocklyUI(this IApplicationBuilder appBuilder, BlocklyUIOptions options =null)
        {
            var manifestEmbeddedProvider =
new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly());

            mapFile("blocklyFiles", manifestEmbeddedProvider, appBuilder);

            #region map options
            options = options ?? new BlocklyUIOptions();
            appBuilder.Map("/BlocklyOptions", app =>
            {
                app.Run(async cnt =>
                {
                    var data = options.StartBlocks?.Replace("`", @"\`");
                    var str = $"var startBlocksStr=`{data}`;";
                    data = options.HeaderName?.Replace("`", @"\`");
                    str += $"{Environment.NewLine}var optHeaderName = `{data}`;";
                    var result = Encoding.UTF8.GetBytes(str);
                    var m = new Memory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });

            });
            #endregion


        }
        /// <summary>
        /// Uses the storage
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public static void UseBlocklyLocalStorage(this IApplicationBuilder appBuilder)
        {
            mapStorage(appBuilder);
        }
        private static void mapStorage(IApplicationBuilder appBuilder)
        {

            var manifestEmbeddedProvider =
                new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly());

            appBuilder.Map("/blocklyStorage", app =>
            {
                app.Run(async cnt =>
                {
                    string nameFile = "extensions/SaveToLocalStorage.js";
                    IFileInfo f = new PhysicalFileInfo(new FileInfo("wwwroot/" + nameFile));

                    if (!f.Exists)
                    {

                        f = manifestEmbeddedProvider.GetFileInfo("blocklyFiles/" + nameFile);
                    }
                     //TODO: add corect mime type for js files
                     using var stream = new MemoryStream();
                    using var cs = f.CreateReadStream();
                    byte[] buffer = new byte[2048]; // read in chunks of 2KB
                     int bytesRead;
                    while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }
                    byte[] result = stream.ToArray();
                     // TODO: do something with the result
                     var m = new Memory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });
            });

        }
    }
}
