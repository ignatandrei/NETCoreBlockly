using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestBlocklyHtml.DB;

namespace TestBlocklyHtml.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DB_DepartmentsController : ControllerBase
    {
        private readonly testsContext _context;

        public DB_DepartmentsController(testsContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            //var deps = await _context.Department.ToListAsync();

            var deps = await _context.Department.AsNoTracking().Include(it => it.Employee).ToListAsync();
            deps.ForEach(dep =>
            {
                foreach (var emp in dep.Employee)
                {
                    emp.IddepartmentNavigation = null;
                }
            });
            return deps;
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(long id)
        {
            var department = await _context.Department.AsNoTracking()
                .Include(it => it.Employee).FirstOrDefaultAsync(it => it.Iddepartment == id);
            //var department = await _context.Department.FirstOrDefaultAsync(it => it.Iddepartment == id);
            if (department == null)
            {
                return NotFound();
            }
            foreach (var emp in department.Employee)
            {
                emp.IddepartmentNavigation = null;
            }
            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(long id, Department department)
        {
            if (id != department.Iddepartment)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            _context.Department.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.Iddepartment }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteDepartment(long id)
        {
            var department = await _context
                .Department
                .AsNoTracking()
                .FirstOrDefaultAsync(it=>it.Iddepartment==id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Department.Remove(department);
            await _context.SaveChangesAsync();

            return department;
        }

        private bool DepartmentExists(long id)
        {
            return _context.Department.Any(e => e.Iddepartment == id);
        }
    }
}
