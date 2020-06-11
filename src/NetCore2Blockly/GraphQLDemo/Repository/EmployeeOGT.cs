using GraphQL.Types;
using GraphQLDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Repository
{
    public class EmployeeOGT : ObjectGraphType<Employee>
    {
        public EmployeeOGT()
        {
            Field(f => f.Idemployee);
            Field(f => f.Name);
        }

    }
}
