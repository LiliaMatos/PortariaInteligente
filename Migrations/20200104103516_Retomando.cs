using Microsoft.EntityFrameworkCore.Migrations;

namespace PortariaInteligente.Migrations
{
    public partial class Retomando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Anfitriaos_AnfitriaoId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_documentos",
                table: "documentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anfitriaos",
                table: "Anfitriaos");

            migrationBuilder.RenameTable(
                name: "documentos",
                newName: "Documentos");

            migrationBuilder.RenameTable(
                name: "Anfitriaos",
                newName: "Anfitrioes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documentos",
                table: "Documentos",
                column: "DocumentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anfitrioes",
                table: "Anfitrioes",
                column: "AnfitriaoId");

            migrationBuilder.CreateTable(
                name: "Convidados",
                columns: table => new
                {
                    ConvidadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeConvidado = table.Column<string>(nullable: false),
                    emailConvidado = table.Column<string>(nullable: false),
                    celConvidado = table.Column<string>(nullable: true),
                    DocumentoId = table.Column<int>(nullable: false),
                    numeroDoctoConvidado = table.Column<string>(nullable: false),
                    placaCarro = table.Column<string>(nullable: true),
                    marcaCarro = table.Column<string>(nullable: true),
                    modeloCarro = table.Column<string>(nullable: true),
                    corCarro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidados", x => x.ConvidadoId);
                    table.ForeignKey(
                        name: "FK_Convidados_Documentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documentos",
                        principalColumn: "DocumentoId",
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
                name: "IX_ConvidadoEventos_ConvidadoId",
                table: "ConvidadoEventos",
                column: "ConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadoEventos_EventoId",
                table: "ConvidadoEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Convidados_DocumentoId",
                table: "Convidados",
                column: "DocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Anfitrioes_AnfitriaoId",
                table: "Eventos",
                column: "AnfitriaoId",
                principalTable: "Anfitrioes",
                principalColumn: "AnfitriaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Anfitrioes_AnfitriaoId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "ConvidadoEventos");

            migrationBuilder.DropTable(
                name: "Convidados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documentos",
                table: "Documentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anfitrioes",
                table: "Anfitrioes");

            migrationBuilder.RenameTable(
                name: "Documentos",
                newName: "documentos");

            migrationBuilder.RenameTable(
                name: "Anfitrioes",
                newName: "Anfitriaos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_documentos",
                table: "documentos",
                column: "DocumentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anfitriaos",
                table: "Anfitriaos",
                column: "AnfitriaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Anfitriaos_AnfitriaoId",
                table: "Eventos",
                column: "AnfitriaoId",
                principalTable: "Anfitriaos",
                principalColumn: "AnfitriaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
