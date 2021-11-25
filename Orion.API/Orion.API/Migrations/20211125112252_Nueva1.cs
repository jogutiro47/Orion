using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orion.API.Migrations
{
    public partial class Nueva1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Eps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescEPS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Eps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_FuenteContactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_fuente_contacto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_FuenteContactos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescGenero = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_TipoVinculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoVinculacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_TipoVinculations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_Tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc_Tratamiento = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Tratamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Nro_Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGeneroId = table.Column<int>(type: "int", nullable: false),
                    IdEpsId = table.Column<int>(type: "int", nullable: true),
                    IdVinculacionId = table.Column<int>(type: "int", nullable: true),
                    IdTratamientoId = table.Column<int>(type: "int", nullable: false),
                    IdFuenteContactoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Usuarios_t_Eps_IdEpsId",
                        column: x => x.IdEpsId,
                        principalTable: "t_Eps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_Usuarios_t_FuenteContactos_IdFuenteContactoId",
                        column: x => x.IdFuenteContactoId,
                        principalTable: "t_FuenteContactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Usuarios_T_Generos_IdGeneroId",
                        column: x => x.IdGeneroId,
                        principalTable: "T_Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Usuarios_T_TipoDocumentos_IdDocumentoId",
                        column: x => x.IdDocumentoId,
                        principalTable: "T_TipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Usuarios_t_TipoVinculations_IdVinculacionId",
                        column: x => x.IdVinculacionId,
                        principalTable: "t_TipoVinculations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_Usuarios_t_Tratamientos_IdTratamientoId",
                        column: x => x.IdTratamientoId,
                        principalTable: "t_Tratamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Id_MedicoId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_Citas_t_Medicos_Id_MedicoId",
                        column: x => x.Id_MedicoId,
                        principalTable: "t_Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_Citas_T_Usuarios_Id_UsuarioId",
                        column: x => x.Id_UsuarioId,
                        principalTable: "T_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_Citas_Id_MedicoId",
                table: "t_Citas",
                column: "Id_MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Citas_Id_UsuarioId",
                table: "t_Citas",
                column: "Id_UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_t_Eps_DescEPS",
                table: "t_Eps",
                column: "DescEPS",
                unique: true,
                filter: "[DescEPS] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_t_FuenteContactos_Desc_fuente_contacto",
                table: "t_FuenteContactos",
                column: "Desc_fuente_contacto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Generos_DescGenero",
                table: "T_Generos",
                column: "DescGenero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_Medicos_NombreMedico",
                table: "t_Medicos",
                column: "NombreMedico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_TipoDocumentos_DescripcionDocumento",
                table: "T_TipoDocumentos",
                column: "DescripcionDocumento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_TipoVinculations_DescTipoVinculacion",
                table: "t_TipoVinculations",
                column: "DescTipoVinculacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_Tratamientos_Desc_Tratamiento",
                table: "t_Tratamientos",
                column: "Desc_Tratamiento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdDocumentoId",
                table: "T_Usuarios",
                column: "IdDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdEpsId",
                table: "T_Usuarios",
                column: "IdEpsId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdFuenteContactoId",
                table: "T_Usuarios",
                column: "IdFuenteContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdGeneroId",
                table: "T_Usuarios",
                column: "IdGeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdTratamientoId",
                table: "T_Usuarios",
                column: "IdTratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdVinculacionId",
                table: "T_Usuarios",
                column: "IdVinculacionId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_Nro_Documento",
                table: "T_Usuarios",
                column: "Nro_Documento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Citas");

            migrationBuilder.DropTable(
                name: "t_Medicos");

            migrationBuilder.DropTable(
                name: "T_Usuarios");

            migrationBuilder.DropTable(
                name: "t_Eps");

            migrationBuilder.DropTable(
                name: "t_FuenteContactos");

            migrationBuilder.DropTable(
                name: "T_Generos");

            migrationBuilder.DropTable(
                name: "T_TipoDocumentos");

            migrationBuilder.DropTable(
                name: "t_TipoVinculations");

            migrationBuilder.DropTable(
                name: "t_Tratamientos");
        }
    }
}
