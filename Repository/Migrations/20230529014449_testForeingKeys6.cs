using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class testForeingKeys6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activos_Empleados_Activos_ActivoIdActivo",
                table: "Activos_Empleados");

            migrationBuilder.RenameColumn(
                name: "IdPersona",
                table: "Empleados",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "ActivoIdActivo",
                table: "Activos_Empleados",
                newName: "ActivoId");

            migrationBuilder.RenameIndex(
                name: "IX_Activos_Empleados_ActivoIdActivo",
                table: "Activos_Empleados",
                newName: "IX_Activos_Empleados_ActivoId");

            migrationBuilder.RenameColumn(
                name: "IdActivo",
                table: "Activos",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PersonaId",
                table: "Empleados",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activos_Empleados_Activos_ActivoId",
                table: "Activos_Empleados",
                column: "ActivoId",
                principalTable: "Activos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Personas_PersonaId",
                table: "Empleados",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activos_Empleados_Activos_ActivoId",
                table: "Activos_Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Personas_PersonaId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PersonaId",
                table: "Empleados");

            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "Empleados",
                newName: "IdPersona");

            migrationBuilder.RenameColumn(
                name: "ActivoId",
                table: "Activos_Empleados",
                newName: "ActivoIdActivo");

            migrationBuilder.RenameIndex(
                name: "IX_Activos_Empleados_ActivoId",
                table: "Activos_Empleados",
                newName: "IX_Activos_Empleados_ActivoIdActivo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Activos",
                newName: "IdActivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Activos_Empleados_Activos_ActivoIdActivo",
                table: "Activos_Empleados",
                column: "ActivoIdActivo",
                principalTable: "Activos",
                principalColumn: "IdActivo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
