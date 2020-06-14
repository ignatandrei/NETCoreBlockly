using GraphQL.Types;
using TestBlocklyHtml.DB;

namespace TestBlocklyHtml.GraphQL
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
