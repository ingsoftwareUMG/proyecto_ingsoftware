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
    public class RepuestoesController : Controller
    {
        private readonly AplicationDbContext _context;

        public RepuestoesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Repuestoes
        public async Task<IActionResult> Index()
        {
              return _context.Repuesto != null ? 
                          View(await _context.Repuesto.ToListAsync()) :
                          Problem("Entity set 'AplicationDbContext.Repuesto'  is null.");
        }

        // GET: Repuestoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Repuesto == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuesto
                .FirstOrDefaultAsync(m => m.IdRepuesto == id);
            if (repuesto == null)
            {
                return NotFound();
            }

            return View(repuesto);
        }

        // GET: Repuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRepuesto,Nombre,Precio,Estado")] Repuesto repuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repuesto);
        }

        // GET: Repuestoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Repuesto == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuesto.FindAsync(id);
            if (repuesto == null)
            {
                return NotFound();
            }
            return View(repuesto);
        }

        // POST: Repuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdRepuesto,Nombre,Precio,Estado")] Repuesto repuesto)
        {
            if (id != repuesto.IdRepuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepuestoExists(repuesto.IdRepuesto))
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
            return View(repuesto);
        }

        // GET: Repuestoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Repuesto == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuesto
                .FirstOrDefaultAsync(m => m.IdRepuesto == id);
            if (repuesto == null)
            {
                return NotFound();
            }

            return View(repuesto);
        }

        // POST: Repuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Repuesto == null)
            {
                return Problem("Entity set 'AplicationDbContext.Repuesto'  is null.");
            }
            var repuesto = await _context.Repuesto.FindAsync(id);
            if (repuesto != null)
            {
                _context.Repuesto.Remove(repuesto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepuestoExists(long id)
        {
          return (_context.Repuesto?.Any(e => e.IdRepuesto == id)).GetValueOrDefault();
        }
    }
}
