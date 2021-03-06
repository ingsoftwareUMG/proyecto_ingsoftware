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
    public class ServiciosController : Controller
    {
        private readonly AplicationDbContext _context;

        public ServiciosController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Servicios
        public async Task<IActionResult> Index()
        {
            using (var db = _context)
            {
                var data = await (from s in db.Servicio
                                  join t in db.TipoServicio
                                  on s.IdTipoServ equals t.IdTipoServ
                                  join c in db.Costumers on s.IdCliente equals c.Id
                                  where s.Estado  == true
                                  orderby s.Fecha ascending
                                  select new ServiciosDetalles
                                  {
                                      Id = s.Id,
                                      Nombre = s.Nombre,
                                      Descripcion = s.Descripcion,
                                      Tipo = t.Nombre,
                                      Cliente = c.Name,
                                      Fecha = s.Fecha,
                                  }).ToListAsync();
                return View(data);
            }

            /*  
             public int Id;
        public string? Nombre;
        public string? Descripcion;
        public string? Tipo;
        public string? Cliente;
        public string? Fecha;
        public string? Producto;
            return _context.Servicio != null ? 
                          View(await _context.Servicio.ToListAsync()) :
                          Problem("Entity set 'AplicationDbContext.Servicio'  is null.");*/
        }

        // GET: Servicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicio == null)
            {
                return NotFound();
            }

            
            
            using (var db = _context)
            {
                float valorSuministros=0;
                float valorRepuestos = 0;
                
                var suministros = await (from ss in db.ServicioSuministro
                                         join sm in db.Suministros
                                         on ss.IdSuministro equals sm.Id
                                         where ss.IdServicio == id
                                         select new Suministrod
                                         {
                                             Nombre = sm.Nombre,
                                             Precio = sm.PrecioVenta,
                                         }).ToListAsync();

                var repuestos = await (from sr in db.ServicioRepuesto
                                       join r in db.Repuestos
                                       on sr.IdRepuesto equals r.Id
                                       where sr.IdServicio == id
                                       select new Repuestod
                                       {
                                           Nombre = r.Nombre,
                                           Precio = (float)r.PrecioVenta,
                                       }).ToListAsync();
                



                if(suministros.Count != 0)
                {
                    foreach(var vs in suministros)
                    {
                        valorSuministros += (float)vs.Precio;
                    }
                }
                
                if(repuestos.Count != 0)
                {
                    foreach(var vr in repuestos)
                    {
                        valorRepuestos += (float)vr.Precio;
                    }
                }

                var data = await (from s in db.Servicio
                                  join t in db.TipoServicio
                                  on s.IdTipoServ equals t.IdTipoServ
                                  join c in db.Costumers on s.IdCliente equals c.Id
                                  where s.Id == id
                                  select new DetallesServicio
                                  {
                                      Id = s.Id,
                                      Nombre = s.Nombre,
                                      Descripcion = s.Descripcion,
                                      Tipo = t.Nombre,
                                      Cliente = c.Name,
                                      Fecha = s.Fecha,
                                      Suministros = suministros,
                                      Repuestos = repuestos,
                                      Vrepuestos = valorRepuestos,
                                      Vsuministros = valorSuministros,
                                      Vtiposervicio = t.Costo,
                                      Viatico = (float?)s.Viatico,
                                      Total = (float?)s.Viatico + t.Costo + valorRepuestos+valorSuministros,
                                  }).FirstOrDefaultAsync();
               
                return View(data);
            }

            
        }

        // GET: Servicios/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Costumers, "Id", "Name");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Nombre");
            ViewData["IdTipoServ"] = new SelectList(_context.TipoServicio, "IdTipoServ", "Nombre");
            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Viatico,Fecha,Estado,IdTipoServ,IdCliente,IdEmpleado,IdProducto")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicio == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicio.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            ViewData["IdCliente"] = new SelectList(_context.Costumers, "Id", "Name");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "IdEmpleado", "Nombre");
            ViewData["IdTipoServ"] = new SelectList(_context.TipoServicio, "IdTipoServ", "Nombre");
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Viatico,Fecha,Estado,IdTipoServ,IdCliente,IdEmpleado,IdProducto")] Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioExists(servicio.Id))
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
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicio == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicio == null)
            {
                return Problem("Entity set 'AplicationDbContext.Servicio'  is null.");
            }
            var servicio = await _context.Servicio.FindAsync(id);
            if (servicio != null)
            {
                _context.Servicio.Remove(servicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioExists(int id)
        {
          return (_context.Servicio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
