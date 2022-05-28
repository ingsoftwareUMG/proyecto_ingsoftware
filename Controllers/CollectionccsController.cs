using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using printSmart.Models;
using printSmart.data;
namespace printSmart.Controllers
{
    public class CollectionccsController : Controller
    {
        private readonly AplicationDbContext _context;

        public CollectionccsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Collectionccs
        public async Task<IActionResult> Index()
        {
            var printSmartContext = _context.Collectionccs.Include(c => c.IdCostumerNavigation);
            return View(await printSmartContext.ToListAsync());
        }

        // GET: Collectionccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Collectionccs == null)
            {
                return NotFound();
            }

            var collectioncc = await _context.Collectionccs
                .Include(c => c.IdCostumerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectioncc == null)
            {
                return NotFound();
            }

            return View(collectioncc);
        }

        // GET: Collectionccs/Create
        public IActionResult Create()
        {
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name");
            return View();
        }

        // POST: Collectionccs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Description,IdCostumer")] Collectioncc collectioncc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectioncc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name", collectioncc.IdCostumer);
            return View(collectioncc);
        }

        // GET: Collectionccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Collectionccs == null)
            {
                return NotFound();
            }

            var collectioncc = await _context.Collectionccs.FindAsync(id);
            if (collectioncc == null)
            {
                return NotFound();
            }
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name", collectioncc.IdCostumer);
            return View(collectioncc);
        }

        // POST: Collectionccs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Description,IdCostumer")] Collectioncc collectioncc)
        {
            if (id != collectioncc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectioncc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionccExists(collectioncc.Id))
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
            ViewData["IdCostumer"] = new SelectList(_context.Costumers, "Id", "Name", collectioncc.IdCostumer);
            return View(collectioncc);
        }

        // GET: Collectionccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Collectionccs == null)
            {
                return NotFound();
            }

            var collectioncc = await _context.Collectionccs
                .Include(c => c.IdCostumerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collectioncc == null)
            {
                return NotFound();
            }

            return View(collectioncc);
        }

        // POST: Collectionccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Collectionccs == null)
            {
                return Problem("Entity set 'printSmartContext.Collectionccs'  is null.");
            }
            var collectioncc = await _context.Collectionccs.FindAsync(id);
            if (collectioncc != null)
            {
                _context.Collectionccs.Remove(collectioncc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectionccExists(int id)
        {
          return (_context.Collectionccs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
