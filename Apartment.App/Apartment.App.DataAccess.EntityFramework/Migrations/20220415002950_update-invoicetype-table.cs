using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class updateinvoicetypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTypeUnit",
                table: "InvoiceTypes");

            migrationBuilder.AddColumn<string>(
                name: "TypeUnit",
                table: "InvoiceTypes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeUnit",
                table: "InvoiceTypes");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceTypeUnit",
                table: "InvoiceTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
