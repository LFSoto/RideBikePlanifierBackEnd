using Microsoft.EntityFrameworkCore.Migrations;

namespace RideBikePlanifierBackEnd.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coordenadas",
                columns: table => new
                {
                    ruta = table.Column<int>(nullable: false),
                    latitud = table.Column<float>(nullable: false),
                    longitud = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coordenadas", x => new { x.ruta, x.latitud, x.longitud });
                    table.ForeignKey(
                        name: "FK_coordenadas_rutas_ruta",
                        column: x => x.ruta,
                        principalTable: "rutas",
                        principalColumn: "id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coordenadas");
        }
    }
}
