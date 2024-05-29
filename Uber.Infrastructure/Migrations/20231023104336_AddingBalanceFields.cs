using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingBalanceFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "profit",
                table: "drivers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                comment: "Field that contains the profit that the driver has made from their orders");

            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "clients",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                comment: "Field that contains the current balance of the client");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: 3,
                column: "year_of_production",
                value: (short)2005);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profit",
                table: "drivers");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "clients");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "Vehicles",
                keyColumn: "vehicle_id",
                keyValue: 3,
                column: "year_of_production",
                value: (short)205);
        }
    }
}
