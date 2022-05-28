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
    public class MarcaSuministroesController : Controller
    {
        private readonly AplicationDbContext _context;

        public MarcaSuministroesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: MarcaSuministroes
        public async Task<IActionResult> Index()
        {
              return _context.MarcaSuministros != null ? 
                          View(await _context.MarcaSuministros.ToListAsync()) :
                          Problem("Entity set 'printSmartContext.MarcaSuministros'  is null.");
        }

        // GET: MarcaSuministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MarcaSuministros == null)
            {
                return NotFound();
            }

            var marcaSuministro = await _context.MarcaSuministros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaSuministro == null)
            {
                return NotFound();
            }

            return View(marcaSuministro);
        }

        // GET: MarcaSuministroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarcaSuministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca")] MarcaSuministro marcaSuministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcaSuministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marcaSuministro);
        }

        // GET: MarcaSuministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MarcaSuministros == null)
            {
                return NotFound();
            }

            var marcaSuministro = await _context.MarcaSuministros.FindAsync(id);
            if (marcaSuministro == null)
            {
                return NotFound();
            }
            return View(marcaSuministro);
        }

        // POST: MarcaSuministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca")] MarcaSuministro marcaSuministro)
        {
            if (id != marcaSuministro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaSuministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaSuministroExists(marcaSuministro.Id))
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
            return View(marcaSuministro);
        }

        // GET: MarcaSuministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MarcaSuministros == null)
            {
                return NotFound();
            }

            var marcaSuministro = await _context.MarcaSuministros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcaSuministro == null)
            {
                return NotFound();
            }

            return View(marcaSuministro);
        }

        // POST: MarcaSuministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MarcaSuministros == null)
            {
                return Problem("Entity set 'printSmartContext.MarcaSuministros'  is null.");
            }
            var marcaSuministro = await _context.MarcaSuministros.FindAsync(id);
            if (marcaSuministro != null)
            {
                _context.MarcaSuministros.Remove(marcaSuministro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaSuministroExists(int id)
        {
          return (_context.MarcaSuministros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
