using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Edited_TransactionTbls_Code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "AppCreditMemoHeaders");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseOrderCode",
                table: "AppPurchaseOrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DebitMemoCode",
                table: "AppDebitMemoHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditMemoCode",
                table: "AppCreditMemoHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseOrderCode",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "DebitMemoCode",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "CreditMemoCode",
                table: "AppCreditMemoHeaders");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AppPurchaseOrderHeaders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AppDebitMemoHeaders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AppCreditMemoHeaders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
