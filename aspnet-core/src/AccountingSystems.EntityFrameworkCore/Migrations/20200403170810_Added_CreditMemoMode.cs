using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Added_CreditMemoMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditMemoMode",
                table: "AppCreditMemoHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditMemoMode",
                table: "AppCreditMemoHeaders");
        }
    }
}
