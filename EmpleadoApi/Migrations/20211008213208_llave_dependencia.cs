using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpleadoApi.Migrations
{
    public partial class llave_dependencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idDependencia",
                table: "empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idDependencia",
                table: "empleados");
        }
    }
}
