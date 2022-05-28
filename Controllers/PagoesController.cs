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
    public class PagoesController : Controller
    {
        private readonly AplicationDbContext _context;

        public PagoesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            using(var db = _context)
            {
                int limiteDatos = 10;
                var pagos = await (from p in db.Pago
                                   join s in db.Servicio on p.IdServicio equals s.Id
                                   join c in db.Costumers on s.IdCliente equals c.Id
                                   orderby p.IdPago descending
                                   select new PagoDetalle
                                   {
                                       IdPago = p.IdPago,
                                       Servicio = s.Nombre,
                                       Cliente = c.Name,
                                       Importe = p.Valor,
                                       IdServicio=s.Id,

                                   }).Take(limiteDatos).ToListAsync();

                return View(pagos);
            }   
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Console.WriteLine(id);
            using (var db = _context)
            {
                float valorSuministros = 0;
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




                if (suministros.Count != 0)
                {
                    foreach (var vs in suministros)
                    {
                        valorSuministros += (float)vs.Precio;
                    }
                }

                if (repuestos.Count != 0)
                {
                    foreach (var vr in repuestos)
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
                                      Total = (float?)s.Viatico + t.Costo + valorRepuestos + valorSuministros,
                                  }).FirstOrDefaultAsync();
                
                foreach(var it in suministros)
                {
                    Console.WriteLine(it.Nombre);
                    Console.WriteLine(it.Precio);
                }
                
                
                return View(data);
            }
        }
         

        
        //post pago
        public async Task<IActionResult> Pago(int id, float Total)
        {
            var pago = new Pago();
            pago.IdServicio = id;
            pago.Valor = Total;
            pago.Estado = true;

           
            
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                var ser = await _context.Servicio.FindAsync(id);
                    ser.Estado = false;
                    _context.Servicio.Update(ser);
                    await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(Index));

            }
          
            return View(pago);
        }


        // GET: Pagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPago,IdServicio,Valor,Estado")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPago,IdServicio,Valor,Estado")] Pago pago)
        {
            if (id != pago.IdPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.IdPago))
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
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pago == null)
            {
                return NotFound();
            }

            var pago = await _context.Pago
                .FirstOrDefaultAsync(m => m.IdPago == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pago == null)
            {
                return Problem("Entity set 'AplicationDbContext.Pago'  is null.");
            }
            var pago = await _context.Pago.FindAsync(id);
            if (pago != null)
            {
                _context.Pago.Remove(pago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
          return (_context.Pago?.Any(e => e.IdPago == id)).GetValueOrDefault();
        }
    }
}
