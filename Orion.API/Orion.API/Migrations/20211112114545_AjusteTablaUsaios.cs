using Microsoft.EntityFrameworkCore.Migrations;

namespace Orion.API.Migrations
{
    public partial class AjusteTablaUsaios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "T_Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "T_Usuarios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "T_Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "T_Usuarios");
        }
    }
}
