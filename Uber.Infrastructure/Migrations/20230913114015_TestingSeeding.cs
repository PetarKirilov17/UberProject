using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class TestingSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehicle_type_vehicle_type_id",
                table: "vehicles");

            migrationBuilder.RenameTable(
                name: "vehicle_type",
                newName: "VehicleType");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "provider_key",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "type_id", "driver_id", "label" },
                values: new object[,]
                {
                    { 1, null, "Car" },
                    { 2, null, "Van" },
                    { 3, null, "SUV" },
                    { 4, null, "Cabriolet" }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehicle_types_vehicle_type_id",
                table: "vehicles",
                column: "vehicle_type_id",
                principalTable: "VehicleType",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehicle_types_vehicle_type_id",
                table: "vehicles");

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "type_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "type_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "type_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleType",
                keyColumn: "type_id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "VehicleType",
                newName: "vehicle_type");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "provider_key",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "login_provider",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehicle_type_vehicle_type_id",
                table: "vehicles",
                column: "vehicle_type_id",
                principalTable: "vehicle_type",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
