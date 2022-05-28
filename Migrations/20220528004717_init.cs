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
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                });

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
                name: "costumer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costumer", x => x.id);
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
                name: "MarcaMaquina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaMaquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcaPC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaPC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcaSuministro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaSuministro", x => x.Id);
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
                name: "Procesador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SistemaOperativo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaOperativo", x => x.Id);
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
                name: "TipoSuministro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSuministro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "collectioncc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id_costumer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collectioncc", x => x.id);
                    table.ForeignKey(
                        name: "FK_collectioncc_costumer",
                        column: x => x.id_costumer,
                        principalTable: "costumer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "paymentcc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    id_costumer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentcc", x => x.id);
                    table.ForeignKey(
                        name: "FK_paymentcc_costumer",
                        column: x => x.id_costumer,
                        principalTable: "costumer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Serie = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Maquina__MarcaId__6E01572D",
                        column: x => x.MarcaId,
                        principalTable: "MarcaMaquina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    SistemaOpId = table.Column<int>(type: "int", nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    ProcesadorId = table.Column<int>(type: "int", nullable: false),
                    Ram = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DiscoDuro = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Pantalla = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PC", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PC__Marca__160F4887",
                        column: x => x.MarcaId,
                        principalTable: "MarcaPC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PC__Procesador__0C85DE4D",
                        column: x => x.ProcesadorId,
                        principalTable: "Procesador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PC__SistemaOp__0A9D95DB",
                        column: x => x.SistemaOpId,
                        principalTable: "SistemaOperativo",
                        principalColumn: "Id");
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
                    IdTipoServNavigationIdTipoServ = table.Column<long>(type: "bigint", nullable: true),
                    IdClienteNavigationIdCliente = table.Column<long>(type: "bigint", nullable: true),
                    IdEmpleadoNavigationIdEmpleado = table.Column<long>(type: "bigint", nullable: true),
                    IdCustomerNavigarionId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Servicio_costumer_IdCustomerNavigarionId",
                        column: x => x.IdCustomerNavigarionId,
                        principalTable: "costumer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Servicio_Empleado_IdEmpleadoNavigationIdEmpleado",
                        column: x => x.IdEmpleadoNavigationIdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado");
                    table.ForeignKey(
                        name: "FK_Servicio_TipoServicio_IdTipoServNavigationIdTipoServ",
                        column: x => x.IdTipoServNavigationIdTipoServ,
                        principalTable: "TipoServicio",
                        principalColumn: "IdTipoServ");
                });

            migrationBuilder.CreateTable(
                name: "Suministro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suministro", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Suministr__IdMar__440B1D61",
                        column: x => x.IdMarca,
                        principalTable: "MarcaSuministro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Suministr__IdTip__44FF419A",
                        column: x => x.IdTipo,
                        principalTable: "TipoSuministro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServicioRepuesto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRepuesto = table.Column<long>(type: "bigint", nullable: true),
                    IdServicio = table.Column<long>(type: "bigint", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdServicioNavigarionId = table.Column<int>(type: "int", nullable: true),
                    IdRepuestoNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioRepuesto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicioRepuesto_Repuesto_IdRepuestoNavigationId",
                        column: x => x.IdRepuestoNavigationId,
                        principalTable: "Repuesto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServicioRepuesto_Servicio_IdServicioNavigarionId",
                        column: x => x.IdServicioNavigarionId,
                        principalTable: "Servicio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServicioSuministro",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSuministro = table.Column<long>(type: "bigint", nullable: true),
                    IdServicio = table.Column<long>(type: "bigint", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdServicioNavigarionId = table.Column<int>(type: "int", nullable: true),
                    IdSuministroNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicioSuministro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicioSuministro_Servicio_IdServicioNavigarionId",
                        column: x => x.IdServicioNavigarionId,
                        principalTable: "Servicio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServicioSuministro_Suministro_IdSuministroNavigationId",
                        column: x => x.IdSuministroNavigationId,
                        principalTable: "Suministro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_collectioncc_id_costumer",
                table: "collectioncc",
                column: "id_costumer");

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_MarcaId",
                table: "Maquina",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_paymentcc_id_costumer",
                table: "paymentcc",
                column: "id_costumer");

            migrationBuilder.CreateIndex(
                name: "IX_PC_MarcaId",
                table: "PC",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_PC_ProcesadorId",
                table: "PC",
                column: "ProcesadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PC_SistemaOpId",
                table: "PC",
                column: "SistemaOpId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdClienteNavigationIdCliente",
                table: "Servicio",
                column: "IdClienteNavigationIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdCustomerNavigarionId",
                table: "Servicio",
                column: "IdCustomerNavigarionId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdEmpleadoNavigationIdEmpleado",
                table: "Servicio",
                column: "IdEmpleadoNavigationIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Servicio_IdTipoServNavigationIdTipoServ",
                table: "Servicio",
                column: "IdTipoServNavigationIdTipoServ");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioRepuesto_IdRepuestoNavigationId",
                table: "ServicioRepuesto",
                column: "IdRepuestoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioRepuesto_IdServicioNavigarionId",
                table: "ServicioRepuesto",
                column: "IdServicioNavigarionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioSuministro_IdServicioNavigarionId",
                table: "ServicioSuministro",
                column: "IdServicioNavigarionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicioSuministro_IdSuministroNavigationId",
                table: "ServicioSuministro",
                column: "IdSuministroNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Suministro_IdMarca",
                table: "Suministro",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Suministro_IdTipo",
                table: "Suministro",
                column: "IdTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "collectioncc");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "paymentcc");

            migrationBuilder.DropTable(
                name: "PC");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.DropTable(
                name: "ServicioRepuesto");

            migrationBuilder.DropTable(
                name: "ServicioSuministro");

            migrationBuilder.DropTable(
                name: "MarcaMaquina");

            migrationBuilder.DropTable(
                name: "MarcaPC");

            migrationBuilder.DropTable(
                name: "Procesador");

            migrationBuilder.DropTable(
                name: "SistemaOperativo");

            migrationBuilder.DropTable(
                name: "Repuesto");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Suministro");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "costumer");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "TipoServicio");

            migrationBuilder.DropTable(
                name: "MarcaSuministro");

            migrationBuilder.DropTable(
                name: "TipoSuministro");
        }
    }
}
