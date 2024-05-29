using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order_status_id",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign Key that describes a 'one-to-many' relationship between the Order and the OrderStatus. Contains information about the current status of the order.");

            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "integer", nullable: false, comment: "Identfier of the status.")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    label = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Label that contains the value of the status.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_status", x => x.status_id);
                },
                comment: "This is a class that describes the OrderStatus Entity in the application.");

            migrationBuilder.CreateIndex(
                name: "ix_orders_order_status_id",
                table: "orders",
                column: "order_status_id");

            migrationBuilder.AddForeignKey(
                name: "fk_orders_order_status_order_status_id",
                table: "orders",
                column: "order_status_id",
                principalTable: "order_status",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orders_order_status_order_status_id",
                table: "orders");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropIndex(
                name: "ix_orders_order_status_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_status_id",
                table: "orders");
        }
    }
}
