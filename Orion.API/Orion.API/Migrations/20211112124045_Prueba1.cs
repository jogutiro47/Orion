using Microsoft.EntityFrameworkCore.Migrations;

namespace Orion.API.Migrations
{
    public partial class Prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Usuarios_T_TipoDocumentos_IdDocumentoId",
                table: "T_Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumentoId",
                table: "T_Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Usuarios_T_TipoDocumentos_IdDocumentoId",
                table: "T_Usuarios",
                column: "IdDocumentoId",
                principalTable: "T_TipoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Usuarios_T_TipoDocumentos_IdDocumentoId",
                table: "T_Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumentoId",
                table: "T_Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_Usuarios_T_TipoDocumentos_IdDocumentoId",
                table: "T_Usuarios",
                column: "IdDocumentoId",
                principalTable: "T_TipoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
