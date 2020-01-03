using Microsoft.EntityFrameworkCore.Migrations;

namespace PortariaInteligente.Migrations
{
    public partial class folderData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carros_Convidados_ConvidadoId",
                table: "carros");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvidadoEventos_Convidados_ConvidadoId",
                table: "ConvidadoEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvidadoEventos_Eventos_EventoId",
                table: "ConvidadoEventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carros",
                table: "carros");

            migrationBuilder.DropIndex(
                name: "IX_carros_ConvidadoId",
                table: "carros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConvidadoEventos",
                table: "ConvidadoEventos");

            migrationBuilder.DropColumn(
                name: "doctoConvidado",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "ConvidadoId",
                table: "carros");

            migrationBuilder.RenameTable(
                name: "carros",
                newName: "Carros");

            migrationBuilder.RenameTable(
                name: "ConvidadoEventos",
                newName: "ConvidadosEventos");

            migrationBuilder.RenameIndex(
                name: "IX_ConvidadoEventos_EventoId",
                table: "ConvidadosEventos",
                newName: "IX_ConvidadosEventos_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_ConvidadoEventos_ConvidadoId",
                table: "ConvidadosEventos",
                newName: "IX_ConvidadosEventos_ConvidadoId");

            migrationBuilder.AddColumn<int>(
                name: "carroId",
                table: "Convidados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "numeroDoctoConvidado",
                table: "Convidados",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "tipoDoctoConvidadoId",
                table: "Convidados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipoDoctoId",
                table: "Convidados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carros",
                table: "Carros",
                column: "CarroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConvidadosEventos",
                table: "ConvidadosEventos",
                column: "ConvidadoEventoId");

            migrationBuilder.CreateTable(
                name: "TipoDoctos",
                columns: table => new
                {
                    tipoDoctoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeDocto = table.Column<string>(nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_ConvidadosEventos_Convidados_ConvidadoId",
                table: "ConvidadosEventos",
                column: "ConvidadoId",
                principalTable: "Convidados",
                principalColumn: "ConvidadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvidadosEventos_Eventos_EventoId",
                table: "ConvidadosEventos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_Carros_carroId",
                table: "Convidados");

            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_TipoDoctos_tipoDoctoId",
                table: "Convidados");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvidadosEventos_Convidados_ConvidadoId",
                table: "ConvidadosEventos");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvidadosEventos_Eventos_EventoId",
                table: "ConvidadosEventos");

            migrationBuilder.DropTable(
                name: "TipoDoctos");

            migrationBuilder.DropIndex(
                name: "IX_Convidados_carroId",
                table: "Convidados");

            migrationBuilder.DropIndex(
                name: "IX_Convidados_tipoDoctoId",
                table: "Convidados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carros",
                table: "Carros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConvidadosEventos",
                table: "ConvidadosEventos");

            migrationBuilder.DropColumn(
                name: "carroId",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "numeroDoctoConvidado",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "tipoDoctoConvidadoId",
                table: "Convidados");

            migrationBuilder.DropColumn(
                name: "tipoDoctoId",
                table: "Convidados");

            migrationBuilder.RenameTable(
                name: "Carros",
                newName: "carros");

            migrationBuilder.RenameTable(
                name: "ConvidadosEventos",
                newName: "ConvidadoEventos");

            migrationBuilder.RenameIndex(
                name: "IX_ConvidadosEventos_EventoId",
                table: "ConvidadoEventos",
                newName: "IX_ConvidadoEventos_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_ConvidadosEventos_ConvidadoId",
                table: "ConvidadoEventos",
                newName: "IX_ConvidadoEventos_ConvidadoId");

            migrationBuilder.AddColumn<string>(
                name: "doctoConvidado",
                table: "Convidados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ConvidadoId",
                table: "carros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_carros",
                table: "carros",
                column: "CarroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConvidadoEventos",
                table: "ConvidadoEventos",
                column: "ConvidadoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_carros_ConvidadoId",
                table: "carros",
                column: "ConvidadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_carros_Convidados_ConvidadoId",
                table: "carros",
                column: "ConvidadoId",
                principalTable: "Convidados",
                principalColumn: "ConvidadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvidadoEventos_Convidados_ConvidadoId",
                table: "ConvidadoEventos",
                column: "ConvidadoId",
                principalTable: "Convidados",
                principalColumn: "ConvidadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvidadoEventos_Eventos_EventoId",
                table: "ConvidadoEventos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
