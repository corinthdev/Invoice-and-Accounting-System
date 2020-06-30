using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Added_InvoiceDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGet",
                table: "AppInvoiceDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdGet",
                table: "AppInvoiceDetails");
        }
    }
}
