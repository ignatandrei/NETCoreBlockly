using GraphQL.Types;

namespace TestBlocklyHtml.GraphQL
{
    public class DepartmentInputType : InputObjectGraphType
    {
        public DepartmentInputType()
        {
            Name = "departmentInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}