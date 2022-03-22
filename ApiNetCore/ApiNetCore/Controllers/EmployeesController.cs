using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNetCore.ModelsDC;
using ApiNetCore.DataAccess;

namespace ApiNetCore.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly pr_canalesContext _context;
        private readonly EmployeeDA _employee;

        public EmployeesController(pr_canalesContext context)
        {
            _context = context;
            _employee = new EmployeeDA(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employee.GetEmployees();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var department = await _employee.GetEmployee(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            try
            {
                await _employee.PutEmployee(id, employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employee.PostEmployee(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var department = await _context.Employees.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            _employee.DeleteEmployee(id);
            return NoContent();
        }
    }
}
