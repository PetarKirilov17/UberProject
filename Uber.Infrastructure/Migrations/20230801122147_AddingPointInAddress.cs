using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingPointInAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlPoint>(
                name: "current_position",
                table: "drivers",
                type: "point",
                nullable: true);

            migrationBuilder.AddColumn<NpgsqlPoint>(
                name: "location",
                table: "addresses",
                type: "point",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "current_position",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "location",
                table: "addresses");
        }
    }
}
