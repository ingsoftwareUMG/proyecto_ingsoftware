﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using printSmart.data;

#nullable disable

namespace printSmart.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("printSmart.Models.Cliente", b =>
                {
                    b.Property<long>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCliente"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("printSmart.Models.Empleado", b =>
                {
                    b.Property<long>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdEmpleado"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdEmpleado");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("printSmart.Models.Pago", b =>
                {
                    b.Property<int>("IdPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPago"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("IdServicio")
                        .HasColumnType("int");

                    b.Property<float?>("Valor")
                        .IsRequired()
                        .HasColumnType("real");

                    b.HasKey("IdPago");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("printSmart.Models.Producto", b =>
                {
                    b.Property<long>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdProducto"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("printSmart.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdCliente")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdClienteNavigationIdCliente")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdEmpleado")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdEmpleadoNavigationIdEmpleado")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdProducto")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdProductoNavigationIdProducto")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdTipoServ")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdTipoServNavigationIdTipoServ")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Viatico")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdClienteNavigationIdCliente");

                    b.HasIndex("IdEmpleadoNavigationIdEmpleado");

                    b.HasIndex("IdProductoNavigationIdProducto");

                    b.HasIndex("IdTipoServNavigationIdTipoServ");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("printSmart.Models.TipoServicio", b =>
                {
                    b.Property<long>("IdTipoServ")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTipoServ"), 1L, 1);

                    b.Property<float>("Costo")
                        .HasColumnType("real");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoServ");

                    b.ToTable("TipoServicio");
                });

            modelBuilder.Entity("printSmart.Models.Servicio", b =>
                {
                    b.HasOne("printSmart.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Servicio")
                        .HasForeignKey("IdClienteNavigationIdCliente");

                    b.HasOne("printSmart.Models.Empleado", "IdEmpleadoNavigation")
                        .WithMany("Servicio")
                        .HasForeignKey("IdEmpleadoNavigationIdEmpleado");

                    b.HasOne("printSmart.Models.Producto", "IdProductoNavigation")
                        .WithMany("Servicio")
                        .HasForeignKey("IdProductoNavigationIdProducto");

                    b.HasOne("printSmart.Models.TipoServicio", "IdTipoServNavigation")
                        .WithMany("Servicio")
                        .HasForeignKey("IdTipoServNavigationIdTipoServ");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdProductoNavigation");

                    b.Navigation("IdTipoServNavigation");
                });

            modelBuilder.Entity("printSmart.Models.Cliente", b =>
                {
                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("printSmart.Models.Empleado", b =>
                {
                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("printSmart.Models.Producto", b =>
                {
                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("printSmart.Models.TipoServicio", b =>
                {
                    b.Navigation("Servicio");
                });
#pragma warning restore 612, 618
        }
    }
}
