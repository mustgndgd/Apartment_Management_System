using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class updatetablevariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Housings_Users_userId",
                table: "Housings");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Housings_housingId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_userId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BlokNumber",
                table: "Housings");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Invoices",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "housingId",
                table: "Invoices",
                newName: "HousingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_userId",
                table: "Invoices",
                newName: "IX_Invoices_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_housingId",
                table: "Invoices",
                newName: "IX_Invoices_HousingId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Housings",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Housings_userId",
                table: "Housings",
                newName: "IX_Housings_UserId");

            migrationBuilder.AddColumn<int>(
                name: "BlockNumber",
                table: "Housings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Housings_Users_UserId",
                table: "Housings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Housings_HousingId",
                table: "Invoices",
                column: "HousingId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Housings_Users_UserId",
                table: "Housings");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Housings_HousingId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BlockNumber",
                table: "Housings");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invoices",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "HousingId",
                table: "Invoices",
                newName: "housingId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                newName: "IX_Invoices_userId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_HousingId",
                table: "Invoices",
                newName: "IX_Invoices_housingId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Housings",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Housings_UserId",
                table: "Housings",
                newName: "IX_Housings_userId");

            migrationBuilder.AddColumn<int>(
                name: "BlokNumber",
                table: "Housings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Housings_Users_userId",
                table: "Housings",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Housings_housingId",
                table: "Invoices",
                column: "housingId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_userId",
                table: "Invoices",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
