using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Edit_Tables_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppPurchaseOrderHeaders",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppDebitMemoHeaders",
                newName: "DebitMemoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppCreditMemoHeaders",
                newName: "CreditMemoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "AppPurchaseOrderHeaders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DebitMemoId",
                table: "AppDebitMemoHeaders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreditMemoId",
                table: "AppCreditMemoHeaders",
                newName: "Id");
        }
    }
}
