using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingIsFreeFieldInDriverEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_free",
                table: "drivers",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Field that tells whether the driver is free and therefore has the opportunity to accpet the order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_free",
                table: "drivers");
        }
    }
}
