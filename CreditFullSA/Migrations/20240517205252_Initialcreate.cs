using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CreditFullSA.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Creditos",
                columns: table => new
                {
                    numeroSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    lineaCredito = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    montoSolicitar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    plazo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    montoInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditos", x => x.numeroSolicitud);
                });

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "email", "Nombre", "Password" },
                values: new object[,]
                {
                    { "jcruz@gmail.com", "Jorge Cruz cruz", "78963" },
                    { "jvega@gmail.com", "Jinnet Vega Marin", "41936" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Creditos");
        }
    }
}
