using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using System;
using System.IO;
using System.Reflection;

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
        public static void UseSqliteStorage(this IApplicationBuilder appBuilder, string sqliteConnection = "blocklySqlite.db")
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
                    // TODO: do something with the result
                    var m = new Memory<byte>(result);
                    await cnt.Response.BodyWriter.WriteAsync(m);
                });
            });

        }
    }
}
