using GraphQL.Types;
using GraphQLDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Repository
{
    public class DepartmentOGT : ObjectGraphType<Department>
    {
        public DepartmentOGT()
        {
            Field(f => f.Iddepartment);
            Field(f => f.Name);
        }

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
            }
        }
    }
}
