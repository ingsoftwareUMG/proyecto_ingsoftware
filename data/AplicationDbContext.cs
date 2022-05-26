using printSmart.Models;
using Microsoft.EntityFrameworkCore;

namespace printSmart.data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options ) : base(options)
        {

        }
      

        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<printSmart.Models.Servicio> Servicio { get; set; }
        public DbSet<printSmart.Models.Cliente> Cliente { get; set; }
        public DbSet<printSmart.Models.Empleado> Empleado { get; set; }
        public DbSet<printSmart.Models.Pago> Pago { get; set; }
        public DbSet<printSmart.Models.Suministros>? Suministros { get; set; }
        public DbSet<printSmart.Models.Repuesto>? Repuesto { get; set; }
        public DbSet<printSmart.Models.ServicioRepuesto>? ServicioRepuesto { get; set; }
        public DbSet<printSmart.Models.ServicioSuministro>? ServicioSuministro { get; set; }
        public DbSet<printSmart.Models.Reporte>? Reporte { get; set; }

    }
}
