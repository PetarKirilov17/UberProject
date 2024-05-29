using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class SeedingOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "order_status",
                newName: "OrderStatus");

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "status_id", "label" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Ready" },
                    { 4, "Waiting" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "status_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "status_id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "OrderStatus",
                newName: "order_status");
        }
    }
}
