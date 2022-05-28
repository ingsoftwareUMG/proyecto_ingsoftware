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
    public class MarcaMaquinasController : Controller
    {
        private readonly AplicationDbContext _context;

        public MarcaMaquinasController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: MarcaMaquinas
        public async Task<IActionResult> Index()
        {
              return _context.MarcaMaquinas != null ? 
                          View(await _context.MarcaMaquinas.ToListAsync()) :
                          Problem("Entity set 'printSmartContext.MarcaMaquinas'  is null.");
        }

        // GET: MarcaMaquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MarcaMaquinas == null)
            {
                return NotFound();
            }

            var marcaMaquina = await _context.MarcaMaquinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaMaquina == null)
            {
                return NotFound();
            }

            return View(marcaMaquina);
        }

        // GET: MarcaMaquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaMaquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca")] MarcaMaquina marcaMaquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaMaquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaMaquina);
        }

        // GET: MarcaMaquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MarcaMaquinas == null)
            {
                return NotFound();
            }

            var marcaMaquina = await _context.MarcaMaquinas.FindAsync(id);
            if (marcaMaquina == null)
            {
                return NotFound();
            }
            return View(marcaMaquina);
        }

        // POST: MarcaMaquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca")] MarcaMaquina marcaMaquina)
        {
            if (id != marcaMaquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaMaquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaMaquinaExists(marcaMaquina.Id))
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
            return View(marcaMaquina);
        }

        // GET: MarcaMaquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MarcaMaquinas == null)
            {
                return NotFound();
            }

            var marcaMaquina = await _context.MarcaMaquinas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaMaquina == null)
            {
                return NotFound();
            }

            return View(marcaMaquina);
        }

        // POST: MarcaMaquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MarcaMaquinas == null)
            {
                return Problem("Entity set 'printSmartContext.MarcaMaquinas'  is null.");
            }
            var marcaMaquina = await _context.MarcaMaquinas.FindAsync(id);
            if (marcaMaquina != null)
            {
                _context.MarcaMaquinas.Remove(marcaMaquina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaMaquinaExists(int id)
        {
          return (_context.MarcaMaquinas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
