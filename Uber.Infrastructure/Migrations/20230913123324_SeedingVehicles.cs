using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class SeedingVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehicle_types_vehicle_type_id",
                table: "vehicles");

            migrationBuilder.EnsureSchema(
                name: "UberDb");

            migrationBuilder.RenameTable(
                name: "vehicles",
                newName: "Vehicles",
                newSchema: "UberDb");

            migrationBuilder.InsertData(
                schema: "UberDb",
                table: "Vehicles",
                columns: new[] { "vehicle_id", "brand", "max_seats", "model", "vehicle_type_id", "year_of_production" },
                values: new object[,]
                {
                    { 1, "BMW", (short)5, "X4", 1, (short)2020 },
                    { 2, "Audi", (short)5, "A6", 1, (short)2019 }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehicle_type_vehicle_type_id",
                schema: "UberDb",
                table: "Vehicles",
                column: "vehicle_type_id",
                principalTable: "VehicleType",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehicle_type_vehicle_type_id",
                schema: "UberDb",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                schema: "UberDb",
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "UberDb",
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Vehicles",
                schema: "UberDb",
                newName: "vehicles");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehicle_types_vehicle_type_id",
                table: "vehicles",
                column: "vehicle_type_id",
                principalTable: "VehicleType",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
