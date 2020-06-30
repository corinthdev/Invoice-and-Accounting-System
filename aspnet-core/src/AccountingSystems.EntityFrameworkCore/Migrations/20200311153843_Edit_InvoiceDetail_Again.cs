using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Edit_InvoiceDetail_Again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppInvoiceDetails",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Please",
                table: "AppInvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetailId",
                table: "AppInvoiceDetails",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppInvoiceDetails",
                table: "AppInvoiceDetails",
                column: "InvoiceDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppInvoiceDetails",
                table: "AppInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceDetailId",
                table: "AppInvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AppInvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "AppInvoiceDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "AppInvoiceDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "AppInvoiceDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Please",
                table: "AppInvoiceDetails",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppInvoiceDetails",
                table: "AppInvoiceDetails",
                column: "Id");
        }
    }
}
