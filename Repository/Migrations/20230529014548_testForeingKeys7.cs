using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class testForeingKeys7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activos_Empleados_Empleados_EmpleadoIdEmpleado",
                table: "Activos_Empleados");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Empleados",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EmpleadoIdEmpleado",
                table: "Activos_Empleados",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Activos_Empleados_EmpleadoIdEmpleado",
                table: "Activos_Empleados",
                newName: "IX_Activos_Empleados_EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activos_Empleados_Empleados_EmpleadoId",
                table: "Activos_Empleados",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activos_Empleados_Empleados_EmpleadoId",
                table: "Activos_Empleados");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Empleados",
                newName: "IdEmpleado");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Activos_Empleados",
                newName: "EmpleadoIdEmpleado");

            migrationBuilder.RenameIndex(
                name: "IX_Activos_Empleados_EmpleadoId",
                table: "Activos_Empleados",
                newName: "IX_Activos_Empleados_EmpleadoIdEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Activos_Empleados_Empleados_EmpleadoIdEmpleado",
                table: "Activos_Empleados",
                column: "EmpleadoIdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
