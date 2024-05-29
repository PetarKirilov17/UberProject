using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingIsFreeFieldInVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_free",
                schema: "public",
                table: "Vehicles",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Field that tells whether the vehice is free at the moment.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_free",
                schema: "public",
                table: "Vehicles");
        }
    }
}
