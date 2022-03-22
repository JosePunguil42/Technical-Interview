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
    public class DepartmentsController : Controller
    {
        private readonly pr_canalesContext _context;
        private readonly IDepartment srvDepartment;

        public DepartmentsController(pr_canalesContext context)
        {
            _context = context;
            this.srvDepartment = new SrvDepartment();
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await srvDepartment.GetDepartments());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmen = await srvDepartment.GetDepartment(id);
            if (departmen == null)
            {
                return NotFound();
            }

            return View(departmen);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusDep,DescriptionDep,NameDep,Phone,IdEnterprise")] Department department)
        {
            if (ModelState.IsValid)
            {
                await srvDepartment.SaveDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await srvDepartment.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusDep,DescriptionDep,NameDep,Phone,IdEnterprise")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await srvDepartment.UpdateDepartment(id, department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await srvDepartment.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await srvDepartment.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
