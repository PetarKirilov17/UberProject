using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingVehicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "vehicles",
                newName: "vehicle_type_id");

            migrationBuilder.CreateTable(
                name: "vehicle_type",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    label = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    driver_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_type", x => x.type_id);
                    table.ForeignKey(
                        name: "fk_vehicle_type_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "driver_id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_vehicle_type_id",
                table: "vehicles",
                column: "vehicle_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_type_driver_id",
                table: "vehicle_type",
                column: "driver_id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehicle_type_vehicle_type_id",
                table: "vehicles",
                column: "vehicle_type_id",
                principalTable: "vehicle_type",
                principalColumn: "type_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehicle_type_vehicle_type_id",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "vehicle_type");

            migrationBuilder.DropIndex(
                name: "ix_vehicles_vehicle_type_id",
                table: "vehicles");

            migrationBuilder.RenameColumn(
                name: "vehicle_type_id",
                table: "vehicles",
                newName: "type");
        }
    }
}
