using GraphQL.Types;
using TestBlocklyHtml.DB;

namespace TestBlocklyHtml.GraphQL
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
