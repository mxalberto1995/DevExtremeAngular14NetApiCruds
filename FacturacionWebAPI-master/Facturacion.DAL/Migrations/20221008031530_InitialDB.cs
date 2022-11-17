using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Facturacion.DAL.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadExistencia = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    NumeroFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaExpedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.NumeroFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVenta_Factura_NumeroFactura",
                        column: x => x.NumeroFactura,
                        principalTable: "Factura",
                        principalColumn: "NumeroFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVenta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, "Navidad" },
                    { 2, "Tecnología" },
                    { 3, "Juguetes" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Apellido", "Direccion", "Email", "FechaNacimiento", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "SMITH", "1913 Hanoi Way", "MARY.SMITH@sakilacustomer.org", new DateTime(1992, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARY", "28303384290" },
                    { 2, "JOHNSON", "1121 Loja Avenue", "PATRICIA.JOHNSON@sakilacustomer.org", new DateTime(1997, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "PATRICIA", "838635286649" },
                    { 3, "WILLIAMS", "692 Joliet Street", "LINDA.WILLIAMS@sakilacustomer.org", new DateTime(1982, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "LINDA", "448477190408" },
                    { 4, "JONES", "1566 Inegl Manor", "BARBARA.JONES@sakilacustomer.org", new DateTime(1987, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "BARBARA", "705814003527" },
                    { 5, "BROWN", "53 Idfu Parkway", "ELIZABETH.BROWN@sakilacustomer.org", new DateTime(1997, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ELIZABETH", "10655648674" },
                    { 6, "DAVIS", "1795 Santiago de Compostela Way", "JENNIFER.DAVIS@sakilacustomer.org", new DateTime(1986, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "JENNIFER", "860452626434" },
                    { 7, "MILLER", "900 Santiago de Compostela Parkway", "MARIA.MILLER@sakilacustomer.org", new DateTime(1989, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARIA", "716571220373" },
                    { 8, "WILSON", "478 Joliet Way", "SUSAN.WILSON@sakilacustomer.org", new DateTime(1998, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUSAN", "657282285970" },
                    { 9, "MOORE", "613 Korolev Drive", "MARGARET.MOORE@sakilacustomer.org", new DateTime(1992, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARGARET", "380657522649" },
                    { 10, "TAYLOR", "1531 Sal Drive", "DOROTHY.TAYLOR@sakilacustomer.org", new DateTime(1996, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DOROTHY", "648856936185" },
                    { 11, "ANDERSON", "1542 Tarlac Parkway", "LISA.ANDERSON@sakilacustomer.org", new DateTime(1985, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "LISA", "635297277345" },
                    { 12, "THOMAS", "808 Bhopal Manor", "NANCY.THOMAS@sakilacustomer.org", new DateTime(1991, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NANCY", "465887807014" },
                    { 13, "JACKSON", "270 Amroha Parkway", "KAREN.JACKSON@sakilacustomer.org", new DateTime(1986, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "KAREN", "695479687538" },
                    { 14, "WHITE", "770 Bydgoszcz Avenue", "BETTY.WHITE@sakilacustomer.org", new DateTime(2001, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "BETTY", "517338314235" },
                    { 15, "HARRIS", "419 Iligan Lane", "HELEN.HARRIS@sakilacustomer.org", new DateTime(1992, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HELEN", "990911107354" },
                    { 16, "MARTIN", "360 Toulouse Parkway", "SANDRA.MARTIN@sakilacustomer.org", new DateTime(1993, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "SANDRA", "949312333307" },
                    { 17, "THOMPSON", "270 Toulon Boulevard", "DONNA.THOMPSON@sakilacustomer.org", new DateTime(1989, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "DONNA", "407752414682" },
                    { 18, "GARCIA", "320 Brest Avenue", "CAROL.GARCIA@sakilacustomer.org", new DateTime(1999, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAROL", "747791594069" },
                    { 19, "MARTINEZ", "1417 Lancaster Avenue", "RUTH.MARTINEZ@sakilacustomer.org", new DateTime(1983, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "RUTH", "272572357893" },
                    { 20, "ROBINSON", "1688 Okara Way", "SHARON.ROBINSON@sakilacustomer.org", new DateTime(1984, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "SHARON", "144453869132" }
                });

            migrationBuilder.InsertData(
                table: "Factura",
                columns: new[] { "NumeroFactura", "ClienteId", "FechaExpedicion" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2000, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2018, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2001, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5, new DateTime(2000, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 6, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 7, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 19, new DateTime(2018, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 15, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "Id", "CantidadExistencia", "CategoriaId", "Nombre", "PrecioUnitario" },
                values: new object[,]
                {
                    { 1, 50, 1, "RENO NAVIDEÑO DE 53 CM CON FALDA A CUADROS", 59900m },
                    { 2, 45, 1, "SANTA COLGANTE ROJO - HO!HO!HO!", 54900m },
                    { 3, 47, 1, "MUÑECO DE NIEVE SENTADO DE 21 CM CON BUSO VERDE", 39900m },
                    { 4, 25, 1, "PIE DE ÁRBOL BEIGE DE 90 CM, MUÑECO DE NIEVE", 89900m },
                    { 5, 33, 1, "CORONA NAVIDEÑA VERDE DE 40 CM CON FRUTOS ROJOS, HOJAS Y MANZANAS", 49900m },
                    { 6, 44, 1, "COJÍN ROJO DE 35.5 CM - HAPPY NEW YEAR", 34900m },
                    { 7, 34, 1, "RAMA NAVIDEÑA DE FRUTOS ROJOS ESCARCHADA DE 73 CM", 14900m },
                    { 8, 10, 1, "ÁRBOL DE NAVIDAD DE 180 CM Y 720 PUNTAS", 169900m },
                    { 9, 5, 1, "ÁRBOL NAVIDEÑO VERDE Y BLANCO DE 1.80 M", 399900m },
                    { 10, 27, 1, "PESEBRE DE 11 FIGURAS EN 1 PIEZA DE 40 X 36 CM CON LUZ Y SONIDO", 409900m },
                    { 11, 7, 2, "PORTÁTIL ACER, INTEL® CORE™ I5 1035G1, RAM 8 GB, 256 GB SSD, A315-57G-59KN, 15.6\" FHD, NEGRO", 1899900m },
                    { 12, 22, 2, "ALL IN ONE HP, AMD RYZEN™ 3, RAM 4 GB, 128 GB SSD, 22-DD0522LA, 21.5” FHD, NEGRO", 1649000m },
                    { 13, 57, 2, "TABLETA LENOVO, RAM 4 GB, 64 GB, TB-X306X TAB M10 HD, 10.1\", GRIS", 699000m },
                    { 14, 5, 2, "TECLADO NUMÉRICO TARGUS DE USB, NEGRO", 55900m },
                    { 15, 100, 2, "COMBO HP DE TECLADO + MOUSE INALÁMBRICO, BLANCO", 189900m },
                    { 16, 14, 2, "GOOGLE WIFI X 3, BLANCO", 959900m },
                    { 17, 64, 2, "MEMORIA USB DE 64 GB MAXELL, NEGRA CON PLATEADO", 29900m },
                    { 18, 8, 2, "HUB USB INFINITO MULTIPUERTO CON HDMI", 149900m },
                    { 19, 85, 2, "MOUSE INALÁMBRICO NIGTHFALL CAMO CON BLUETOOTH, AZUL", 69900m },
                    { 20, 17, 2, "CÁMARA WEB 12 MP, HAVIT HV-NA20G", 289900m },
                    { 21, 71, 3, "FIGURA DE LAS TORTUGAS NINJA DE 51 CM – LEONARDO", 269900m },
                    { 22, 25, 3, "SR. CARA DE PAPA", 69900m },
                    { 23, 58, 3, "IRON MAN", 69900m },
                    { 24, 65, 3, "FIGURA DE IRON SPIDER ENDGAME DE 50 CM", 269900m },
                    { 25, 2, 3, "REMOLQUE HOT WHEELS, DISEÑO TIBURÓN", 109900m },
                    { 26, 19, 3, "CAMIONETA MONSTER JAM RC GRAVE DIGGER", 149900m },
                    { 27, 88, 3, "LANZADOR DE DARDOS SONIC RAPTOR CON 10 DARDOS", 79900m },
                    { 28, 35, 3, "LANZADOR NERF DINOSQUAD RAPTOR-SLASH CON 6 DARDOS", 99900m },
                    { 29, 26, 3, "TIMÓN DIDÁCTICO AZUL CON LUZ Y SONIDO", 59900m },
                    { 30, 11, 3, "BLOQUES LÓGICOS EN CAUCHO ESPUMA, 48 PIEZAS", 33200m }
                });

            migrationBuilder.InsertData(
                table: "ItemVenta",
                columns: new[] { "Id", "CantidadVendida", "NumeroFactura", "PrecioUnitario", "ProductoId" },
                values: new object[,]
                {
                    { 1, 1, 1, 59900m, 1 },
                    { 2, 1, 1, 169900m, 8 },
                    { 3, 2, 1, 69900m, 23 },
                    { 4, 1, 2, 69900m, 23 },
                    { 5, 1, 2, 59900m, 29 },
                    { 6, 1, 2, 33200m, 30 },
                    { 7, 1, 3, 699000m, 13 },
                    { 8, 1, 3, 55900m, 14 },
                    { 9, 1, 3, 189900m, 15 },
                    { 10, 1, 4, 959900m, 16 },
                    { 11, 2, 4, 149900m, 18 },
                    { 12, 1, 4, 409900m, 10 },
                    { 13, 1, 5, 54900m, 2 },
                    { 14, 4, 5, 33000m, 6 },
                    { 15, 1, 5, 699000m, 13 },
                    { 16, 1, 6, 39900m, 3 },
                    { 17, 1, 6, 49900m, 5 },
                    { 18, 1, 6, 14900m, 7 },
                    { 19, 1, 7, 1899900m, 11 },
                    { 20, 2, 7, 29900m, 17 },
                    { 21, 1, 7, 69900m, 19 },
                    { 22, 1, 8, 269900m, 24 },
                    { 23, 1, 8, 109900m, 25 },
                    { 24, 1, 8, 99900m, 28 },
                    { 25, 1, 9, 169900m, 8 },
                    { 26, 1, 9, 55900m, 14 },
                    { 27, 2, 9, 33000m, 6 },
                    { 28, 1, 10, 399900m, 9 },
                    { 29, 1, 10, 1649000m, 12 },
                    { 30, 1, 10, 149900m, 18 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenta_NumeroFactura",
                table: "ItemVenta",
                column: "NumeroFactura");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenta_ProductoId",
                table: "ItemVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemVenta");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
