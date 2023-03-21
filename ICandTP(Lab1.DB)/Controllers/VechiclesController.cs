using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICandTP_Lab1.DB_;

namespace ICandTP_Lab1.DB_.Controllers
{
    public class VechiclesController : Controller
    {
        private readonly DbcarsSearchContext _context;

        public VechiclesController(DbcarsSearchContext context)
        {
            _context = context;
        }

        // GET: Vechicles
        public async Task<IActionResult> Index()
        {
            var dbcarsSearchContext = _context.Vechicles.Include(v => v.Insuarence).Include(v => v.Model).Include(v => v.OwnerTinNavigation);
            return View(await dbcarsSearchContext.ToListAsync());
        }

        // GET: Vechicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vechicles == null)
            {
                return NotFound();
            }

            var vechicle = await _context.Vechicles
                .Include(v => v.Insuarence)
                .Include(v => v.Model)
                .Include(v => v.OwnerTinNavigation)
                .FirstOrDefaultAsync(m => m.Vin == id);
            if (vechicle == null)
            {
                return NotFound();
            }

            return View(vechicle);
        }

        // GET: Vechicles/CreateІ
        public IActionResult Create()
        {
            ViewData["InsuarenceId"] = new SelectList(_context.Insuarences, "Id", "Id");
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id");
            ViewData["OwnerTin"] = new SelectList(_context.Owners, "Tin", "Tin");
            return View();
        }

        // POST: Vechicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vin,EngineCapacity,ModelId,InsuarenceId,PlateNum,DateOfIssue,OwnerTin")] Vechicle vechicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vechicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuarenceId"] = new SelectList(_context.Insuarences, "Id", "Id", vechicle.InsuarenceId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id", vechicle.ModelId);
            ViewData["OwnerTin"] = new SelectList(_context.Owners, "Tin", "Tin", vechicle.OwnerTin);
            return View(vechicle);
        }

        // GET: Vechicles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Vechicles == null)
            {
                return NotFound();
            }

            var vechicle = await _context.Vechicles.FindAsync(id);
            if (vechicle == null)
            {
                return NotFound();
            }
            ViewData["InsuarenceId"] = new SelectList(_context.Insuarences, "Id", "Id", vechicle.InsuarenceId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id", vechicle.ModelId);
            ViewData["OwnerTin"] = new SelectList(_context.Owners, "Tin", "Tin", vechicle.OwnerTin);
            return View(vechicle);
        }

        // POST: Vechicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Vin,EngineCapacity,ModelId,InsuarenceId,PlateNum,DateOfIssue,OwnerTin")] Vechicle vechicle)
        {
            if (id != vechicle.Vin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vechicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VechicleExists(vechicle.Vin))
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
            ViewData["InsuarenceId"] = new SelectList(_context.Insuarences, "Id", "Id", vechicle.InsuarenceId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Id", vechicle.ModelId);
            ViewData["OwnerTin"] = new SelectList(_context.Owners, "Tin", "Tin", vechicle.OwnerTin);
            return View(vechicle);
        }

        // GET: Vechicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vechicles == null)
            {
                return NotFound();
            }

            var vechicle = await _context.Vechicles
                .Include(v => v.Insuarence)
                .Include(v => v.Model)
                .Include(v => v.OwnerTinNavigation)
                .FirstOrDefaultAsync(m => m.Vin == id);
            if (vechicle == null)
            {
                return NotFound();
            }

            return View(vechicle);
        }

        // POST: Vechicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vechicles == null)
            {
                return Problem("Entity set 'DbcarsSearchContext.Vechicles'  is null.");
            }
            var vechicle = await _context.Vechicles.FindAsync(id);
            if (vechicle != null)
            {
                _context.Vechicles.Remove(vechicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VechicleExists(string id)
        {
          return (_context.Vechicles?.Any(e => e.Vin == id)).GetValueOrDefault();
        }
    }
}
