using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortariaInteligente.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anfitriaos",
                columns: table => new
                {
                    AnfitriaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeAnfitriao = table.Column<string>(nullable: true),
                    emailAnfitriao = table.Column<string>(nullable: true),
                    celAnfitriao = table.Column<string>(nullable: true),
                    telAnfitriao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anfitriaos", x => x.AnfitriaoId);
                });

            migrationBuilder.CreateTable(
                name: "Convidados",
                columns: table => new
                {
                    ConvidadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeConvidado = table.Column<string>(nullable: true),
                    emailConvidado = table.Column<string>(nullable: true),
                    celConvidado = table.Column<string>(nullable: true),
                    doctoConvidado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidados", x => x.ConvidadoId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEvento = table.Column<string>(nullable: true),
                    dataEvento = table.Column<DateTime>(nullable: false),
                    horaEvento = table.Column<DateTime>(nullable: false),
                    localEvento = table.Column<string>(nullable: true),
                    AnfitriaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Anfitriaos_AnfitriaoId",
                        column: x => x.AnfitriaoId,
                        principalTable: "Anfitriaos",
                        principalColumn: "AnfitriaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carros",
                columns: table => new
                {
                    CarroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placaCarro = table.Column<string>(nullable: true),
                    marcaCarro = table.Column<string>(nullable: true),
                    modeloCarro = table.Column<string>(nullable: true),
                    corCarro = table.Column<string>(nullable: true),
                    ConvidadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carros", x => x.CarroId);
                    table.ForeignKey(
                        name: "FK_carros_Convidados_ConvidadoId",
                        column: x => x.ConvidadoId,
                        principalTable: "Convidados",
                        principalColumn: "ConvidadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConvidadoEventos",
                columns: table => new
                {
                    ConvidadoEventoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoId = table.Column<int>(nullable: false),
                    ConvidadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvidadoEventos", x => x.ConvidadoEventoId);
                    table.ForeignKey(
                        name: "FK_ConvidadoEventos_Convidados_ConvidadoId",
                        column: x => x.ConvidadoId,
                        principalTable: "Convidados",
                        principalColumn: "ConvidadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvidadoEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carros_ConvidadoId",
                table: "carros",
                column: "ConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadoEventos_ConvidadoId",
                table: "ConvidadoEventos",
                column: "ConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadoEventos_EventoId",
                table: "ConvidadoEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_AnfitriaoId",
                table: "Eventos",
                column: "AnfitriaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carros");

            migrationBuilder.DropTable(
                name: "ConvidadoEventos");

            migrationBuilder.DropTable(
                name: "Convidados");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Anfitriaos");
        }
    }
}
