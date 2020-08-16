using GraphQL.Types;

namespace TestBlocklyHtml.GraphQL
{
    /*
     * It will be used as an input type. In our case, the input will be the department name.
     */
    public class DepartmentInputType : InputObjectGraphType
    {
        public DepartmentInputType()
        {
            Name = "departmentInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}