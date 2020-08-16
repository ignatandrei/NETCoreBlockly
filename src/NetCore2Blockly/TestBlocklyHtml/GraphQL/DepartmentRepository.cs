
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlocklyHtml.DB;

namespace TestBlocklyHtml.GraphQL
{
    /// <summary>
    /// Repository for DB interaction for GraphQL
    /// </summary>
    public class DepartmentRepository
    {
        private readonly testsContext _context;

        public DepartmentRepository(testsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {

            var items= await _context.Department.AsQueryable().ToArrayAsync();
            return items;
        }

        public async Task<Department> GetOneDepartment(int id)
        {
            return await _context.Department
                .AsQueryable()
                .FirstOrDefaultAsync(dep => dep.Iddepartment == id);
        }

        //Shoud return maybe the success or failure of operation
        public async Task<int> AddDepartment(Department department)
        {
            using (var transaction = _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Department.Add(department);
                    await _context.SaveChangesAsync();
                    await transaction.Result.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.Result.RollbackAsync();
                    throw ex;
                }
            }
            return -1;// never do that. :)
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employee.AsQueryable().ToListAsync();
        }

        internal Task<Employee[]> GetEmployeesAfterName(string empName, string depName)
        {
            var data = _context.Employee.AsQueryable();
            if(!string.IsNullOrWhiteSpace(empName))
            {
                data = data.Where(it => it.Name.Contains(empName));
            }
            if (!string.IsNullOrWhiteSpace(depName))
            {
                data = data.Where(it => it.Name.Contains(depName));
            }
            return data.AsQueryable().ToArrayAsync();
        }
    }
}
