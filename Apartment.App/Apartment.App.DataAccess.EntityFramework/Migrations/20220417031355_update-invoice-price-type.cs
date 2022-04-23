using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class updateinvoicepricetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invoices",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                newName: "IX_Invoices_userId");

            migrationBuilder.AlterColumn<double>(
                name: "InvoicePrice",
                table: "Invoices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_userId",
                table: "Invoices",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_userId",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Invoices",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_userId",
                table: "Invoices",
                newName: "IX_Invoices_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "InvoicePrice",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
