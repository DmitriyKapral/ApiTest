using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiTest.Migrations
{
    /// <inheritdoc />
    public partial class testdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nav_O_Fsks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    iindex = table.Column<string>(name: "i_index", type: "text", nullable: true),
                    iarea = table.Column<string>(name: "i_area", type: "text", nullable: true),
                    icity = table.Column<string>(name: "i_city", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nav_O_Fsks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nav_O_Ias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    iindex = table.Column<string>(name: "i_index", type: "text", nullable: true),
                    iarea = table.Column<string>(name: "i_area", type: "text", nullable: true),
                    icity = table.Column<string>(name: "i_city", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nav_O_Ias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nav_O_Ias_nav_O_Fsks_ParentId",
                        column: x => x.ParentId,
                        principalTable: "nav_O_Fsks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "nav_O_Mes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    iindex = table.Column<string>(name: "i_index", type: "text", nullable: true),
                    iarea = table.Column<string>(name: "i_area", type: "text", nullable: true),
                    icity = table.Column<string>(name: "i_city", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nav_O_Mes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nav_O_Mes_nav_O_Fsks_ParentId",
                        column: x => x.ParentId,
                        principalTable: "nav_O_Fsks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "nav_O_Pmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    iindex = table.Column<string>(name: "i_index", type: "text", nullable: true),
                    iarea = table.Column<string>(name: "i_area", type: "text", nullable: true),
                    icity = table.Column<string>(name: "i_city", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nav_O_Pmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nav_O_Pmes_nav_O_Mes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "nav_O_Mes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "nav_O_Substations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    iindex = table.Column<string>(name: "i_index", type: "text", nullable: true),
                    iarea = table.Column<string>(name: "i_area", type: "text", nullable: true),
                    icity = table.Column<string>(name: "i_city", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nav_O_Substations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nav_O_Substations_nav_O_Pmes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "nav_O_Pmes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_nav_O_Ias_ParentId",
                table: "nav_O_Ias",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_nav_O_Mes_ParentId",
                table: "nav_O_Mes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_nav_O_Pmes_ParentId",
                table: "nav_O_Pmes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_nav_O_Substations_ParentId",
                table: "nav_O_Substations",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nav_O_Ias");

            migrationBuilder.DropTable(
                name: "nav_O_Substations");

            migrationBuilder.DropTable(
                name: "nav_O_Pmes");

            migrationBuilder.DropTable(
                name: "nav_O_Mes");

            migrationBuilder.DropTable(
                name: "nav_O_Fsks");
        }
    }
}
