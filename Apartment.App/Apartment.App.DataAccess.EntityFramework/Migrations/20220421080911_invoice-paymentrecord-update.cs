using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class invoicepaymentrecordupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoicePaymentId",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "InvoicePaymentRecordId",
                table: "Invoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoicePaymentRecordId",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "InvoicePaymentId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
