using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupo1.AgendaDeTurnos.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disponibilidades_Usuario_PorfesionalId",
                table: "Disponibilidades");

            migrationBuilder.DropIndex(
                name: "IX_Disponibilidades_PorfesionalId",
                table: "Disponibilidades");

            migrationBuilder.DropColumn(
                name: "PorfesionalId",
                table: "Disponibilidades");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Turnos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Monto",
                table: "Prestaciones",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_IdProfesional",
                table: "Disponibilidades",
                column: "IdProfesional");

            migrationBuilder.AddForeignKey(
                name: "FK_Disponibilidades_Usuario_IdProfesional",
                table: "Disponibilidades",
                column: "IdProfesional",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disponibilidades_Usuario_IdProfesional",
                table: "Disponibilidades");

            migrationBuilder.DropIndex(
                name: "IX_Disponibilidades_IdProfesional",
                table: "Disponibilidades");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Turnos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Prestaciones",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PorfesionalId",
                table: "Disponibilidades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_PorfesionalId",
                table: "Disponibilidades",
                column: "PorfesionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disponibilidades_Usuario_PorfesionalId",
                table: "Disponibilidades",
                column: "PorfesionalId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
