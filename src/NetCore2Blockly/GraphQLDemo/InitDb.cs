using GraphQLDemo.Models;
using GraphQLDemo.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo
{
    public class InitDb
    {
         public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GraphQLDbContext(serviceProvider.GetRequiredService<DbContextOptions<GraphQLDbContext>>()))
            {
                if (context.Department.Any())
                {
                    return; //db already initialized
                }

                context.Department.AddRange(
                    new Department { Iddepartment = 1, Name = "IT" },
                    new Department { Iddepartment = 2, Name = "Accounting" }


                    );
                context.SaveChanges();
            }
        }
    }
}
