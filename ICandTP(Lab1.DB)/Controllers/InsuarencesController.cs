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
    public class InsuarencesController : Controller
    {
        private readonly DbcarsSearchContext _context;

        public InsuarencesController(DbcarsSearchContext context)
        {
            _context = context;
        }

        // GET: Insuarences
        public async Task<IActionResult> Index()
        {
              return _context.Insuarences != null ? 
                          View(await _context.Insuarences.ToListAsync()) :
                          Problem("Entity set 'DbcarsSearchContext.Insuarences'  is null.");
        }

        // GET: Insuarences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insuarences == null)
            {
                return NotFound();
            }

            var insuarence = await _context.Insuarences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuarence == null)
            {
                return NotFound();
            }

            return View(insuarence);
        }

        // GET: Insuarences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insuarences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IssueDate,ExpirationDate,VechicleVin,Type")] Insuarence insuarence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuarence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuarence);
        }

        // GET: Insuarences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Insuarences == null)
            {
                return NotFound();
            }

            var insuarence = await _context.Insuarences.FindAsync(id);
            if (insuarence == null)
            {
                return NotFound();
            }
            return View(insuarence);
        }

        // POST: Insuarences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IssueDate,ExpirationDate,VechicleVin,Type")] Insuarence insuarence)
        {
            if (id != insuarence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuarence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuarenceExists(insuarence.Id))
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
            return View(insuarence);
        }

        // GET: Insuarences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insuarences == null)
            {
                return NotFound();
            }

            var insuarence = await _context.Insuarences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuarence == null)
            {
                return NotFound();
            }

            return View(insuarence);
        }

        // POST: Insuarences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insuarences == null)
            {
                return Problem("Entity set 'DbcarsSearchContext.Insuarences'  is null.");
            }
            var insuarence = await _context.Insuarences.FindAsync(id);
            if (insuarence != null)
            {
                _context.Insuarences.Remove(insuarence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuarenceExists(int id)
        {
          return (_context.Insuarences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
