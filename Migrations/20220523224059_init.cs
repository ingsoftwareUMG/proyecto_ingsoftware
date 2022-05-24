using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace printSmart.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.IdPago);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicio",
                columns: table => new
                {
                    IdTipoServ = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Costo = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicio", x => x.IdTipoServ);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viatico = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoServ = table.Column<long>(type: "bigint", nullable: true),
                    IdCliente = table.Column<long>(type: "bigint", nullable: true),
                    IdEmpleado = table.Column<long>(type: "bigint", nullable: true),
                    IdProducto = table.Column<long>(type: "bigint", nullable: true),
                    IdTipoServNavigationIdTipoServ = table.Column<long>(type: "bigint", nullable: true),
                    IdClienteNavigationIdCliente = table.Column<long>(type: "bigint", nullable: true),
                    IdEmpleadoNavigationIdEmpleado = table.Column<long>(type: "bigint", nullable: true),
                    IdProductoNavigationIdProducto = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicio_Cliente_IdClienteNavigationIdCliente",
                        column: x => x.IdClienteNavigationIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Servicio_Empleado_IdEmpleadoNavigationIdEmpleado",
                        column: x => x.IdEmpleadoNavigationIdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado");
                    table.ForeignKey(
                        name: "FK_Servicio_Producto_IdProductoNavigationIdProducto",
                        column: x => x.IdProductoNavigationIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_Servicio_TipoServicio_IdTipoServNavigationIdTipoServ",
                        column: x => x.IdTipoServNavigationIdTipoServ,
                        principalTable: "TipoServicio",
                        principalColumn: "IdTipoServ");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdClienteNavigationIdCliente",
                table: "Servicio",
                column: "IdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdEmpleadoNavigationIdEmpleado",
                table: "Servicio",
                column: "IdEmpleadoNavigationIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdProductoNavigationIdProducto",
                table: "Servicio",
                column: "IdProductoNavigationIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdTipoServNavigationIdTipoServ",
                table: "Servicio",
                column: "IdTipoServNavigationIdTipoServ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "TipoServicio");
        }
    }
}
