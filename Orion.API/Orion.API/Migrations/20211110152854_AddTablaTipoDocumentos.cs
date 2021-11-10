using Microsoft.EntityFrameworkCore.Migrations;

namespace Orion.API.Migrations
{
    public partial class AddTablaTipoDocumentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_TipoDocumentos_DescripcionDocumento",
                table: "T_TipoDocumentos",
                column: "DescripcionDocumento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_TipoDocumentos");
        }
    }
}
