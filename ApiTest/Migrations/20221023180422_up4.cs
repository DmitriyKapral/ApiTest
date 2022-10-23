using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiTest.Migrations
{
    /// <inheritdoc />
    public partial class up4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesProjects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectsId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectsId",
                table: "Employees",
                column: "ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectsId",
                table: "Employees",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectsId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectsId",
                table: "Employees");

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
    }
}
