using GraphQL.Types;

namespace GraphQLDemo.Repository
{
    public partial class DepartmentOGT
    {
        public class GetAllQuery : ObjectGraphType
        {
            public GetAllQuery(DepartmentRepository departmentRepository)
            {
                Field<ListGraphType<DepartmentOGT>>(
                              "departmentQuery",
                              resolve: context => departmentRepository.GetDepartment()
                          );

                Field<ListGraphType<EmployeeOGT>>(
                             "employeeQuery",
                             resolve: context => departmentRepository.GetEmployees()
                         );

                Field<DepartmentOGT>(
                    "getOneDepartment",
                    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                    resolve: context =>
                    {
                        var id = context.GetArgument<int>("id");
                        return departmentRepository.GetOneDepartment(id);
                    }
                    );
            }
        }
    }
}
