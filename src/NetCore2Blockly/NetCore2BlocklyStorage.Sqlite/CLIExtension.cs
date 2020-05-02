using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using NetCore2BlocklyStorage.Sqlite.ModelsDB;
using System;
using System.IO;
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
                    var res = JsonSerializer.Serialize(await cn.data());

                    byte[] result = Encoding.UTF8.GetBytes(res);
                    
                    var m = new ReadOnlyMemory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });
            });



        }

        private static void mapStorage(IApplicationBuilder appBuilder)
        {

            var manifestEmbeddedProvider =
                new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly());

            appBuilder.Map("/blocklyStorage", app =>
            {
                app.Run(async cnt =>
                {
                    string nameFile = "extensions/SaveToSqliteStorage.js";
                    
                    var f = manifestEmbeddedProvider.GetFileInfo("blocklyFiles/" + nameFile);
                    
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
                    var m = new ReadOnlyMemory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });
            });

        }
    }
}
