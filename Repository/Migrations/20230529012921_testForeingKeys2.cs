using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class testForeingKeys2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Empleados",
                newName: "IdEmpleado");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Activos",
                newName: "IdActivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Empleados",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdActivo",
                table: "Activos",
                newName: "Id");
        }
    }
}
