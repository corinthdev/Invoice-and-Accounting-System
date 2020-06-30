using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Edit_TransactionTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "AppInvoiceHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DebitMemoDate",
                table: "AppDebitMemoHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreditMemoDate",
                table: "AppCreditMemoHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "AppInvoiceHeaders");

            migrationBuilder.DropColumn(
                name: "DebitMemoDate",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "CreditMemoDate",
                table: "AppCreditMemoHeaders");
        }
    }
}
