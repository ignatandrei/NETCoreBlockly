using GraphQL;
using GraphQL.Types;
using static TestBlocklyHtml.GraphQL.DepartmentOGT;

namespace TestBlocklyHtml.GraphQL
{
    public class DepartmentSchema : Schema
    {
        public DepartmentSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<GetAllQuery>();
        }
    }
}
