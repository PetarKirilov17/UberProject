using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingCancelledOrdersInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drivers_orders",
                columns: table => new
                {
                    driver_id = table.Column<int>(type: "integer", nullable: false, comment: "Used to describe the 'many-to-many' relationship between the Driver and the Order. Used both as primary key and foregin to make the relationship with the driver."),
                    order_id = table.Column<int>(type: "integer", nullable: false, comment: "Used to describe the 'many-to-many' relationship between the Driver and the Order. Used both as primary key and foregin to make the relationship with the order.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivers_orders", x => new { x.driver_id, x.order_id });
                    table.ForeignKey(
                        name: "fk_drivers_orders_drivers_driver_id",
                        column: x => x.driver_id,
                        principalTable: "drivers",
                        principalColumn: "driver_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_drivers_orders_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "odrer_id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This is a class that describes the mapping Entity between the Driver and the Order");

            migrationBuilder.CreateIndex(
                name: "ix_drivers_orders_order_id",
                table: "drivers_orders",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drivers_orders");
        }
    }
}
