using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore.ModelsDC;

namespace WebCore.Controllers
{
    public class DepartmentsEmployeesController : Controller
    {
        private readonly pr_canalesContext _context;

        public DepartmentsEmployeesController(pr_canalesContext context)
        {
            _context = context;
        }

        // GET: DepartmentsEmployees
        public async Task<IActionResult> Index()
        {
            var pr_canalesContext = _context.DepartmentsEmployees.Include(d => d.IdDepartmentNavigation).Include(d => d.IdEmployeeNavigation);
            return View(await pr_canalesContext.ToListAsync());
        }

        // GET: DepartmentsEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentsEmployee = await _context.DepartmentsEmployees
                .Include(d => d.IdDepartmentNavigation)
                .Include(d => d.IdEmployeeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsEmployee == null)
            {
                return NotFound();
            }

            return View(departmentsEmployee);
        }

        // GET: DepartmentsEmployees/Create
        public IActionResult Create()
        {
            ViewData["IdDepartment"] = new SelectList(_context.Departments, "Id", "Id");
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: DepartmentsEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusDep,IdDepartment,IdEmployee")] DepartmentsEmployee departmentsEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentsEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartment"] = new SelectList(_context.Departments, "Id", "Id", departmentsEmployee.IdDepartment);
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id", departmentsEmployee.IdEmployee);
            return View(departmentsEmployee);
        }

        // GET: DepartmentsEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentsEmployee = await _context.DepartmentsEmployees.FindAsync(id);
            if (departmentsEmployee == null)
            {
                return NotFound();
            }
            ViewData["IdDepartment"] = new SelectList(_context.Departments, "Id", "Id", departmentsEmployee.IdDepartment);
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id", departmentsEmployee.IdEmployee);
            return View(departmentsEmployee);
        }

        // POST: DepartmentsEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusDep,IdDepartment,IdEmployee")] DepartmentsEmployee departmentsEmployee)
        {
            if (id != departmentsEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentsEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentsEmployeeExists(departmentsEmployee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDepartment"] = new SelectList(_context.Departments, "Id", "Id", departmentsEmployee.IdDepartment);
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "Id", "Id", departmentsEmployee.IdEmployee);
            return View(departmentsEmployee);
        }

        // GET: DepartmentsEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentsEmployee = await _context.DepartmentsEmployees
                .Include(d => d.IdDepartmentNavigation)
                .Include(d => d.IdEmployeeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsEmployee == null)
            {
                return NotFound();
            }

            return View(departmentsEmployee);
        }

        // POST: DepartmentsEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentsEmployee = await _context.DepartmentsEmployees.FindAsync(id);
            _context.DepartmentsEmployees.Remove(departmentsEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsEmployeeExists(int id)
        {
            return _context.DepartmentsEmployees.Any(e => e.Id == id);
        }
    }
}
