using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class ReseedingFirstVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
