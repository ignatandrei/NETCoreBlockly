using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var existCategory =await GetTopCategory();
            if(existCategory == null)
            {
                existCategory = new Category()
                {
                    Name = "Top"
                    
                };

                this.Category.Add(existCategory);
            }
            return await this.SaveChangesAsync();
        }
        public async Task<Category> GetTopCategory()
        {
            var parentCategories= await Category.Where(it => it.Idparent == null).ToArrayAsync();
            if (parentCategories.Length == 1)
                return parentCategories[0];

            return null;
        }
        private async Task<IQueryable<Blocks>> BlocksCategory()
        {
            var top = await GetTopCategory();
            var id = top.Id;
            return this.Blocks.Where(it => it.Idcategory == id);
        }
        public async Task<int> Length()
        {
            var b = await BlocksCategory();
            return await b.CountAsync();
        }

        public async Task<Blocks> Get(int key)
        {
            var b = await BlocksCategory();
            return await b.FirstOrDefaultAsync(b => b.Id == key);
        }
        public async Task<Blocks> Set(int key, Blocks b)
        {
            var top = await GetTopCategory();
            b.Idcategory = top.Id;
            var exists = await Get(key);
            if(exists == null)
            {
                exists = b;
                this.Add(b);
            }
            exists.CopyPropsFrom(b);
            await this.SaveChangesAsync();
            return exists;
        } 
        public async Task<Blocks[]> data()
        {
            var b = await BlocksCategory();
            return await b.ToArrayAsync();
        }
    }
}
