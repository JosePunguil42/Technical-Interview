using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNetCore.ModelsDC;

namespace ApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsEmployeesController : ControllerBase
    {
        private readonly pr_canalesContext _context;

        public DepartmentsEmployeesController(pr_canalesContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentsEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentsEmployee>>> GetDepartmentsEmployees()
        {
            return await _context.DepartmentsEmployees.ToListAsync();
        }

        // GET: api/DepartmentsEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentsEmployee>> GetDepartmentsEmployee(int id)
        {
            var departmentsEmployee = await _context.DepartmentsEmployees.FindAsync(id);

            if (departmentsEmployee == null)
            {
                return NotFound();
            }

            return departmentsEmployee;
        }

        // PUT: api/DepartmentsEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentsEmployee(int id, DepartmentsEmployee departmentsEmployee)
        {
            if (id != departmentsEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentsEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentsEmployeeExists(id))
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

        // POST: api/DepartmentsEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentsEmployee>> PostDepartmentsEmployee(DepartmentsEmployee departmentsEmployee)
        {
            _context.DepartmentsEmployees.Add(departmentsEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentsEmployee", new { id = departmentsEmployee.Id }, departmentsEmployee);
        }

        // DELETE: api/DepartmentsEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentsEmployee(int id)
        {
            var departmentsEmployee = await _context.DepartmentsEmployees.FindAsync(id);
            if (departmentsEmployee == null)
            {
                return NotFound();
            }

            _context.DepartmentsEmployees.Remove(departmentsEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentsEmployeeExists(int id)
        {
            return _context.DepartmentsEmployees.Any(e => e.Id == id);
        }
    }
}
