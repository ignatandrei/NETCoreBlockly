using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    /// <summary>
    /// extension to register to the startup
    /// </summary>
    public static class CLIExtension
    {
        private const string Key = "NetCoreBlockly:OtherLinks";
        static string nameBlockly()
        {
            var ass = Assembly.GetExecutingAssembly();
            var assName = ass.GetName();
            var nameBlockly = assName.Name;
            try
            {
                var title = ass.GetCustomAttribute<AssemblyTitleAttribute>();
                nameBlockly = title?.Title ?? nameBlockly;
            }
            catch
            {
                //do nothing
            }
            return $"{nameBlockly} version:{assName.Version.ToString()}";
        }
        static CLIExtension()
        {          
            Console.WriteLine(nameBlockly());
        }
        /// <summary>
        /// Uses the blockly links from config
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlocklyLinksFromConfig(this IApplicationBuilder app, IConfiguration  config)
        {
            var otherLinks = config.GetSection(Key).Get<BLocklyOtherLinks>();
            return UseBatchBlocklyLinks(app, otherLinks);
        }
        /// <summary>
        /// Adds the batch blockly links.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="links">The links.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseBatchBlocklyLinks(this IApplicationBuilder  app,BLocklyOtherLinks links)
        {
            if (links == null)
                return app;

            if (links.ODatas?.Length > 0)
            {
                foreach(var item in links.ODatas)
                {
                    UseBlocklyOData(app, item.Name, item.Link);
                }
            }
            if (links.Swaggers?.Length > 0)
            {
                foreach (var item in links.Swaggers)
                {
                    UseBlocklySwagger(app, item.Name, item.Link);
                }
            }
            return app;
        }
        /// <summary>
        /// Adds the blockly to startup
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <param name="fullWebSiteUrl"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlockly(this IServiceCollection serviceCollection, string fullWebSiteUrl = null)
        {
            GenerateBlocklyFilesHostedService.InternalSiteUrl = fullWebSiteUrl;
            serviceCollection.AddSingleton<GenerateBlocklyFilesHostedService>();
            serviceCollection.AddHostedService(p => p.GetService<GenerateBlocklyFilesHostedService>());
            //serviceCollection.AddTransient<BlocklyRegisterMiddleware>();
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
        /// Uses the blockly.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlockly(this IApplicationBuilder app)
        {
            var service = app.ApplicationServices.GetService<GenerateBlocklyFilesHostedService>();
            service.app = app;
            MapJS(app, "/blocklyDefinitions", b => b.BlocklyTypesDefinition);
            MapJS(app, "/BlocklyToolBoxValueDefinitions", b => b.BlocklyToolBoxValueDefinition);
            MapJS(app, "/blocklyAPIFunctions", b => b.BlocklyAPIFunctions);
            MapJS(app, "/BlocklyToolBoxFunctionDefinitions", b => b.BlocklyToolBoxFunctionDefinition);
            MapJS(app, "/BlocklySwaggers", b => b.SwaggersDictionaryJS);
            MapJS(app, "/BlocklyODatas", b => b.ODataDictionaryJS);
            MapJS(app, "/BlocklyGraphQLs", b => b.GraphQLDictionaryJS);
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


            {
                MapJS(app, "/BlocklyDefinitionsGraphQL", b => b.GraphQLBlocklyTypesDefinition());
                MapJS(app, "/BlocklyToolBoxValueDefinitionsGraphQL", b => b.GraphQLBlocklyToolBoxValueDefinition());
                MapJS(app, "/blocklyAPIFunctionsGraphQL", b => b.GraphQLBlocklyAPIFunctions());
                MapJS(app, "/BlocklyToolBoxFunctionDefinitionsGraphQL", b => b.GraphQLBlocklyToolBoxFunctionDefinition());

            }
            app.Map("/NetCore2BlocklyVersion", config =>
             {
                 config.Run(async context =>
                 {
                     await context.Response.WriteAsync(nameBlockly());
                 });
             });
            return app;
        }
        //public static IApplicationBuilder UseBlocklyRegisterMiddleware(this IApplicationBuilder  builder)
        //{
        //    var service = builder.ApplicationServices.GetService<GenerateBlocklyFilesHostedService>();

        //    //builder.UseMiddleware<BlocklyRegisterMiddleware>();
        //    return builder;
        //}
        /// <summary>
        /// add GraphQL endpoints
        /// </summary>
        /// <param name="app"></param>
        /// <param name="key"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseBlocklyGraphQL(this IApplicationBuilder app,string key, string endpoint)
        {
            var blocklyFilesHostedService = app.ApplicationServices
                    .GetService<GenerateBlocklyFilesHostedService>();
            var t = blocklyFilesHostedService.AddGraphQL(key, endpoint);
            t.GetAwaiter().GetResult();

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
                    context.Response.ContentType = "application/javascript";
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
            var service = appBuilder.ApplicationServices;
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
                    data= options.CustomBlocks?.Replace("`", @"\`");
                    str += $"{Environment.NewLine}var customBlocks = `{data}`;";

                    str += $"{Environment.NewLine}{options.RunTimeString?.Invoke(service)};";
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
