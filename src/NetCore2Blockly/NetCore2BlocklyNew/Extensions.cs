using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using MimeTypes;
using System;
using System.IO;
using System.Reflection;

namespace NetCore2BlocklyNew
{
    public static class Extensions
    {
        public static IEndpointRouteBuilder UseBlocklyAutomation(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapFallbackToFile("BlocklyAutomation/{*:nonfilename}", "BlocklyAutomation/index.html");
            return endpoints;
        }
        public static void UseBlocklyUI(this IApplicationBuilder appBuilder, IWebHostEnvironment environment)
        {
            var manifestEmbeddedProvider =
                    new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly());
            var service = appBuilder.ApplicationServices;
            var physicalProvider = environment.ContentRootFileProvider;
            var compositeProvider =
                new CompositeFileProvider(physicalProvider, manifestEmbeddedProvider);
            mapFile("blocklyAutomation", manifestEmbeddedProvider, appBuilder);
        }
        static string contentFromExtension(string file)
        {
            var dot = file.IndexOf(".");
            if (dot < 1)
                return "text/html";

            var ext = file.Substring(dot+1).ToLowerInvariant();
            return MimeTypeMap.GetMimeType(ext);
            //switch (ext)
            //{
            //    case "htm":
            //        return "text/html";

            //    case "html":
            //        return "text/html";


            //    default:
            //        throw new ArgumentException("cannot handle " + file);
            //}

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
                string map = (dirName + "/" + item.Name);//.Substring(dirName.Length);
                map = "/" + map;
                var s = map;
                appBuilder.Map(map, app =>
                {
                    var f = item;

                    app.Run(async cnt =>
                    {
                        //TODO: find from extension

                        cnt.Response.ContentType = contentFromExtension(map);
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

    }
}
