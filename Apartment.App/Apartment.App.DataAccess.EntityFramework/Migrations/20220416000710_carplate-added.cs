using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class carplateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarPlateNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasCar",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarPlateNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HasCar",
                table: "Users");
        }
    }
}
