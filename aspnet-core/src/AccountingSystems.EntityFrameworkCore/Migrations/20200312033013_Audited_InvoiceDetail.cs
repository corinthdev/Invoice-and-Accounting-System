using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Audited_InvoiceDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "AppInvoiceDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "AppInvoiceDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "AppInvoiceDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "AppInvoiceDetails");
        }
    }
}
