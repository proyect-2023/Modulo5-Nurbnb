using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nurbnb.Pagos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalogo",
                columns: table => new
                {
                    catalogoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    porcentaje = table.Column<int>(type: "INTEGER", nullable: false),
                    esReserva = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogo", x => x.catalogoId);
                });

            migrationBuilder.CreateTable(
                name: "catalogoDevolucion",
                columns: table => new
                {
                    catalogoDevolucionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    nroDias = table.Column<int>(type: "INTEGER", nullable: false),
                    porcentajeDescuento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogoDevolucion", x => x.catalogoDevolucionId);
                });

            migrationBuilder.CreateTable(
                name: "medioPago",
                columns: table => new
                {
                    medioPagoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    pagoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    cuentaOrigen = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    bcoOrigen = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    comprobanteExterno = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medioPago", x => x.medioPagoId);
                });

            migrationBuilder.CreateTable(
                name: "pago",
                columns: table => new
                {
                    pagoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fechaCancelacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    operacionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    costoTotalRenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    cuentaOrigen = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    bcoOrigen = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pago", x => x.pagoId);
                });

            migrationBuilder.CreateTable(
                name: "detallePago",
                columns: table => new
                {
                    detallePagoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    catalogoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    pagoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    porcentaje = table.Column<int>(type: "INTEGER", nullable: false),
                    importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePago", x => x.detallePagoId);
                    table.ForeignKey(
                        name: "FK_detallePago_catalogo_catalogoId",
                        column: x => x.catalogoId,
                        principalTable: "catalogo",
                        principalColumn: "catalogoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallePago_pago_pagoId",
                        column: x => x.pagoId,
                        principalTable: "pago",
                        principalColumn: "pagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "devolucion",
                columns: table => new
                {
                    devolucionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    pagoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    catalogoDevolucionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    porcentajeDevolucion = table.Column<int>(type: "INTEGER", nullable: false),
                    importePago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalDevolucion = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devolucion", x => x.devolucionId);
                    table.ForeignKey(
                        name: "FK_devolucion_catalogoDevolucion_catalogoDevolucionId",
                        column: x => x.catalogoDevolucionId,
                        principalTable: "catalogoDevolucion",
                        principalColumn: "catalogoDevolucionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_devolucion_pago_pagoId",
                        column: x => x.pagoId,
                        principalTable: "pago",
                        principalColumn: "pagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detallePago_catalogoId",
                table: "detallePago",
                column: "catalogoId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePago_pagoId",
                table: "detallePago",
                column: "pagoId");

            migrationBuilder.CreateIndex(
                name: "IX_devolucion_catalogoDevolucionId",
                table: "devolucion",
                column: "catalogoDevolucionId");

            migrationBuilder.CreateIndex(
                name: "IX_devolucion_pagoId",
                table: "devolucion",
                column: "pagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallePago");

            migrationBuilder.DropTable(
                name: "devolucion");

            migrationBuilder.DropTable(
                name: "medioPago");

            migrationBuilder.DropTable(
                name: "catalogo");

            migrationBuilder.DropTable(
                name: "catalogoDevolucion");

            migrationBuilder.DropTable(
                name: "pago");
        }
    }
}
