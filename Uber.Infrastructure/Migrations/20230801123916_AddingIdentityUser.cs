using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber.Infrastructure.Migrations
{
    public partial class AddingIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "people",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_people_user_id",
                table: "people",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_people_users_user_id",
                table: "people",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_people_users_user_id",
                table: "people");

            migrationBuilder.DropIndex(
                name: "ix_people_user_id",
                table: "people");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "people");
        }
    }
}
