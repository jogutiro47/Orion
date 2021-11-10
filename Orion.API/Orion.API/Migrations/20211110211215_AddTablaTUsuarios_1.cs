using Microsoft.EntityFrameworkCore.Migrations;

namespace Orion.API.Migrations
{
    public partial class AddTablaTUsuarios_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Usuarios_T_TipoDocumentos_IdDocumentoId",
                        column: x => x.IdDocumentoId,
                        principalTable: "T_TipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_IdDocumentoId",
                table: "T_Usuarios",
                column: "IdDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Usuarios_Nro_Documento",
                table: "T_Usuarios",
                column: "Nro_Documento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Usuarios");
        }
    }
}
