using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class CreatorUsername_toOtherTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorUsername",
                table: "AppWithdrawalHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUsername",
                table: "AppUnloadHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUsername",
                table: "AppPurchaseOrderHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUsername",
                table: "AppExtruckSaleHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUsername",
                table: "AppDebitMemoHeaders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUsername",
                table: "AppCreditMemoHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUsername",
                table: "AppWithdrawalHeaders");

            migrationBuilder.DropColumn(
                name: "CreatorUsername",
                table: "AppUnloadHeaders");

            migrationBuilder.DropColumn(
                name: "CreatorUsername",
                table: "AppPurchaseOrderHeaders");

            migrationBuilder.DropColumn(
                name: "CreatorUsername",
                table: "AppExtruckSaleHeaders");

            migrationBuilder.DropColumn(
                name: "CreatorUsername",
                table: "AppDebitMemoHeaders");

            migrationBuilder.DropColumn(
                name: "CreatorUsername",
                table: "AppCreditMemoHeaders");
        }
    }
}
