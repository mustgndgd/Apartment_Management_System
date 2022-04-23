using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment.App.DataAccess.EntityFramework.Migrations
{
    public partial class Addedtablesinvoiceinvoicetypehousing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HounsingId",
                schema: "Identity",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Housings",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    IsEmpty = table.Column<bool>(nullable: false),
                    IsHomeowner = table.Column<bool>(nullable: false),
                    BlokNumber = table.Column<int>(nullable: false),
                    FloorNumber = table.Column<int>(nullable: false),
                    ApartmentNumber = table.Column<int>(nullable: false),
                    ApartmentSizeInfo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Housings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastSpendDate = table.Column<DateTime>(nullable: false),
                    IsSpended = table.Column<bool>(nullable: false),
                    TotalDay = table.Column<int>(nullable: false),
                    InvoiceAmountOfUse = table.Column<int>(nullable: false),
                    InvoicePrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    LastUpdatedAt = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: false),
                    InvoiceTypeUnit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Housings",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InvoiceTypes",
                schema: "Identity");

            migrationBuilder.DropColumn(
                name: "HounsingId",
                schema: "Identity",
                table: "Users");
        }
    }
}
