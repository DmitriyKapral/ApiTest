using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTest.Migrations
{
    /// <inheritdoc />
    public partial class up3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmployeesId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmployeesId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmployeesId1",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "EmployeesProjects",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "integer", nullable: false),
                    ProjectsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesProjects", x => new { x.EmployeesId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeesProjects_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesProjects_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesProjects_ProjectsId",
                table: "EmployeesProjects",
                column: "ProjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesProjects");

            migrationBuilder.AddColumn<List<int>>(
                name: "EmployeesId",
                table: "Projects",
                type: "integer[]",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId1",
                table: "Projects",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeesId1",
                table: "Projects",
                column: "EmployeesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmployeesId1",
                table: "Projects",
                column: "EmployeesId1",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
