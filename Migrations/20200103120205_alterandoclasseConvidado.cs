using Microsoft.EntityFrameworkCore.Migrations;

namespace PortariaInteligente.Migrations
{
    public partial class alterandoclasseConvidado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_Carros_carroId",
                table: "Convidados");

            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_TipoDoctos_tipoDoctoId",
                table: "Convidados");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "TipoDoctos");

            migrationBuilder.DropIndex(
                name: "IX_Convidados_carroId",
                table: "Convidados");

            migrationBuilder.DropIndex(
                name: "IX_Convidados_tipoDoctoId",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "carroId",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "tipoDoctoConvidadoId",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "tipoDoctoId",
                table: "Convidados");

            migrationBuilder.AddColumn<string>(
                name: "corCarro",
                table: "Convidados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "marcaCarro",
                table: "Convidados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modeloCarro",
                table: "Convidados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "placaCarro",
                table: "Convidados",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipoDocto",
                table: "Convidados",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "corCarro",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "marcaCarro",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "modeloCarro",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "placaCarro",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "tipoDocto",
                table: "Convidados");

            migrationBuilder.AddColumn<int>(
                name: "carroId",
                table: "Convidados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoDoctoConvidadoId",
                table: "Convidados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoDoctoId",
                table: "Convidados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    corCarro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marcaCarro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    modeloCarro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placaCarro = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroId);
                });

            migrationBuilder.CreateTable(
                name: "TipoDoctos",
                columns: table => new
                {
                    tipoDoctoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeDocto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDoctos", x => x.tipoDoctoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Convidados_carroId",
                table: "Convidados",
                column: "carroId");

            migrationBuilder.CreateIndex(
                name: "IX_Convidados_tipoDoctoId",
                table: "Convidados",
                column: "tipoDoctoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convidados_Carros_carroId",
                table: "Convidados",
                column: "carroId",
                principalTable: "Carros",
                principalColumn: "CarroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Convidados_TipoDoctos_tipoDoctoId",
                table: "Convidados",
                column: "tipoDoctoId",
                principalTable: "TipoDoctos",
                principalColumn: "tipoDoctoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
