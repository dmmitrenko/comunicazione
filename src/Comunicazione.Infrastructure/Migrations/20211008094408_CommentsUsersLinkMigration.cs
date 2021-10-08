using Microsoft.EntityFrameworkCore.Migrations;

namespace Comunicazione.Infrastructure.Migrations
{
    public partial class CommentsUsersLinkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Adresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UserId1",
                table: "Adresses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Users_UserId1",
                table: "Adresses",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Users_UserId1",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_UserId1",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Adresses");
        }
    }
}
