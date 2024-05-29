using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class SeedingVehiclesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Vehicles",
                schema: "UberDb",
                newName: "Vehicles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "UberDb");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicles",
                newSchema: "UberDb");
        }
    }
}
