using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateProjectionDataClean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionData_Building_BuildingId",
                table: "ProjectionData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionData_Employee_EmployeeId",
                table: "ProjectionData");

            migrationBuilder.DropIndex(
                name: "IX_ProjectionData_BuildingId",
                table: "ProjectionData");

            migrationBuilder.DropIndex(
                name: "IX_ProjectionData_EmployeeId",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ProjectionData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_BuildingId",
                table: "ProjectionData",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_EmployeeId",
                table: "ProjectionData",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionData_Building_BuildingId",
                table: "ProjectionData",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionData_Employee_EmployeeId",
                table: "ProjectionData",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
