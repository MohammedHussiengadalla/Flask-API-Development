using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flask_API_Development.Migrations
{
    public partial class NewIntilize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestAssetId",
                table: "executionResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestAssetId",
                table: "executionResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
