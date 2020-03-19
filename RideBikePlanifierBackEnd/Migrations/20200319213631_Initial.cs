using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RideBikePlanifierBackEnd.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    correoElectronico = table.Column<string>(nullable: false),
                    nombre = table.Column<string>(nullable: false),
                    apellido1 = table.Column<string>(nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    contrasenia = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    numeroEmergencia = table.Column<string>(nullable: true),
                    padecimientos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.correoElectronico);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
