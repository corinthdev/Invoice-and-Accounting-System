using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class ChangeType_DecimaltoDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Vatable",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TwelvePercentVat",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPiecePrice",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalNet",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalGross",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCasePrice",
                table: "AppPurchaseOrderHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "PiecePrice",
                table: "AppPurchaseOrderDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Net",
                table: "AppPurchaseOrderDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Gross",
                table: "AppPurchaseOrderDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "CasePrice",
                table: "AppPurchaseOrderDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Vatable",
                table: "AppInvoiceHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TwelvePercentVat",
                table: "AppInvoiceHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalNet",
                table: "AppInvoiceHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalGross",
                table: "AppInvoiceHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalProductPrice",
                table: "AppInvoiceDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Net",
                table: "AppInvoiceDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Gross",
                table: "AppInvoiceDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Vatable",
                table: "AppDebitMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TwelvePercentVat",
                table: "AppDebitMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPiecePrice",
                table: "AppDebitMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalNet",
                table: "AppDebitMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalGross",
                table: "AppDebitMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCasePrice",
                table: "AppDebitMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "PiecePrice",
                table: "AppDebitMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Net",
                table: "AppDebitMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Gross",
                table: "AppDebitMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "CasePrice",
                table: "AppDebitMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Vatable",
                table: "AppCreditMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TwelvePercentVat",
                table: "AppCreditMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPiecePrice",
                table: "AppCreditMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalNet",
                table: "AppCreditMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalGross",
                table: "AppCreditMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalCasePrice",
                table: "AppCreditMemoHeaders",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "PiecePrice",
                table: "AppCreditMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Net",
                table: "AppCreditMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "Gross",
                table: "AppCreditMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<double>(
                name: "CasePrice",
                table: "AppCreditMemoDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Vatable",
                table: "AppPurchaseOrderHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TwelvePercentVat",
                table: "AppPurchaseOrderHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPiecePrice",
                table: "AppPurchaseOrderHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalNet",
                table: "AppPurchaseOrderHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGross",
                table: "AppPurchaseOrderHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCasePrice",
                table: "AppPurchaseOrderHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "PiecePrice",
                table: "AppPurchaseOrderDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Net",
                table: "AppPurchaseOrderDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Gross",
                table: "AppPurchaseOrderDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "CasePrice",
                table: "AppPurchaseOrderDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Vatable",
                table: "AppInvoiceHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TwelvePercentVat",
                table: "AppInvoiceHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalNet",
                table: "AppInvoiceHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGross",
                table: "AppInvoiceHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalProductPrice",
                table: "AppInvoiceDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Net",
                table: "AppInvoiceDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Gross",
                table: "AppInvoiceDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Vatable",
                table: "AppDebitMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TwelvePercentVat",
                table: "AppDebitMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPiecePrice",
                table: "AppDebitMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalNet",
                table: "AppDebitMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGross",
                table: "AppDebitMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCasePrice",
                table: "AppDebitMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "PiecePrice",
                table: "AppDebitMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Net",
                table: "AppDebitMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Gross",
                table: "AppDebitMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "CasePrice",
                table: "AppDebitMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Vatable",
                table: "AppCreditMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TwelvePercentVat",
                table: "AppCreditMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPiecePrice",
                table: "AppCreditMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalNet",
                table: "AppCreditMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGross",
                table: "AppCreditMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCasePrice",
                table: "AppCreditMemoHeaders",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "PiecePrice",
                table: "AppCreditMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Net",
                table: "AppCreditMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Gross",
                table: "AppCreditMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "CasePrice",
                table: "AppCreditMemoDetails",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
