using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_APPINT.Migrations
{
    public partial class Autor91 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "PkAutor", "Nacionalidad", "Nombre" },
                values: new object[] { 1, "Mexicano", "Charly" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autores",
                keyColumn: "PkAutor",
                keyValue: 1);
        }
    }
}
