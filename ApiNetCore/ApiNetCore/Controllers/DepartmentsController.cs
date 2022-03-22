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
    [Route("api/Department")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly pr_canalesContext _context;
        private readonly DepartmentDA departments;
        public DepartmentsController(pr_canalesContext context)
        {
            _context = context;
            departments = new DepartmentDA(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await departments.GetDepartments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await departments.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return department;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, Department department) //ID, epartment.Id, IdEnterprise
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            try
            {
                await departments.PutDepartment(id, department);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            await departments.PostDepartment(department);
            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            departments.DeleteDepartment(id);
            return NoContent();
        }
    }
}
