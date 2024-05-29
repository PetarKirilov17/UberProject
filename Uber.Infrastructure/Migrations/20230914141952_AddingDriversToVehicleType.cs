using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingDriversToVehicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicle_type_drivers_driver_id",
                table: "VehicleType");

            migrationBuilder.DropIndex(
                name: "ix_vehicle_type_driver_id",
                table: "VehicleType");

            migrationBuilder.DropColumn(
                name: "driver_id",
                table: "VehicleType");

            migrationBuilder.CreateTable(
                name: "driver_vehicle_type",
                columns: table => new
                {
                    drivers_driver_id = table.Column<int>(type: "integer", nullable: false),
                    vehicle_categories_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_driver_vehicle_type", x => new { x.drivers_driver_id, x.vehicle_categories_type_id });
                    table.ForeignKey(
                        name: "fk_driver_vehicle_type_drivers_drivers_driver_id",
                        column: x => x.drivers_driver_id,
                        principalTable: "drivers",
                        principalColumn: "driver_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_driver_vehicle_type_vehicle_types_vehicle_categories_type_id",
                        column: x => x.vehicle_categories_type_id,
                        principalTable: "VehicleType",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_driver_vehicle_type_vehicle_categories_type_id",
                table: "driver_vehicle_type",
                column: "vehicle_categories_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "driver_vehicle_type");

            migrationBuilder.AddColumn<int>(
                name: "driver_id",
                table: "VehicleType",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_type_driver_id",
                table: "VehicleType",
                column: "driver_id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicle_type_drivers_driver_id",
                table: "VehicleType",
                column: "driver_id",
                principalTable: "drivers",
                principalColumn: "driver_id");
        }
    }
}
