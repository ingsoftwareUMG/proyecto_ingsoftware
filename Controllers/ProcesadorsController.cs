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
    public class ProcesadorsController : Controller
    {
        private readonly AplicationDbContext _context;

        public ProcesadorsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Procesadors
        public async Task<IActionResult> Index()
        {
              return _context.Procesadors != null ? 
                          View(await _context.Procesadors.ToListAsync()) :
                          Problem("Entity set 'printSmartContext.Procesadors'  is null.");
        }

        // GET: Procesadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procesadors == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // GET: Procesadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procesadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Procesador procesador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesador);
        }

        // GET: Procesadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procesadors == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesadors.FindAsync(id);
            if (procesador == null)
            {
                return NotFound();
            }
            return View(procesador);
        }

        // POST: Procesadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Procesador procesador)
        {
            if (id != procesador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesadorExists(procesador.Id))
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
            return View(procesador);
        }

        // GET: Procesadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procesadors == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesadors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // POST: Procesadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procesadors == null)
            {
                return Problem("Entity set 'printSmartContext.Procesadors'  is null.");
            }
            var procesador = await _context.Procesadors.FindAsync(id);
            if (procesador != null)
            {
                _context.Procesadors.Remove(procesador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesadorExists(int id)
        {
          return (_context.Procesadors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
