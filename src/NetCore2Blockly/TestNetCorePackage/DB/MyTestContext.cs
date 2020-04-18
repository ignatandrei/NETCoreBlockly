using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCorePackage.DB
{
    public partial class testsContext : DbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBDepartment>().
                HasData(new DBDepartment{ Iddepartment=1,Name="IT" },            
                new DBDepartment { Iddepartment = 2, Name = "Accounting" }
                );

            modelBuilder.Entity<DBEmployee>().
                HasData(new DBEmployee { Iddepartment = 1, Name = "Person from IT", Idemployee=1 },
                new DBEmployee{ Iddepartment = 2, Name = "Person from Accounting", Idemployee=2 }
                );

          
        }
    }
}
