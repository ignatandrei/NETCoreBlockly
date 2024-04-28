using GraphQL;
using GraphQL.Types;

namespace TestBlocklyHtml.GraphQL
{
    public partial class DepartmentOGT
    {
        public class GetAllQuery : ObjectGraphType
        {
            public GetAllQuery(DepartmentRepository departmentRepository)
            {
                //TODO : graphql

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

                FieldAsync< ListGraphType<EmployeeOGT>>(
                    "getEmployeeAfterName",
                    arguments: new QueryArguments(
                        new QueryArgument<StringGraphType> { Name = "employeeName" },
                        new QueryArgument<StringGraphType> { Name = "departmentName" }

                        ),
                    resolve:async  context =>
                    {
                        var empName = context.GetArgument<string>("employeeName");
                        var depName = context.GetArgument<string>("departmentName");
                        return await departmentRepository.GetEmployeesAfterName(empName,depName);
                    }
                    );

            }
        }
    }
}
