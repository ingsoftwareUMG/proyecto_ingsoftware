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
   
    public class ReportesController : Controller
    {
        private readonly AplicationDbContext _context;

        public ReportesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reportes
        public async Task<IActionResult> Index(DateTime ini, DateTime fin)
        {
            string fechaReco = "01/01/0001 0:00:00";
            DateTime fechaR = new DateTime();
            fechaR = DateTime.Parse(fechaReco);
            Console.WriteLine(ini);
            Console.WriteLine(fin);
            if (ini.Date == fechaR.Date)
            {
                Console.WriteLine("No hay datos");
                return View();
            }
            else
            {
                
                using (var db = _context)
                {

                    var data = await (from s in db.Servicio
                                      join t in db.TipoServicio on s.IdTipoServ equals t.IdTipoServ
                                      join c in db.Costumers on s.IdCliente equals c.Id
                                      join p in db.Pago on s.Id equals p.IdServicio
                                      where (s.Fecha.Date >= ini.Date && s.Fecha.Date <= fin.Date)
                                      orderby s.Fecha ascending
                                      select new ReporteServicioss
                                      {
                                          Nombre = s.Nombre,
                                          Descripcion = s.Descripcion,
                                          Tipo = t.Nombre,
                                          Cliente = c.Name,
                                          Fecha = s.Fecha,
                                          Monto = p.Valor,
                                          Estado = s.Estado,
                                          Ini = ini,
                                          Fin = fin,
                                      }).ToListAsync();
                    return View(data);

                }
            }
           
            
        }

        // GET: Reporte de servicios
        public async Task<IActionResult> Rservicios(DateTime ini,DateTime fin)
        {
            Console.WriteLine(ini);
            Console.WriteLine(fin);
            using (var db = _context)
            {

                var data = await (from s in db.Servicio
                                  join t in db.TipoServicio on s.IdTipoServ equals t.IdTipoServ
                                  join c in db.Costumers on s.IdCliente equals c.Id
                                  join p in db.Pago on s.Id equals p.IdServicio
                                  where (s.Fecha.Date >= ini.Date && s.Fecha.Date <= fin.Date) 
                                  orderby s.Fecha ascending
                                  select new ReporteServicioss
                                  {
                                      Nombre = s.Nombre,
                                      Descripcion = s.Descripcion,
                                      Tipo = t.Nombre,
                                      Cliente = c.Name,
                                      Fecha = s.Fecha,
                                      Monto = p.Valor,
                                      Estado = s.Estado,
                                  }).ToListAsync();
                return View(data);

            }
        }


        
        //GET reportes/servicios
        


        // GET: Reportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reporte == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // GET: Reportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Reporte reporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporte);
        }

        // GET: Reportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reporte == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte == null)
            {
                return NotFound();
            }
            return View(reporte);
        }

        // POST: Reportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Reporte reporte)
        {
            if (id != reporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteExists(reporte.Id))
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
            return View(reporte);
        }

        // GET: Reportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reporte == null)
            {
                return NotFound();
            }

            var reporte = await _context.Reporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reporte == null)
            {
                return NotFound();
            }

            return View(reporte);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reporte == null)
            {
                return Problem("Entity set 'AplicationDbContext.Reporte'  is null.");
            }
            var reporte = await _context.Reporte.FindAsync(id);
            if (reporte != null)
            {
                _context.Reporte.Remove(reporte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteExists(int id)
        {
          return (_context.Reporte?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
