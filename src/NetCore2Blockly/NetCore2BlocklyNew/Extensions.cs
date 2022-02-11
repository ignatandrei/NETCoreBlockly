using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using MimeTypes;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore2BlocklyNew
{
    public static class Extensions
    {
        public static IEndpointRouteBuilder UseBlocklyAutomation(this IEndpointRouteBuilder endpoints)
        {
            //endpoints.MapFallbackToFile("BlocklyAutomation/{**:nonfile}", "BlocklyAutomation/index.html");
            endpoints.Map("BlocklyAutomation/{**:nonfile}", async ctx =>
            {
                 var dir = FileProvider.GetDirectoryContents("BlocklyAutomation").ToArray();
                var file = dir.Where(it => it?.Name?.ToLower() == "index.html").FirstOrDefault();
                 var response = ctx.Response;
                response.ContentType = contentFromExtension(file.Name);
                 //in net 6 use sendfileasync
                 using (var fileContent = file.CreateReadStream())
                 {                     
                     await StreamCopyOperation.CopyToAsync(fileContent, response.Body,file.Length, CancellationToken.None);
                 }
            });
            return endpoints;
        }
        public static IFileProvider FileProvider { get; set; }
        public static void UseBlocklyUI(this IApplicationBuilder appBuilder, IWebHostEnvironment environment)
        {
            if (FileProvider == null)
            {
                var manifestEmbeddedProvider =
                        new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly());
                var service = appBuilder.ApplicationServices;
                FileProvider = manifestEmbeddedProvider;
                if (environment != null)
                {
                    var originalProvider = environment.ContentRootFileProvider;
                    var pRoot = originalProvider as PhysicalFileProvider;
                    if (pRoot != null)
                    {
                        //try to add wwwroot for standalone
                        string wwwrootFolder = Path.Combine(pRoot.Root, "wwwroot");
                        if (Directory.Exists(wwwrootFolder))
                            pRoot = new PhysicalFileProvider(wwwrootFolder);
                        FileProvider =
                            new CompositeFileProvider(pRoot, manifestEmbeddedProvider);
                    }
                    else if(originalProvider != null)
                    {
                        FileProvider =
                            new CompositeFileProvider(originalProvider, manifestEmbeddedProvider);

                    }
                }
            }
            mapFile("BlocklyAutomation", FileProvider, appBuilder);
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
                        if (f.Length < 1)
                            throw new ArgumentException($"file {f.Name} does not exists");

                        var chunks = Math.Max(2048, f.Length / 3);
                        byte[] buffer = new byte[chunks]; // read in chunks of 2KB
                        using var stream = new MemoryStream();
                        using var cs = f.CreateReadStream();
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
