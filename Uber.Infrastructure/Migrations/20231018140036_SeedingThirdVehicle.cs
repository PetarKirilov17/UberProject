using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class SeedingThirdVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: 2);

            migrationBuilder.InsertData(
                schema: "public",
                table: "Vehicles",
                columns: new[] { "vehicle_id", "brand", "max_seats", "model", "vehicle_type_id", "year_of_production" },
                values: new object[] { 3, "Peugeot", (short)4, "206", 1, (short)205 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: 3);

            migrationBuilder.InsertData(
                schema: "public",
                table: "Vehicles",
                columns: new[] { "vehicle_id", "brand", "max_seats", "model", "vehicle_type_id", "year_of_production" },
                values: new object[,]
                {
                    { 1, "BMW", (short)5, "X4", 1, (short)2020 },
                    { 2, "Audi", (short)5, "A6", 1, (short)2019 }
                });
        }
    }
}
