using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ultragamma.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoSexoTablaProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Producto");
        }
    }
}
