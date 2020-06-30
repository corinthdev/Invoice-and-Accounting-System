using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Edited_Transaction_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCasePrice",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "TotalPiecePrice",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "CasePrice",
                table: "AppPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "PiecePrice",
                table: "AppPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalCasePrice",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "TotalPiecePrice",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "CasePrice",
                table: "AppDebitMemoDetails");

            migrationBuilder.DropColumn(
                name: "PiecePrice",
                table: "AppDebitMemoDetails");

            migrationBuilder.DropColumn(
                name: "TotalCasePrice",
                table: "AppCreditMemoHeaders");

            migrationBuilder.DropColumn(
                name: "TotalPiecePrice",
                table: "AppCreditMemoHeaders");

            migrationBuilder.DropColumn(
                name: "CasePrice",
                table: "AppCreditMemoDetails");

            migrationBuilder.DropColumn(
                name: "PiecePrice",
                table: "AppCreditMemoDetails");

            migrationBuilder.AddColumn<int>(
                name: "TotalBox",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Box",
                table: "AppPurchaseOrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalProductPrice",
                table: "AppPurchaseOrderDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBox",
                table: "AppDebitMemoHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "AppDebitMemoHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Box",
                table: "AppDebitMemoDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalProductPrice",
                table: "AppDebitMemoDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBox",
                table: "AppCreditMemoHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "AppCreditMemoHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Box",
                table: "AppCreditMemoDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalProductPrice",
                table: "AppCreditMemoDetails",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBox",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "Box",
                table: "AppPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalProductPrice",
                table: "AppPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalBox",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "Box",
                table: "AppDebitMemoDetails");

            migrationBuilder.DropColumn(
                name: "TotalProductPrice",
                table: "AppDebitMemoDetails");

            migrationBuilder.DropColumn(
                name: "TotalBox",
                table: "AppCreditMemoHeaders");

            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "AppCreditMemoHeaders");

            migrationBuilder.DropColumn(
                name: "Box",
                table: "AppCreditMemoDetails");

            migrationBuilder.DropColumn(
                name: "TotalProductPrice",
                table: "AppCreditMemoDetails");

            migrationBuilder.AddColumn<double>(
                name: "TotalCasePrice",
                table: "AppPurchaseOrderHeaders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPiecePrice",
                table: "AppPurchaseOrderHeaders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CasePrice",
                table: "AppPurchaseOrderDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PiecePrice",
                table: "AppPurchaseOrderDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalCasePrice",
                table: "AppDebitMemoHeaders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPiecePrice",
                table: "AppDebitMemoHeaders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CasePrice",
                table: "AppDebitMemoDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PiecePrice",
                table: "AppDebitMemoDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalCasePrice",
                table: "AppCreditMemoHeaders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPiecePrice",
                table: "AppCreditMemoHeaders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CasePrice",
                table: "AppCreditMemoDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PiecePrice",
                table: "AppCreditMemoDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
