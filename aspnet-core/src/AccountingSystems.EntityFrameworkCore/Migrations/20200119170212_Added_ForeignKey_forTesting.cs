using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Added_ForeignKey_forTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesmanCode",
                table: "Vans");

            migrationBuilder.DropColumn(
                name: "SalesmanName",
                table: "Vans");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LocationCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "SalesmanId",
                table: "Vans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vans_SalesmanId",
                table: "Vans",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vans_Salesmen_SalesmanId",
                table: "Vans",
                column: "SalesmanId",
                principalTable: "Salesmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Vans_Salesmen_SalesmanId",
                table: "Vans");

            migrationBuilder.DropIndex(
                name: "IX_Vans_SalesmanId",
                table: "Vans");

            migrationBuilder.DropIndex(
                name: "IX_Products_SupplierId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LocationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SalesmanId",
                table: "Vans");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "SalesmanCode",
                table: "Vans",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesmanName",
                table: "Vans",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                table: "Products",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "Products",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationCode",
                table: "Customers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Customers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
