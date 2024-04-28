using GraphQL;
using GraphQL.Types;
using System;
using static TestBlocklyHtml.GraphQL.DepartmentOGT;

namespace TestBlocklyHtml.GraphQL
{
    public class DepartmentSchema : Schema
    {
        public DepartmentSchema(IServiceProvider resolver) : base(resolver)
        {
            //TODO : graphql

            //Query = resolver.GetService< IDependencyResolver>.Resolve<GetAllQuery>();
            //Mutation = resolver.Resolve<Mutations>();
        }
    }
}
