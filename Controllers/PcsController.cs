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
    public class PcsController : Controller
    {
        private readonly AplicationDbContext _context;

        public PcsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pcs
        public async Task<IActionResult> Index()
        {
            var printSmartContext = _context.Pcs.Include(p => p.Marca).Include(p => p.Procesador).Include(p => p.SistemaOp);
            return View(await printSmartContext.ToListAsync());
        }

        // GET: Pcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pcs == null)
            {
                return NotFound();
            }

            var pc = await _context.Pcs
                .Include(p => p.Marca)
                .Include(p => p.Procesador)
                .Include(p => p.SistemaOp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pc == null)
            {
                return NotFound();
            }

            return View(pc);
        }

        // GET: Pcs/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.MarcaPcs, "Id", "Nombre");
            ViewData["ProcesadorId"] = new SelectList(_context.Procesadors, "Id", "Nombre");
            ViewData["SistemaOpId"] = new SelectList(_context.SistemaOperativos, "Id", "Nombre");
            return View();
        }

        // POST: Pcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,SistemaOpId,MarcaId,ProcesadorId,Ram,DiscoDuro,Pantalla,PrecioVenta,PrecioCompra")] Pc pc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.MarcaPcs, "Id", "Nombre", pc.MarcaId);
            ViewData["ProcesadorId"] = new SelectList(_context.Procesadors, "Id", "Nombre", pc.ProcesadorId);
            ViewData["SistemaOpId"] = new SelectList(_context.SistemaOperativos, "Id", "Nombre", pc.SistemaOpId);
            return View(pc);
        }

        // GET: Pcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pcs == null)
            {
                return NotFound();
            }

            var pc = await _context.Pcs.FindAsync(id);
            if (pc == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.MarcaPcs, "Id", "Nombre", pc.MarcaId);
            ViewData["ProcesadorId"] = new SelectList(_context.Procesadors, "Id", "Nombre", pc.ProcesadorId);
            ViewData["SistemaOpId"] = new SelectList(_context.SistemaOperativos, "Id", "Nombre", pc.SistemaOpId);
            return View(pc);
        }

        // POST: Pcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,SistemaOpId,MarcaId,ProcesadorId,Ram,DiscoDuro,Pantalla,PrecioVenta,PrecioCompra")] Pc pc)
        {
            if (id != pc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PcExists(pc.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.MarcaPcs, "Id", "Nombre", pc.MarcaId);
            ViewData["ProcesadorId"] = new SelectList(_context.Procesadors, "Id", "Nombre", pc.ProcesadorId);
            ViewData["SistemaOpId"] = new SelectList(_context.SistemaOperativos, "Id", "Nombre", pc.SistemaOpId);
            return View(pc);
        }

        // GET: Pcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pcs == null)
            {
                return NotFound();
            }

            var pc = await _context.Pcs
                .Include(p => p.Marca)
                .Include(p => p.Procesador)
                .Include(p => p.SistemaOp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pc == null)
            {
                return NotFound();
            }

            return View(pc);
        }

        // POST: Pcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pcs == null)
            {
                return Problem("Entity set 'printSmartContext.Pcs'  is null.");
            }
            var pc = await _context.Pcs.FindAsync(id);
            if (pc != null)
            {
                _context.Pcs.Remove(pc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PcExists(int id)
        {
          return (_context.Pcs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
