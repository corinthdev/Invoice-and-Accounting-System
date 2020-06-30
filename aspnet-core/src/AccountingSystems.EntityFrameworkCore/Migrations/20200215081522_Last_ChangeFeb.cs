using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Last_ChangeFeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                table: "AppRetailEnvironment");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Warehouse",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "AppInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TotalCasePrice",
                table: "AppInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TotalPiecePrice",
                table: "AppInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "CasePrice",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "PiecePrice",
                table: "AppInvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "SubRECode",
                table: "AppRetailEnvironment",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceF",
                table: "AppProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceE",
                table: "AppProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceD",
                table: "AppProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceC",
                table: "AppProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceB",
                table: "AppProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PriceA",
                table: "AppProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Net",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PricePerBox",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceCode",
                table: "AppInvoiceHeaders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalBox",
                table: "AppInvoiceHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "AppInvoiceHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Box",
                table: "AppInvoiceDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalProductPrice",
                table: "AppInvoiceDetails",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubRECode",
                table: "AppRetailEnvironment");

            migrationBuilder.DropColumn(
                name: "Net",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "PricePerBox",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "InvoiceCode",
                table: "AppInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TotalBox",
                table: "AppInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "AppInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "Box",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "TotalProductPrice",
                table: "AppInvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "Reserved",
                table: "AppRetailEnvironment",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PriceF",
                table: "AppProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PriceE",
                table: "AppProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PriceD",
                table: "AppProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PriceC",
                table: "AppProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PriceB",
                table: "AppProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "PriceA",
                table: "AppProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<double>(
                name: "UnitCost",
                table: "AppProducts",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Warehouse",
                table: "AppProducts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AppInvoiceHeaders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCasePrice",
                table: "AppInvoiceHeaders",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPiecePrice",
                table: "AppInvoiceHeaders",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CasePrice",
                table: "AppInvoiceDetails",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PiecePrice",
                table: "AppInvoiceDetails",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
