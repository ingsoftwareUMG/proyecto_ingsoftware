using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using printSmart.data;
using printSmart.Models;

namespace printSmart.Controllers
{
    public class MarcaPcsController : Controller
    {
        private readonly AplicationDbContext _context;

        public MarcaPcsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: MarcaPcs
        public async Task<IActionResult> Index()
        {
              return _context.MarcaPcs != null ? 
                          View(await _context.MarcaPcs.ToListAsync()) :
                          Problem("Entity set 'printSmartContext.MarcaPcs'  is null.");
        }

        // GET: MarcaPcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MarcaPcs == null)
            {
                return NotFound();
            }

            var marcaPc = await _context.MarcaPcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaPc == null)
            {
                return NotFound();
            }

            return View(marcaPc);
        }

        // GET: MarcaPcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaPcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] MarcaPc marcaPc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaPc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaPc);
        }

        // GET: MarcaPcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MarcaPcs == null)
            {
                return NotFound();
            }

            var marcaPc = await _context.MarcaPcs.FindAsync(id);
            if (marcaPc == null)
            {
                return NotFound();
            }
            return View(marcaPc);
        }

        // POST: MarcaPcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] MarcaPc marcaPc)
        {
            if (id != marcaPc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaPc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaPcExists(marcaPc.Id))
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
            return View(marcaPc);
        }

        // GET: MarcaPcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MarcaPcs == null)
            {
                return NotFound();
            }

            var marcaPc = await _context.MarcaPcs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaPc == null)
            {
                return NotFound();
            }

            return View(marcaPc);
        }

        // POST: MarcaPcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MarcaPcs == null)
            {
                return Problem("Entity set 'printSmartContext.MarcaPcs'  is null.");
            }
            var marcaPc = await _context.MarcaPcs.FindAsync(id);
            if (marcaPc != null)
            {
                _context.MarcaPcs.Remove(marcaPc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaPcExists(int id)
        {
          return (_context.MarcaPcs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
