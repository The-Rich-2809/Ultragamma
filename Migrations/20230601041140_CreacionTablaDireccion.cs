using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ultragamma.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablaDireccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumExt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumInt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alcaldia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direccion");
        }
    }
}
