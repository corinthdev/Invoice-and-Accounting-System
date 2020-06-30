using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class ForgottenVan_inCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VansId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_VansId",
                table: "Customers",
                column: "VansId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Vans_VansId",
                table: "Customers",
                column: "VansId",
                principalTable: "Vans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Vans_VansId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_VansId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "VansId",
                table: "Customers");
        }
    }
}
