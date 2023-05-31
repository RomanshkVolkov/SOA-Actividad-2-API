using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class testForeingKeys3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Activos_Empleados",
                newName: "EmpleadoIdEmpleado");

            migrationBuilder.RenameColumn(
                name: "IdActivo",
                table: "Activos_Empleados",
                newName: "ActivoIdActivo");

            migrationBuilder.CreateIndex(
                name: "IX_Activos_Empleados_ActivoIdActivo",
                table: "Activos_Empleados",
                column: "ActivoIdActivo");

            migrationBuilder.CreateIndex(
                name: "IX_Activos_Empleados_EmpleadoIdEmpleado",
                table: "Activos_Empleados",
                column: "EmpleadoIdEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Activos_Empleados_Activos_ActivoIdActivo",
                table: "Activos_Empleados",
                column: "ActivoIdActivo",
                principalTable: "Activos",
                principalColumn: "IdActivo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activos_Empleados_Empleados_EmpleadoIdEmpleado",
                table: "Activos_Empleados",
                column: "EmpleadoIdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activos_Empleados_Activos_ActivoIdActivo",
                table: "Activos_Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Activos_Empleados_Empleados_EmpleadoIdEmpleado",
                table: "Activos_Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Activos_Empleados_ActivoIdActivo",
                table: "Activos_Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Activos_Empleados_EmpleadoIdEmpleado",
                table: "Activos_Empleados");

            migrationBuilder.RenameColumn(
                name: "EmpleadoIdEmpleado",
                table: "Activos_Empleados",
                newName: "IdEmpleado");

            migrationBuilder.RenameColumn(
                name: "ActivoIdActivo",
                table: "Activos_Empleados",
                newName: "IdActivo");
        }
    }
}
