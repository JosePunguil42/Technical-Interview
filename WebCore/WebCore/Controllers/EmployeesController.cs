using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore.ModelsDC;
using WebCore.Services;

namespace WebCore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly pr_canalesContext _context;
        private readonly IEmployee srvEmployee;

        public EmployeesController(pr_canalesContext context)
        {
            _context = context;
            this.srvEmployee = new SrvEmployee();
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await srvEmployee.GetEmployees());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await srvEmployee.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusEmp,Age,Email,NameEmp,Position,Surname")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await srvEmployee.SaveEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await srvEmployee.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusEmp,Age,Email,NameEmp,Position,Surname")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await srvEmployee.UpdateEmployee(id, employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await srvEmployee.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await srvEmployee.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
