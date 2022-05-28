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
    public class MaquinasController : Controller
    {
        private readonly AplicationDbContext _context;

        public MaquinasController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index()
        {
            var printSmartContext = _context.Maquinas.Include(m => m.Marca);
            return View(await printSmartContext.ToListAsync());
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maquinas == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.MarcaMaquinas, "Id", "Marca");
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,MarcaId,Modelo,Serie,Existencia,PrecioCompra,PrecioVenta")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.MarcaMaquinas, "Id", "Marca", maquina.MarcaId);
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maquinas == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.MarcaMaquinas, "Id", "Marca", maquina.MarcaId);
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,MarcaId,Modelo,Serie,Existencia,PrecioCompra,PrecioVenta")] Maquina maquina)
        {
            if (id != maquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.Id))
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
            ViewData["MarcaId"] = new SelectList(_context.MarcaMaquinas, "Id", "Marca", maquina.MarcaId);
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maquinas == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquinas
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maquinas == null)
            {
                return Problem("Entity set 'printSmartContext.Maquinas'  is null.");
            }
            var maquina = await _context.Maquinas.FindAsync(id);
            if (maquina != null)
            {
                _context.Maquinas.Remove(maquina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
          return (_context.Maquinas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
