using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class addforeingkeyinvoicetablesandupdateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HounsingId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceTypeId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                table: "Invoices",
                column: "InvoiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_userId",
                table: "Invoices",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_InvoiceTypes_InvoiceTypeId",
                table: "Invoices",
                column: "InvoiceTypeId",
                principalTable: "InvoiceTypes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_InvoiceTypes_InvoiceTypeId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_userId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_InvoiceTypeId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_userId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceTypeId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "HounsingId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
