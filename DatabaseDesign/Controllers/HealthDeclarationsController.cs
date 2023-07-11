using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseDesign.Data;
using DatabaseDesign.Models;

namespace DatabaseDesign.Controllers
{
    public class HealthDeclarationsController : Controller
    {
        private readonly DatabaseDesignContext _context;

        public HealthDeclarationsController(DatabaseDesignContext context)
        {
            _context = context;
        }

        //GET: HealthDeclarations
        public async Task<IActionResult> Index()
        {
              return _context.HealthDeclaration != null ? 
                          View(await _context.HealthDeclaration.ToListAsync()) :
                          Problem("Entity set 'DatabaseDesignContext.HealthDeclaration'  is null.");
        }

        // GET: HealthDeclarations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HealthDeclaration == null)
            {
                return NotFound();
            }

            var healthDeclaration = await _context.HealthDeclaration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthDeclaration == null)
            {
                return NotFound();
            }

            return View(healthDeclaration);
        }

        // GET: HealthDeclarations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthDeclarations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BusinessEmail,CompanyName,Designation,BusinessNumber,LicensePlate,NRIC,QuarantineOrder,CloseContact,Fever,Agreement")] HealthDeclaration healthDeclaration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthDeclaration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthDeclaration);
        }

        // GET: HealthDeclarations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HealthDeclaration == null)
            {
                return NotFound();
            }

            var healthDeclaration = await _context.HealthDeclaration.FindAsync(id);
            if (healthDeclaration == null)
            {
                return NotFound();
            }
            return View(healthDeclaration);
        }

        // POST: HealthDeclarations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BusinessEmail,CompanyName,Designation,BusinessNumber,LicensePlate,NRIC,QuarantineOrder,CloseContact,Fever,Agreement")] HealthDeclaration healthDeclaration)
        {
            if (id != healthDeclaration.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthDeclaration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthDeclarationExists(healthDeclaration.Id))
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
            return View(healthDeclaration);
        }

        // GET: HealthDeclarations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HealthDeclaration == null)
            {
                return NotFound();
            }

            var healthDeclaration = await _context.HealthDeclaration
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthDeclaration == null)
            {
                return NotFound();
            }

            return View(healthDeclaration);
        }

        // POST: HealthDeclarations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HealthDeclaration == null)
            {
                return Problem("Entity set 'DatabaseDesignContext.HealthDeclaration'  is null.");
            }
            var healthDeclaration = await _context.HealthDeclaration.FindAsync(id);
            if (healthDeclaration != null)
            {
                _context.HealthDeclaration.Remove(healthDeclaration);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthDeclarationExists(int id)
        {
          return (_context.HealthDeclaration?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
