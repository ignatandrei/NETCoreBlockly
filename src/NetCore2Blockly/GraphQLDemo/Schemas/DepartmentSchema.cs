using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GraphQLDemo.Repository.DepartmentOGT;

namespace GraphQLDemo.Schemas
{
    public class DepartmentSchema : Schema
    {
        public DepartmentSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GetAllQuery>();
        }
    }
}
