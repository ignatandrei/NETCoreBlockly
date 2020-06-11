using GraphQLDemo.Models;
using GraphQLDemo.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Repository
{
    public class DepartmentRepository
    {
        private readonly GraphQLDbContext _context;

        public DepartmentRepository(GraphQLDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department> GetOneDepartment(int id)
        {
            return await _context.Department.FirstOrDefaultAsync(dep => dep.Iddepartment == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }
    }
}
