using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class addinvoiceunitrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "InvoiceAmountOfUse",
                table: "Invoices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "InvoiceUnitPrice",
                table: "Invoices",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceUnitPrice",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceAmountOfUse",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
