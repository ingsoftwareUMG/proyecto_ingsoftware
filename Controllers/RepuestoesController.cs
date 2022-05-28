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
              return _context.Repuestos != null ? 
                          View(await _context.Repuestos.ToListAsync()) :
                          Problem("Entity set 'printSmartContext.Repuestos'  is null.");
        }

        // GET: Repuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Repuestos == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuestos
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Nombre,Codigo,Modelo,Existencia,PrecioVenta,PrecioCompra")] Repuesto repuesto)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Repuestos == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuestos.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Codigo,Modelo,Existencia,PrecioVenta,PrecioCompra")] Repuesto repuesto)
        {
            if (id != repuesto.Id)
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
                    if (!RepuestoExists(repuesto.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Repuestos == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuestos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repuesto == null)
            {
                return NotFound();
            }

            return View(repuesto);
        }

        // POST: Repuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Repuestos == null)
            {
                return Problem("Entity set 'printSmartContext.Repuestos'  is null.");
            }
            var repuesto = await _context.Repuestos.FindAsync(id);
            if (repuesto != null)
            {
                _context.Repuestos.Remove(repuesto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepuestoExists(int id)
        {
          return (_context.Repuestos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
