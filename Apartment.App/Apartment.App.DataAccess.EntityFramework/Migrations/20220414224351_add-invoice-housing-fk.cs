using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class addinvoicehousingfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "housingId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_housingId",
                table: "Invoices",
                column: "housingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Housings_housingId",
                table: "Invoices",
                column: "housingId",
                principalTable: "Housings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Housings_housingId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_housingId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "housingId",
                table: "Invoices");
        }
    }
}
