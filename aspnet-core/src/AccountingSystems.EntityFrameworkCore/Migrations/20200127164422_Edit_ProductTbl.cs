using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Edit_ProductTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PackSize",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "BarcodeCase",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarcodeItem",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarcodeCase",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BarcodeItem",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Products",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackSize",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
