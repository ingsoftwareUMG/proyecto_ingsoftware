using printSmart.Models;
using Microsoft.EntityFrameworkCore;

namespace printSmart.data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options ) : base(options)
        {

        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Servicio>()
             //   .Property(b => b.Creacion)
                .ValueGeneratedOnAdd();
        }*/

        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<printSmart.Models.Servicio> Servicio { get; set; }
        public DbSet<printSmart.Models.Cliente> Cliente { get; set; }
        public DbSet<printSmart.Models.Empleado> Empleado { get; set; }
        public DbSet<printSmart.Models.Producto> Producto { get; set; }
        public DbSet<printSmart.Models.Pago> Pago { get; set; }

    }
}
