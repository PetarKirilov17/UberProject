using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class RemovingIntegerPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "current_position",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "location",
                table: "addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "current_position",
                table: "drivers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "location",
                table: "addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
