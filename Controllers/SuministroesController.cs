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
    public class SuministroesController : Controller
    {
        private readonly AplicationDbContext _context;

        public SuministroesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suministroes
        public async Task<IActionResult> Index()
        {
            var printSmartContext = _context.Suministros.Include(s => s.IdMarcaNavigation).Include(s => s.IdTipoNavigation);
            return View(await printSmartContext.ToListAsync());
        }

        // GET: Suministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Suministros == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministros
                .Include(s => s.IdMarcaNavigation)
                .Include(s => s.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suministro == null)
            {
                return NotFound();
            }

            return View(suministro);
        }

        // GET: Suministroes/Create
        public IActionResult Create()
        {
            ViewData["IdMarca"] = new SelectList(_context.MarcaSuministros, "Id", "Marca");
            ViewData["IdTipo"] = new SelectList(_context.TipoSuministros, "Id", "NombreTipo");
            return View();
        }

        // POST: Suministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdMarca,IdTipo,Modelo,Existencia,PrecioCompra,PrecioVenta")] Suministro suministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.MarcaSuministros, "Id", "Marca", suministro.IdMarca);
            ViewData["IdTipo"] = new SelectList(_context.TipoSuministros, "Id", "NombreTipo", suministro.IdTipo);
            return View(suministro);
        }

        // GET: Suministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Suministros == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministros.FindAsync(id);
            if (suministro == null)
            {
                return NotFound();
            }
            ViewData["IdMarca"] = new SelectList(_context.MarcaSuministros, "Id", "Marca", suministro.IdMarca);
            ViewData["IdTipo"] = new SelectList(_context.TipoSuministros, "Id", "NombreTipo", suministro.IdTipo);
            return View(suministro);
        }

        // POST: Suministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,IdMarca,IdTipo,Modelo,Existencia,PrecioCompra,PrecioVenta")] Suministro suministro)
        {
            if (id != suministro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuministroExists(suministro.Id))
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
            ViewData["IdMarca"] = new SelectList(_context.MarcaSuministros, "Id", "Marca", suministro.IdMarca);
            ViewData["IdTipo"] = new SelectList(_context.TipoSuministros, "Id", "NombreTipo", suministro.IdTipo);
            return View(suministro);
        }

        // GET: Suministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Suministros == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministros
                .Include(s => s.IdMarcaNavigation)
                .Include(s => s.IdTipoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suministro == null)
            {
                return NotFound();
            }

            return View(suministro);
        }

        // POST: Suministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Suministros == null)
            {
                return Problem("Entity set 'printSmartContext.Suministros'  is null.");
            }
            var suministro = await _context.Suministros.FindAsync(id);
            if (suministro != null)
            {
                _context.Suministros.Remove(suministro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuministroExists(int id)
        {
          return (_context.Suministros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
