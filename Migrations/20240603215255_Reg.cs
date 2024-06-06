using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_APPINT.Migrations
{
    public partial class Reg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    PkTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.PkTipo);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    PkRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.PkRegistro);
                    table.ForeignKey(
                        name: "FK_Registros_Tipos_FkTipo",
                        column: x => x.FkTipo,
                        principalTable: "Tipos",
                        principalColumn: "PkTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "PkTipo", "Nombre" },
                values: new object[] { 1, "Entrada" });

            migrationBuilder.InsertData(
                table: "Registros",
                columns: new[] { "PkRegistro", "Cantidad", "Descripcion", "Fecha", "FkTipo" },
                values: new object[] { 1, "$1999", "Mexicano", "Charly", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_FkTipo",
                table: "Registros",
                column: "FkTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
