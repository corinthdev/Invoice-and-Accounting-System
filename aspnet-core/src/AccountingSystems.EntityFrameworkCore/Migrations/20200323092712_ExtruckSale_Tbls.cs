using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class ExtruckSale_Tbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_AppProducts_ProductId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "AppStocks");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_ProductId",
                table: "AppStocks",
                newName: "IX_AppStocks_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppStocks",
                table: "AppStocks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppExtruckSaleHeaders",
                columns: table => new
                {
                    ExtruckSaleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ExtruckSaleCode = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false),
                    TotalCase = table.Column<int>(nullable: false),
                    TotalBox = table.Column<int>(nullable: false),
                    TotalPiece = table.Column<int>(nullable: false),
                    TotalQuantity = table.Column<int>(nullable: false),
                    TotalGross = table.Column<double>(nullable: false),
                    TotalDiscount = table.Column<string>(nullable: true),
                    TotalNet = table.Column<double>(nullable: false),
                    Vatable = table.Column<double>(nullable: false),
                    TwelvePercentVat = table.Column<double>(nullable: false),
                    ExtruckSaleDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppExtruckSaleHeaders", x => x.ExtruckSaleId);
                    table.ForeignKey(
                        name: "FK_AppExtruckSaleHeaders_AppCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppExtruckSaleHeaders_AppSalesmans_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "AppSalesmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppExtruckSaleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ExtruckSaleHeaderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Box = table.Column<int>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    TotalProductPrice = table.Column<double>(nullable: false),
                    Gross = table.Column<double>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    Net = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppExtruckSaleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppExtruckSaleDetails_AppExtruckSaleHeaders_ExtruckSaleHeade~",
                        column: x => x.ExtruckSaleHeaderId,
                        principalTable: "AppExtruckSaleHeaders",
                        principalColumn: "ExtruckSaleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppExtruckSaleDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppExtruckSaleDetails_ExtruckSaleHeaderId",
                table: "AppExtruckSaleDetails",
                column: "ExtruckSaleHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExtruckSaleDetails_ProductId",
                table: "AppExtruckSaleDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExtruckSaleHeaders_CustomerId",
                table: "AppExtruckSaleHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppExtruckSaleHeaders_SalesmanId",
                table: "AppExtruckSaleHeaders",
                column: "SalesmanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppStocks_AppProducts_ProductId",
                table: "AppStocks",
                column: "ProductId",
                principalTable: "AppProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStocks_AppProducts_ProductId",
                table: "AppStocks");

            migrationBuilder.DropTable(
                name: "AppExtruckSaleDetails");

            migrationBuilder.DropTable(
                name: "AppExtruckSaleHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppStocks",
                table: "AppStocks");

            migrationBuilder.RenameTable(
                name: "AppStocks",
                newName: "Stocks");

            migrationBuilder.RenameIndex(
                name: "IX_AppStocks_ProductId",
                table: "Stocks",
                newName: "IX_Stocks_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_AppProducts_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "AppProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
