using System;
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
    public class ServicioSuministroesController : Controller
    {
        private readonly AplicationDbContext _context;

        public ServicioSuministroesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicioSuministroes
        public async Task<IActionResult> Index()
        {
            using (var db = _context)
            {
                var datos = await (from ss in db.ServicioSuministro
                                   join s in db.Servicio
                                   on ss.IdServicio equals s.Id
                                   join sm in db.Suministros
                                   on ss.IdSuministro equals sm.Id
                                   orderby ss.Id descending
                                   select new ServicioSuministroDetalle
                                   {
                                       Id = (int)ss.Id,
                                       Servicio = s.Nombre,
                                       Repuesto = sm.Nombre,
                                   }).ToListAsync();
                return View(datos);
            }
            /*
            return _context.ServicioSuministro != null ? 
                          View(await _context.ServicioSuministro.ToListAsync()) :
                          Problem("Entity set 'AplicationDbContext.ServicioSuministro'  is null.");*/
        }

        // GET: ServicioSuministroes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ServicioSuministro == null)
            {
                return NotFound();
            }

            var servicioSuministro = await _context.ServicioSuministro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioSuministro == null)
            {
                return NotFound();
            }

            return View(servicioSuministro);
        }

        // GET: ServicioSuministroes/Create
        public IActionResult Create()
        {

            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "Id", "Nombre");
            ViewData["IdServicio"] = new SelectList(_context.Servicio.Where(s=>s.Estado==true), "Id", "Nombre");
            return View();
        }

        // POST: ServicioSuministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdSuministro,IdServicio,Estado")] ServicioSuministro servicioSuministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioSuministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioSuministro);
        }

        // GET: ServicioSuministroes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ServicioSuministro == null)
            {
                return NotFound();
            }

            var servicioSuministro = await _context.ServicioSuministro.FindAsync(id);
            if (servicioSuministro == null)
            {
                return NotFound();
            }
            ViewData["IdServicio"] = new SelectList(_context.Servicio, "Id", "Nombre");
            ViewData["IdSuministro"] = new SelectList(_context.Suministros, "IdSuministro", "Nombre");
            return View(servicioSuministro);
        }

        // POST: ServicioSuministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,IdSuministro,IdServicio,Estado")] ServicioSuministro servicioSuministro)
        {
            if (id != servicioSuministro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioSuministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioSuministroExists(servicioSuministro.Id))
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
            return View(servicioSuministro);
        }

        // GET: ServicioSuministroes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ServicioSuministro == null)
            {
                return NotFound();
            }

            var servicioSuministro = await _context.ServicioSuministro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioSuministro == null)
            {
                return NotFound();
            }

            return View(servicioSuministro);
        }

        // POST: ServicioSuministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ServicioSuministro == null)
            {
                return Problem("Entity set 'AplicationDbContext.ServicioSuministro'  is null.");
            }
            var servicioSuministro = await _context.ServicioSuministro.FindAsync(id);
            if (servicioSuministro != null)
            {
                _context.ServicioSuministro.Remove(servicioSuministro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioSuministroExists(long id)
        {
          return (_context.ServicioSuministro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
