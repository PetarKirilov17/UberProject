using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingIsApprvedFieldToDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_driver_approved",
                table: "drivers",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Field that tells whether the driver is approved by the admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_driver_approved",
                table: "drivers");
        }
    }
}
