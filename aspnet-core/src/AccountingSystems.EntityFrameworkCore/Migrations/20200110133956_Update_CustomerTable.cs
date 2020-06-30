using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Update_CustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditLimit",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Disc1",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Disc2",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Disc3",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Disc4",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Disc1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Disc2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Disc3",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Disc4",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");
        }
    }
}
