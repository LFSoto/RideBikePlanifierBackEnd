using Microsoft.EntityFrameworkCore.Migrations;

namespace RideBikePlanifierBackEnd.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCalificada",
                table: "usuarioRutas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCalificada",
                table: "usuarioRutas");
        }
    }
}
