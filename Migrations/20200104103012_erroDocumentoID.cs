using Microsoft.EntityFrameworkCore.Migrations;

namespace PortariaInteligente.Migrations
{
    public partial class erroDocumentoID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvidadosEventos");

            migrationBuilder.DropTable(
                name: "Convidados");

            migrationBuilder.DropColumn(
                name: "telAnfitriao",
                table: "Anfitriaos");

            migrationBuilder.AlterColumn<string>(
                name: "nomeAnfitriao",
                table: "Anfitriaos",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "fixoAnfitriao",
                table: "Anfitriaos",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "documentos",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeDocumento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentos", x => x.DocumentoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documentos");

            migrationBuilder.DropColumn(
                name: "fixoAnfitriao",
                table: "Anfitriaos");

            migrationBuilder.AlterColumn<string>(
                name: "nomeAnfitriao",
                table: "Anfitriaos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "telAnfitriao",
                table: "Anfitriaos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Convidados",
                columns: table => new
                {
                    ConvidadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    celConvidado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    corCarro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailConvidado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marcaCarro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modeloCarro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomeConvidado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroDoctoConvidado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    placaCarro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoDocto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convidados", x => x.ConvidadoId);
                });

            migrationBuilder.CreateTable(
                name: "ConvidadosEventos",
                columns: table => new
                {
                    ConvidadoEventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConvidadoId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvidadosEventos", x => x.ConvidadoEventoId);
                    table.ForeignKey(
                        name: "FK_ConvidadosEventos_Convidados_ConvidadoId",
                        column: x => x.ConvidadoId,
                        principalTable: "Convidados",
                        principalColumn: "ConvidadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvidadosEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadosEventos_ConvidadoId",
                table: "ConvidadosEventos",
                column: "ConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadosEventos_EventoId",
                table: "ConvidadosEventos",
                column: "EventoId");
        }
    }
}
