using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBlocklyHtml.DB;

namespace TestBlocklyHtml.GraphQL
{
    public class DepartmentRepository
    {
        private readonly testsContext _context;

        public DepartmentRepository(testsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {

            var items= await _context.Department.ToArrayAsync();
            return items;
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
