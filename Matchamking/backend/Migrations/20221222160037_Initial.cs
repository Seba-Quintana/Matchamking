using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Nickname = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Jugados = table.Column<int>(type: "int", nullable: false),
                    Victorias = table.Column<int>(type: "int", nullable: false),
                    Empates = table.Column<int>(type: "int", nullable: false),
                    Derrotas = table.Column<int>(type: "int", nullable: false),
                    Elo = table.Column<float>(type: "float", nullable: false),
                    CantRacha = table.Column<int>(type: "int", nullable: false),
                    Resaca = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GolesAFavor = table.Column<int>(type: "int", nullable: false),
                    GolesEnContra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Nickname);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Cancha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Goles = table.Column<int>(type: "int", nullable: false),
                    Suplentes = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PartidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipo_Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo_Jugadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipo_Jugadores_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipo_Jugadores_Jugadores_Nickname",
                        column: x => x.Nickname,
                        principalTable: "Jugadores",
                        principalColumn: "Nickname",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_Jugadores_EquipoId",
                table: "Equipo_Jugadores",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_Jugadores_Nickname",
                table: "Equipo_Jugadores",
                column: "Nickname");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_PartidoId",
                table: "Equipos",
                column: "PartidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo_Jugadores");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}
