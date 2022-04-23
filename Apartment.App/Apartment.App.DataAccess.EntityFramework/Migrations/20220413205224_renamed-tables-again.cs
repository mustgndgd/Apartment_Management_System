using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class renamedtablesagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrIdentityNumber",
                schema: "Identity",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrIdentityNumber",
                schema: "Identity",
                table: "Users");
        }
    }
}
