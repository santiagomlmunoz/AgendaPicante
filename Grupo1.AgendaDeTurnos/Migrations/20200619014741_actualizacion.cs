using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupo1.AgendaDeTurnos.Migrations
{
    public partial class actualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    DuracionHoras = table.Column<int>(maxLength: 2, nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    IdPaciente = table.Column<int>(nullable: false),
                    IdProfesional = table.Column<int>(nullable: false),
                    IdCentro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Dni = table.Column<string>(nullable: true),
                    Rol = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<byte[]>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PrestacionId = table.Column<int>(nullable: true),
                    CentroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Prestaciones_PrestacionId",
                        column: x => x.PrestacionId,
                        principalTable: "Prestaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calle = table.Column<string>(maxLength: 100, nullable: false),
                    Altura = table.Column<int>(maxLength: 10, nullable: false),
                    Localidad = table.Column<string>(maxLength: 100, nullable: false),
                    Provincia = table.Column<string>(maxLength: 100, nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direcciones_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dia = table.Column<int>(nullable: false),
                    HoraDesde = table.Column<int>(nullable: false),
                    HoraHasta = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    IdProfesional = table.Column<int>(nullable: false),
                    PorfesionalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disponibilidades_Usuario_PorfesionalId",
                        column: x => x.PorfesionalId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mails_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    NumeroCelular = table.Column<string>(maxLength: 12, nullable: false),
                    TelefonoAlternativo = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefonos_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Centros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    DireccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Centros_Direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Centros_DireccionId",
                table: "Centros",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_IdUsuario",
                table: "Direcciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_PorfesionalId",
                table: "Disponibilidades",
                column: "PorfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Mails_IdUsuario",
                table: "Mails",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_IdUsuario",
                table: "Telefonos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdCentro",
                table: "Turnos",
                column: "IdCentro");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdPaciente",
                table: "Turnos",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_IdProfesional",
                table: "Turnos",
                column: "IdProfesional");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CentroId",
                table: "Usuario",
                column: "CentroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PrestacionId",
                table: "Usuario",
                column: "PrestacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Usuario_IdPaciente",
                table: "Turnos",
                column: "IdPaciente",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Turnos_Usuario_IdProfesional",
            //    table: "Turnos",
            //    column: "IdProfesional",
            //    principalTable: "Usuario",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Turnos_Centros_IdCentro",
            //    table: "Turnos",
            //    column: "IdCentro",
            //    principalTable: "Centros",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Usuario_Centros_CentroId",
            //    table: "Usuario",
            //    column: "CentroId",
            //    principalTable: "Centros",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centros_Direcciones_DireccionId",
                table: "Centros");

            migrationBuilder.DropTable(
                name: "Disponibilidades");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Centros");

            migrationBuilder.DropTable(
                name: "Prestaciones");
        }
    }
}
