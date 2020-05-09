using Microsoft.EntityFrameworkCore.Migrations;

namespace PortariaInteligente.Migrations
{
    public partial class AddingVisitado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Anfitrioes_AnfitriaoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_AnfitriaoId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "Anfitrioes");

            migrationBuilder.DropColumn(
                name: "AnfitriaoId",
                table: "Eventos");

            migrationBuilder.CreateTable(
                name: "Visitados",
                columns: table => new
                {
                    VisitadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeVisitado = table.Column<string>(maxLength: 150, nullable: false),
                    emailVisitado = table.Column<string>(nullable: false),
                    celVisitado = table.Column<string>(nullable: true),
                    fixoVisitado = table.Column<string>(nullable: false),
                    senhaVisitado = table.Column<string>(nullable: true),
                    tokenVisitado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitados", x => x.VisitadoId);
                });

            migrationBuilder.AddColumn<int>(
                name: "VisitadoId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_VisitadoId",
                table: "Eventos",
                column: "VisitadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Visitados_VisitadoId",
                table: "Eventos",
                column: "VisitadoId",
                principalTable: "Visitados",
                principalColumn: "VisitadoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Anfitrioes_AnfitriaoId",
                table: "Eventos",
                column: "AnfitriaoId",
                principalTable: "Anfitrioes",
                principalColumn: "AnfitriaoId",
                onDelete: ReferentialAction.Cascade);


            migrationBuilder.CreateIndex(
                name: "IX_Eventos_AnfitriaoId",
                table: "Eventos",
                column: "AnfitriaoId");


            migrationBuilder.AddColumn<int>(
                name: "AnfitriaoId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Anfitrioes",
                columns: table => new
                {
                    AnfitriaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    celAnfitriao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailAnfitriao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fixoAnfitriao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeAnfitriao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    senhaAnfitriao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tokenAnfitiao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anfitrioes", x => x.AnfitriaoId);
                });


        }
    }
}
