using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using printSmart.data;
using printSmart.Models;

namespace printSmart.Controllers
{
    

    
    public class ReporteServicios : Controller
    {
        private readonly AplicationDbContext _context;

        public ReporteServicios(AplicationDbContext context)
        {
            _context = context;
        }
        /*
        public async Task<IActionResult> Index()
        {
            using (var db = _context)
            {
                var data = await (from s in db.Servicio
                                  join t in db.TipoServicio
                                  on s.IdTipoServ equals t.IdTipoServ
                                  join c in db.Cliente on s.IdCliente equals c.IdCliente
                                  orderby s.Fecha ascending
                                  select new ReporteServicios
                                  {
                                      Nombre = s.Nombre,
                                      Descripcion = s.Descripcion,
                                      Tipo = t.Nombre,
                                      Cliente = c.Nombre + c.Apellido,
                                      Fecha = s.Fecha,
                                      Estado = s.Estado,
                                  }).ToListAsync();
                return View(data);
            }
        }*/
    }
}
