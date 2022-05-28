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
    public class ServicioRepuestoesController : Controller
    {
        private readonly AplicationDbContext _context;

        public ServicioRepuestoesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: ServicioRepuestoes
        public async Task<IActionResult> Index()
        {
            using(var db = _context)
            {
                var datos = await (from sr in db.ServicioRepuesto
                                   join s in db.Servicio
                                   on sr.IdServicio equals s.Id
                                   join r in db.Repuestos
                                   on sr.IdRepuesto equals r.Id
                                   orderby sr.Id descending
                                   select new ServicioRepuestoDetalle
                                   {
                                       Id = (int)sr.Id,
                                       Servicio = s.Nombre,
                                       Repuesto = r.Nombre,
                                   }).ToListAsync();
                return View(datos);
            }  
            /*
            
            return _context.ServicioRepuesto != null ? 
                          View(await _context.ServicioRepuesto.ToListAsync()) :
                          Problem("Entity set 'AplicationDbContext.ServicioRepuesto'  is null.");*/
        }

        // GET: ServicioRepuestoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ServicioRepuesto == null)
            {
                return NotFound();
            }

            var servicioRepuesto = await _context.ServicioRepuesto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioRepuesto == null)
            {
                return NotFound();
            }

            return View(servicioRepuesto);
        }

        // GET: ServicioRepuestoes/Create
        public IActionResult Create()
        {
            ViewData["IdRepuesto"] = new SelectList(_context.Repuestos, "Id", "Nombre");
            ViewData["IdServicio"] = new SelectList(_context.Servicio.Where(s=>s.Estado==true), "Id", "Nombre");
            return View();
        }

        // POST: ServicioRepuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdRepuesto,IdServicio,Estado")] ServicioRepuesto servicioRepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioRepuesto);
        }

        // GET: ServicioRepuestoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ServicioRepuesto == null)
            {
                return NotFound();
            }

            var servicioRepuesto = await _context.ServicioRepuesto.FindAsync(id);
            if (servicioRepuesto == null)
            {
                return NotFound();
            }
            ViewData["IdServicio"] = new SelectList(_context.Servicio, "Id", "Nombre");
            ViewData["IdRepuesto"] = new SelectList(_context.Repuestos, "Id", "Nombre");
            return View(servicioRepuesto);
        }

        // POST: ServicioRepuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,IdRepuesto,IdServicio,Estado")] ServicioRepuesto servicioRepuesto)
        {
            if (id != servicioRepuesto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioRepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioRepuestoExists(servicioRepuesto.Id))
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
            return View(servicioRepuesto);
        }

        // GET: ServicioRepuestoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ServicioRepuesto == null)
            {
                return NotFound();
            }

            var servicioRepuesto = await _context.ServicioRepuesto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioRepuesto == null)
            {
                return NotFound();
            }

            return View(servicioRepuesto);
        }

        // POST: ServicioRepuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ServicioRepuesto == null)
            {
                return Problem("Entity set 'AplicationDbContext.ServicioRepuesto'  is null.");
            }
            var servicioRepuesto = await _context.ServicioRepuesto.FindAsync(id);
            if (servicioRepuesto != null)
            {
                _context.ServicioRepuesto.Remove(servicioRepuesto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioRepuestoExists(long id)
        {
          return (_context.ServicioRepuesto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
