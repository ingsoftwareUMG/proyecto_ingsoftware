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
    public class TipoSuministroesController : Controller
    {
        private readonly AplicationDbContext _context;

        public TipoSuministroesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoSuministroes
        public async Task<IActionResult> Index()
        {
              return _context.TipoSuministros != null ? 
                          View(await _context.TipoSuministros.ToListAsync()) :
                          Problem("Entity set 'printSmartContext.TipoSuministros'  is null.");
        }

        // GET: TipoSuministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoSuministros == null)
            {
                return NotFound();
            }

            var tipoSuministro = await _context.TipoSuministros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoSuministro == null)
            {
                return NotFound();
            }

            return View(tipoSuministro);
        }

        // GET: TipoSuministroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSuministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreTipo")] TipoSuministro tipoSuministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSuministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSuministro);
        }

        // GET: TipoSuministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoSuministros == null)
            {
                return NotFound();
            }

            var tipoSuministro = await _context.TipoSuministros.FindAsync(id);
            if (tipoSuministro == null)
            {
                return NotFound();
            }
            return View(tipoSuministro);
        }

        // POST: TipoSuministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreTipo")] TipoSuministro tipoSuministro)
        {
            if (id != tipoSuministro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSuministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSuministroExists(tipoSuministro.Id))
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
            return View(tipoSuministro);
        }

        // GET: TipoSuministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoSuministros == null)
            {
                return NotFound();
            }

            var tipoSuministro = await _context.TipoSuministros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoSuministro == null)
            {
                return NotFound();
            }

            return View(tipoSuministro);
        }

        // POST: TipoSuministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoSuministros == null)
            {
                return Problem("Entity set 'printSmartContext.TipoSuministros'  is null.");
            }
            var tipoSuministro = await _context.TipoSuministros.FindAsync(id);
            if (tipoSuministro != null)
            {
                _context.TipoSuministros.Remove(tipoSuministro);
                
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSuministroExists(int id)
        {
          return (_context.TipoSuministros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
