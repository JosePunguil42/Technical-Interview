using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNetCore.ModelsDC;
using ApiNetCore.DataAccess;

namespace ApiNetCore.Controllers
{
    [Route("api/Enterprise")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private readonly pr_canalesContext _context;
        private readonly EnterpriseDA _enterprise;

        public EnterprisesController(pr_canalesContext context)
        {
            _context = context;
            _enterprise = new EnterpriseDA(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Enterprise>> GetEnterprises()
        {
            return await _enterprise.GetEnterprises();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enterprise>> GetEnterprise(int id)
        {
            var enter = await _enterprise.GetEnterprise(id);
            if (enter == null)
            {
                return NotFound();
            }
            return enter;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnterprise(int id, Enterprise enterprise)
        {
            try
            {
                await _enterprise.PutEnterprise(id, enterprise);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Enterprise>> PostEnterprise(Enterprise enterprise)
        {
            await _enterprise.PostEnterprise(enterprise);
            return CreatedAtAction("GetEnterprise", new { id = enterprise.Id }, enterprise);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnterprise(int id)
        {
            var department = await _context.Enterprises.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            _enterprise.DeleteEnterprise(id);
            return NoContent();
        }
    }
}
