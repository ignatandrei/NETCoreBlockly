using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Primitives;
using NetCore2BlocklyStorage.Sqlite.ModelsDB;
using System;
using System.Buffers;
using System.IO;
using System.IO.Pipelines;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCore2Blockly
{
    /// <summary>
    /// extension for sqlite
    /// </summary>
    public static class CLIExtension
    {
        static CLIExtension()
        {
            var assName = Assembly.GetExecutingAssembly().GetName();
            Console.WriteLine($"{assName.Name} version:{assName.Version.ToString()}");

        }


        /// <summary>
        /// Uses the storage
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        /// <param name="sqliteConnection">Sqlitedb connection</param>
        public async static void UseBlocklySqliteStorage(this IApplicationBuilder appBuilder, string sqliteConnection = "Data Source=blocklySqlite.db")
        {
            using var cn = new blocklyCategContext(sqliteConnection);
            await cn.CreateDb();
            mapStorage(appBuilder);
            mapEndpoints(appBuilder, sqliteConnection);
        }

        private static void mapEndpoints(IApplicationBuilder appBuilder,string sqliteConnection)
        {
            appBuilder.Map("/blocklyStorageLength", app =>
            {
                app.Run(async cnt =>
                {
                    using var cn = new blocklyCategContext(sqliteConnection);
                    var res =(await cn.Length()).ToString();

                    byte[] result = Encoding.UTF8.GetBytes(res);
                    
                    var m = new ReadOnlyMemory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });
            });
            appBuilder.Map("/blocklyStoragedata", app =>
            {
                app.Run(async cnt =>
                {
                    using var cn = new blocklyCategContext(sqliteConnection);
                    var data = await cn.data();
                    foreach (var item in data)
                    {
                        item.CleanSerialize();
                    }
                    var res = JsonSerializer.Serialize(data, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    byte[] result = Encoding.UTF8.GetBytes(res);
                    
                    var m = new ReadOnlyMemory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });
            });
            appBuilder.Map("/blocklyStorageget", app =>
            {
                app.Run(async cnt =>
                {

                   var data = cnt.Request.Query["key"];
                   if (string.IsNullOrWhiteSpace(data.ToString()))
                   {
                        await WriteString(cnt.Response.BodyWriter, "please add query string ?key=...");
                        return;
                   }
                   
                    using var cn = new blocklyCategContext(sqliteConnection);
                    var block = await cn.Get(data);
                    if (block == null)
                        return;
                    var res = JsonSerializer.Serialize(block.CleanSerialize(), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    await WriteString(cnt.Response.BodyWriter, res);
                    
                });
            });

            appBuilder.Map("/blocklyStorageset", app =>
            {
                app.Run(async cnt =>
                {

                    var data = cnt.Request.Query["key"];
                    if (string.IsNullOrWhiteSpace(data.ToString()))
                    {
                        await WriteString(cnt.Response.BodyWriter, "please add query string ?key=...");
                        return;
                    }
                    
                    ReadOnlySequence<byte> buffer;
                    while (true)
                    {
                        var blockData = await cnt.Request.BodyReader.ReadAsync();
                        buffer = blockData.Buffer;
                        cnt.Request.BodyReader.AdvanceTo(buffer.Start, buffer.End);
                        if (blockData.IsCompleted)
                            break;

                    }
                    var doc = JsonSerializer.Deserialize<Blocks>(buffer.FirstSpan, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    using var cn = new blocklyCategContext(sqliteConnection);
                    var block = await cn.Set(data,doc);
                    
                    var res = JsonSerializer.Serialize(block.CleanSerialize(),new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    await WriteString(cnt.Response.BodyWriter, res);
                        
                });
            });


        }
        private static async Task WriteString(PipeWriter pw, string message)
        {
            byte[] result = Encoding.UTF8.GetBytes(message);

            var m = new ReadOnlyMemory<byte>(result);
            await pw.WriteAsync(result);
        }
        private static void mapStorage(IApplicationBuilder appBuilder)
        {

            var manifestEmbeddedProvider =
                new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly());

            appBuilder.Map("/blocklyStorage", app =>
            {
                app.Run(async cnt =>
                {
                    cnt.Response.ContentType = "application/javascript";
                    
                    string nameFile = "extensions/SaveToSqliteStorage.js";
                    
                    var f = manifestEmbeddedProvider.GetFileInfo("blocklyFiles/" + nameFile);

                    using var stream = new MemoryStream();
                    using var cs = f.CreateReadStream();
                    byte[] buffer = new byte[2048]; // read in chunks of 2KB
                    int bytesRead;
                    while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }
                    byte[] result = stream.ToArray();
                    var m = new ReadOnlyMemory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });
            });

        }
    }
}
