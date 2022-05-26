﻿using System;
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
    public class SuministrosController : Controller
    {
        private readonly AplicationDbContext _context;

        public SuministrosController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suministros
        public async Task<IActionResult> Index()
        {
              return _context.Suministros != null ? 
                          View(await _context.Suministros.ToListAsync()) :
                          Problem("Entity set 'AplicationDbContext.Suministros'  is null.");
        }

        // GET: Suministros/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Suministros == null)
            {
                return NotFound();
            }

            var suministros = await _context.Suministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (suministros == null)
            {
                return NotFound();
            }

            return View(suministros);
        }

        // GET: Suministros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suministros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuministro,Nombre,Precio,Estado")] Suministros suministros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suministros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suministros);
        }

        // GET: Suministros/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Suministros == null)
            {
                return NotFound();
            }

            var suministros = await _context.Suministros.FindAsync(id);
            if (suministros == null)
            {
                return NotFound();
            }
            return View(suministros);
        }

        // POST: Suministros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdSuministro,Nombre,Precio,Estado")] Suministros suministros)
        {
            if (id != suministros.IdSuministro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suministros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuministrosExists(suministros.IdSuministro))
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
            return View(suministros);
        }

        // GET: Suministros/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Suministros == null)
            {
                return NotFound();
            }

            var suministros = await _context.Suministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (suministros == null)
            {
                return NotFound();
            }

            return View(suministros);
        }

        // POST: Suministros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Suministros == null)
            {
                return Problem("Entity set 'AplicationDbContext.Suministros'  is null.");
            }
            var suministros = await _context.Suministros.FindAsync(id);
            if (suministros != null)
            {
                _context.Suministros.Remove(suministros);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuministrosExists(long id)
        {
          return (_context.Suministros?.Any(e => e.IdSuministro == id)).GetValueOrDefault();
        }
    }
}
