using GraphQL.Types;
using GraphQLDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Repository
{
    public partial class DepartmentOGT : ObjectGraphType<Department>
    {
        public DepartmentOGT()
        {
            Field(f => f.Iddepartment);
            Field(f => f.Name);
        }
    }
}
