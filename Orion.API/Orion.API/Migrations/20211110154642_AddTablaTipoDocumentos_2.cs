using Microsoft.EntityFrameworkCore.Migrations;

namespace Orion.API.Migrations
{
    public partial class AddTablaTipoDocumentos_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abreviatura",
                table: "T_TipoDocumentos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abreviatura",
                table: "T_TipoDocumentos");
        }
    }
}
