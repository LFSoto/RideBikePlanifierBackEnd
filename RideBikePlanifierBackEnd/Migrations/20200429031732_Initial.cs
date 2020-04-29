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

            migrationBuilder.CreateTable(
                name: "amigos",
                columns: table => new
                {
                    usuario = table.Column<string>(nullable: false),
                    amigo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amigos", x => new { x.usuario, x.amigo });
                    table.ForeignKey(
                        name: "FK_amigos_usuarios_amigo",
                        column: x => x.amigo,
                        principalTable: "usuarios",
                        principalColumn: "correoElectronico");
                    table.ForeignKey(
                        name: "FK_amigos_usuarios_usuario",
                        column: x => x.usuario,
                        principalTable: "usuarios",
                        principalColumn: "correoElectronico");
                });

            migrationBuilder.CreateTable(
                name: "rutas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creador = table.Column<string>(nullable: false),
                    kilometrosRecorrer = table.Column<float>(nullable: false),
                    isPublica = table.Column<bool>(nullable: false),
                    comentarios = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutas", x => x.id);
                    table.ForeignKey(
                        name: "FK_rutas_usuarios_creador",
                        column: x => x.creador,
                        principalTable: "usuarios",
                        principalColumn: "correoElectronico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarioRutas",
                columns: table => new
                {
                    ruta = table.Column<int>(nullable: false),
                    usuario = table.Column<string>(nullable: false),
                    dificultad = table.Column<int>(nullable: true),
                    ambiente = table.Column<int>(nullable: true),
                    evaluacionFinal = table.Column<int>(nullable: true),
                    comentariosEvaluacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioRutas", x => new { x.ruta, x.usuario });
                    table.ForeignKey(
                        name: "FK_usuarioRutas_rutas_ruta",
                        column: x => x.ruta,
                        principalTable: "rutas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_usuarioRutas_usuarios_usuario",
                        column: x => x.usuario,
                        principalTable: "usuarios",
                        principalColumn: "correoElectronico");
                });

            migrationBuilder.CreateIndex(
                name: "IX_amigos_amigo",
                table: "amigos",
                column: "amigo");

            migrationBuilder.CreateIndex(
                name: "IX_rutas_creador",
                table: "rutas",
                column: "creador");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioRutas_usuario",
                table: "usuarioRutas",
                column: "usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amigos");

            migrationBuilder.DropTable(
                name: "usuarioRutas");

            migrationBuilder.DropTable(
                name: "rutas");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
