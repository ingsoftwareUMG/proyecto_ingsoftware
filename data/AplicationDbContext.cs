using printSmart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace printSmart.data
{
    public partial class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options ) : base(options)
        {

        }
      

        public DbSet<TipoServicio> TipoServicio { get; set; }
        public DbSet<printSmart.Models.Servicio> Servicio { get; set; }
       // public DbSet<printSmart.Models.Cliente> Cliente { get; set; }
        public DbSet<printSmart.Models.Empleado> Empleado { get; set; }
        public DbSet<printSmart.Models.Pago> Pago { get; set; }
       // public DbSet<printSmart.Models.Suministros>? Suministros { get; set; }
       // public DbSet<printSmart.Models.Repuesto>? Repuesto { get; set; }
        public DbSet<printSmart.Models.ServicioRepuesto>? ServicioRepuesto { get; set; }
        public DbSet<printSmart.Models.ServicioSuministro>? ServicioSuministro { get; set; }
        public DbSet<printSmart.Models.Reporte>? Reporte { get; set; }
        //
        public virtual DbSet<Categorium>? Categoria { get; set; }
        public virtual DbSet<Maquina>? Maquinas { get; set; }
        public virtual DbSet<MarcaMaquina>? MarcaMaquinas { get; set; }
        public virtual DbSet<MarcaPc>? MarcaPcs { get; set; }
        public virtual DbSet<MarcaSuministro>? MarcaSuministros { get; set; }
        public virtual DbSet<Pc>? Pcs { get; set; }
        public virtual DbSet<Procesador>? Procesadors { get; set; }
        public virtual DbSet<Repuesto>? Repuestos { get; set; }
        public virtual DbSet<SistemaOperativo>? SistemaOperativos { get; set; }
        public virtual DbSet<Suministro>? Suministros { get; set; }
        public virtual DbSet<TipoSuministro>? TipoSuministros { get; set; }

        //oscar
        public virtual DbSet<Collectioncc> Collectionccs { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }
        public virtual DbSet<Paymentcc> Paymentccs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.ToTable("Maquina");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Serie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Maquina__MarcaId__6E01572D");
            });

            modelBuilder.Entity<MarcaMaquina>(entity =>
            {
                entity.ToTable("MarcaMaquina");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarcaPc>(entity =>
            {
                entity.ToTable("MarcaPC");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarcaSuministro>(entity =>
            {
                entity.ToTable("MarcaSuministro");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pc>(entity =>
            {
                entity.ToTable("PC");

                entity.Property(e => e.DiscoDuro)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pantalla)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Ram)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.MarcaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PC__Marca__160F4887");

                entity.HasOne(d => d.Procesador)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.ProcesadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PC__Procesador__0C85DE4D");

                entity.HasOne(d => d.SistemaOp)
                    .WithMany(p => p.Pcs)
                    .HasForeignKey(d => d.SistemaOpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PC__SistemaOp__0A9D95DB");
            });

            modelBuilder.Entity<Procesador>(entity =>
            {
                entity.ToTable("Procesador");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.ToTable("Repuesto");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<SistemaOperativo>(entity =>
            {
                entity.ToTable("SistemaOperativo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Suministro>(entity =>
            {
                entity.ToTable("Suministro");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Suministros)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suministr__IdMar__440B1D61");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Suministros)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suministr__IdTip__44FF419A");
            });

            modelBuilder.Entity<TipoSuministro>(entity =>
            {
                entity.ToTable("TipoSuministro");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //oscar
            modelBuilder.Entity<Collectioncc>(entity =>
            {
                entity.ToTable("collectioncc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.IdCostumer).HasColumnName("id_costumer");

                entity.HasOne(d => d.IdCostumerNavigation)
                    .WithMany(p => p.Collectionccs)
                    .HasForeignKey(d => d.IdCostumer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_collectioncc_costumer");
            });

            modelBuilder.Entity<Costumer>(entity =>
            {
                entity.ToTable("costumer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Nit)
                    .HasMaxLength(50)
                    .HasColumnName("nit");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Paymentcc>(entity =>
            {
                entity.ToTable("paymentcc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.IdCostumer).HasColumnName("id_costumer");

                entity.HasOne(d => d.IdCostumerNavigation)
                    .WithMany(p => p.Paymentccs)
                    .HasForeignKey(d => d.IdCostumer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paymentcc_costumer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
