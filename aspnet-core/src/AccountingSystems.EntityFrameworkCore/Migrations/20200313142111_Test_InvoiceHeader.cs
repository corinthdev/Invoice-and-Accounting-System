using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Test_InvoiceHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppInvoiceHeaders",
                newName: "InvoiceId");

            migrationBuilder.RenameColumn(
                name: "InvoiceDetailId",
                table: "AppInvoiceDetails",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "AppInvoiceHeaders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppInvoiceDetails",
                newName: "InvoiceDetailId");
        }
    }
}
