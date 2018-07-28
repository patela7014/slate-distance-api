using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    MidName = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_User_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AverageDistance = table.Column<string>(nullable: true),
                    AverageDuration = table.Column<float>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_User_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Submarket = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Building_User_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Building_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectionData",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Duration = table.Column<float>(nullable: false),
                    Distance = table.Column<float>(nullable: false),
                    ReportId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectionData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectionData_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectionData_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectionData_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectionData_User_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectionData_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportProjection",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReportId = table.Column<int>(nullable: false),
                    ProjectionDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportProjection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportProjection_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportProjection_User_LastUpdatedBy",
                        column: x => x.LastUpdatedBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportProjection_ProjectionData_ProjectionDataId",
                        column: x => x.ProjectionDataId,
                        principalTable: "ProjectionData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportProjection_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Building_CreatedBy",
                table: "Building",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Building_LastUpdatedBy",
                table: "Building",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Building_ProjectId",
                table: "Building",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreatedBy",
                table: "Employee",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LastUpdatedBy",
                table: "Employee",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedBy",
                table: "Project",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Project_LastUpdatedBy",
                table: "Project",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_BuildingId",
                table: "ProjectionData",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_CreatedBy",
                table: "ProjectionData",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_EmployeeId",
                table: "ProjectionData",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_LastUpdatedBy",
                table: "ProjectionData",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectionData_ReportId",
                table: "ProjectionData",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CreatedBy",
                table: "Report",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Report_LastUpdatedBy",
                table: "Report",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProjection_CreatedBy",
                table: "ReportProjection",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProjection_LastUpdatedBy",
                table: "ReportProjection",
                column: "LastUpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProjection_ProjectionDataId",
                table: "ReportProjection",
                column: "ProjectionDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportProjection_ReportId",
                table: "ReportProjection",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportProjection");

            migrationBuilder.DropTable(
                name: "ProjectionData");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
