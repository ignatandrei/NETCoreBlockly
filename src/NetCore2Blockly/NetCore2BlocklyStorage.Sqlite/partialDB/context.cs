using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore2BlocklyStorage.Sqlite.ModelsDB
{
    /// <summary>
    /// see below the scaffolded string
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    partial class blocklyCategContext
    {
        private readonly string connection;

        //Scaffold-DbContext 'Data Source=.;Initial Catalog=blocklyCateg;UID=sa;PWD=<YourStrong@Passw0rd>' Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsDB  -DataAnnotations -force
        public blocklyCategContext(string connection)
        {
            this.connection = connection;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connection);
        public async Task<int> CreateDb()
        {
            await this.Database.EnsureCreatedAsync();
            var m = new Messages();
            m.Date = DateTime.UtcNow;
            m.Message = "starting";
            this.Messages.Add(m);
            return await this.SaveChangesAsync();
        }
    }
}
