using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class addforeingkeyhousingtouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Housings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Housings_userId",
                table: "Housings",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Housings_Users_userId",
                table: "Housings",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Housings_Users_userId",
                table: "Housings");

            migrationBuilder.DropIndex(
                name: "IX_Housings_userId",
                table: "Housings");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Housings");
        }
    }
}
