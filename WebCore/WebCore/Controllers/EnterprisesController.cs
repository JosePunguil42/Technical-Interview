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
    public class EnterprisesController : Controller
    {
        private readonly pr_canalesContext _context;
        private readonly IEnterprise srvEnterprise;

        public EnterprisesController(pr_canalesContext context)
        {
            _context = context;
            this.srvEnterprise = new SrvEnterprise();
        }

        public async Task<IActionResult> Index()
        {
            return View(await srvEnterprise.GetEnterprises());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var enterprise = await srvEnterprise.GetEnterprise(id);
            if (enterprise == null)
            {
                return NotFound();
            }
            return View(enterprise);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusEnt,AddressEnt,NameEnt,Phone")] Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                await srvEnterprise.SaveEnterprise(enterprise);
                return RedirectToAction(nameof(Index));
            }
            return View(enterprise);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var enterprise = await srvEnterprise.GetEnterprise(id);
            if (enterprise == null)
            {
                return NotFound();
            }
            return View(enterprise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreatedBy,CreateDate,ModifiedBy,ModifiedDate,StatusEnt,AddressEnt,NameEnt,Phone")] Enterprise enterprise)
        {
            if (id != enterprise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await srvEnterprise.UpdateEnterprise(id, enterprise);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enterprise);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise = await srvEnterprise.GetEnterprise(id);
            if (enterprise == null)
            {
                return NotFound();
            }

            return View(enterprise);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await srvEnterprise.DeleteEnterprise(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
