using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Added_TotalPieces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPieces",
                table: "AppPurchaseOrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPieces",
                table: "AppInvoiceDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPieces",
                table: "AppExtruckSaleDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPieces",
                table: "AppDebitMemoDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPieces",
                table: "AppCreditMemoDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPieces",
                table: "AppBookingDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPieces",
                table: "AppPurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalPieces",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "TotalPieces",
                table: "AppExtruckSaleDetails");

            migrationBuilder.DropColumn(
                name: "TotalPieces",
                table: "AppDebitMemoDetails");

            migrationBuilder.DropColumn(
                name: "TotalPieces",
                table: "AppCreditMemoDetails");

            migrationBuilder.DropColumn(
                name: "TotalPieces",
                table: "AppBookingDetails");
        }
    }
}
