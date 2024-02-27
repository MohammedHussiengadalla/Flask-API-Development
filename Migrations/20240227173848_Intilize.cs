using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flask_API_Development.Migrations
{
    public partial class Intilize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "testCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "executionResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestCaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    TestAssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_executionResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_executionResults_testCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "testCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_executionResults_TestCaseId",
                table: "executionResults",
                column: "TestCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "executionResults");

            migrationBuilder.DropTable(
                name: "testCases");
        }
    }
}
