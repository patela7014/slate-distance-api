using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateProjectionData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionData_Building_BuildingId",
                table: "ProjectionData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionData_Employee_EmployeeId",
                table: "ProjectionData");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "ProjectionData",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "ProjectionData",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "BuildingAddress",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingCity",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingCountry",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingState",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingTitle",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuildingZip",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeAddress",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCity",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCountry",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeState",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeZip",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ProjectionData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Submarket",
                table: "ProjectionData",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionData_Building_BuildingId",
                table: "ProjectionData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectionData_Employee_EmployeeId",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "BuildingAddress",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "BuildingCity",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "BuildingCountry",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "BuildingState",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "BuildingTitle",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "BuildingZip",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "EmployeeAddress",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "EmployeeCity",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "EmployeeCountry",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "EmployeeState",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "EmployeeZip",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ProjectionData");

            migrationBuilder.DropColumn(
                name: "Submarket",
                table: "ProjectionData");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "ProjectionData",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "ProjectionData",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionData_Building_BuildingId",
                table: "ProjectionData",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectionData_Employee_EmployeeId",
                table: "ProjectionData",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
