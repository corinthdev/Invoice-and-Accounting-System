using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class SiteCode_CreditDebit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteCode",
                table: "AppDebitMemoHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteCode",
                table: "AppCreditMemoHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteCode",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "SiteCode",
                table: "AppCreditMemoHeaders");
        }
    }
}
