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
    public class SistemaOperativoesController : Controller
    {
        private readonly AplicationDbContext _context;

        public SistemaOperativoesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: SistemaOperativoes
        public async Task<IActionResult> Index()
        {
              return _context.SistemaOperativos != null ? 
                          View(await _context.SistemaOperativos.ToListAsync()) :
                          Problem("Entity set 'printSmartContext.SistemaOperativos'  is null.");
        }

        // GET: SistemaOperativoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SistemaOperativos == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }

            return View(sistemaOperativo);
        }

        // GET: SistemaOperativoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SistemaOperativoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] SistemaOperativo sistemaOperativo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistemaOperativo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistemaOperativo);
        }

        // GET: SistemaOperativoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SistemaOperativos == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativos.FindAsync(id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }
            return View(sistemaOperativo);
        }

        // POST: SistemaOperativoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] SistemaOperativo sistemaOperativo)
        {
            if (id != sistemaOperativo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistemaOperativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemaOperativoExists(sistemaOperativo.Id))
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
            return View(sistemaOperativo);
        }

        // GET: SistemaOperativoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SistemaOperativos == null)
            {
                return NotFound();
            }

            var sistemaOperativo = await _context.SistemaOperativos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sistemaOperativo == null)
            {
                return NotFound();
            }

            return View(sistemaOperativo);
        }

        // POST: SistemaOperativoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SistemaOperativos == null)
            {
                return Problem("Entity set 'printSmartContext.SistemaOperativos'  is null.");
            }
            var sistemaOperativo = await _context.SistemaOperativos.FindAsync(id);
            if (sistemaOperativo != null)
            {
                _context.SistemaOperativos.Remove(sistemaOperativo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemaOperativoExists(int id)
        {
          return (_context.SistemaOperativos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
