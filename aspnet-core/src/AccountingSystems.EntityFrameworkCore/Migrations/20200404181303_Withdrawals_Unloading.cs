using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Withdrawals_Unloading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUnloadHeaders",
                columns: table => new
                {
                    WithdrawalId = table.Column<int>(nullable: false)
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
                    WithdrawalCode = table.Column<string>(nullable: true),
                    VanId = table.Column<int>(nullable: false),
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
                    UnloadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUnloadHeaders", x => x.WithdrawalId);
                    table.ForeignKey(
                        name: "FK_AppUnloadHeaders_AppSalesmans_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "AppSalesmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUnloadHeaders_AppVans_VanId",
                        column: x => x.VanId,
                        principalTable: "AppVans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppWithdrawalHeaders",
                columns: table => new
                {
                    WithdrawalId = table.Column<int>(nullable: false)
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
                    WithdrawalCode = table.Column<string>(nullable: true),
                    VanId = table.Column<int>(nullable: false),
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
                    WithdrawalDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWithdrawalHeaders", x => x.WithdrawalId);
                    table.ForeignKey(
                        name: "FK_AppWithdrawalHeaders_AppSalesmans_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "AppSalesmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppWithdrawalHeaders_AppVans_VanId",
                        column: x => x.VanId,
                        principalTable: "AppVans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUnloadDetails",
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
                    WithdrawalHeaderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Box = table.Column<int>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    TotalPieces = table.Column<int>(nullable: false),
                    TotalProductPrice = table.Column<double>(nullable: false),
                    Gross = table.Column<double>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    Net = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUnloadDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUnloadDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUnloadDetails_AppUnloadHeaders_WithdrawalHeaderId",
                        column: x => x.WithdrawalHeaderId,
                        principalTable: "AppUnloadHeaders",
                        principalColumn: "WithdrawalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppWithdrawalDetails",
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
                    WithdrawalHeaderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Box = table.Column<int>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    TotalPieces = table.Column<int>(nullable: false),
                    TotalProductPrice = table.Column<double>(nullable: false),
                    Gross = table.Column<double>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    Net = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWithdrawalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppWithdrawalDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppWithdrawalDetails_AppWithdrawalHeaders_WithdrawalHeaderId",
                        column: x => x.WithdrawalHeaderId,
                        principalTable: "AppWithdrawalHeaders",
                        principalColumn: "WithdrawalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUnloadDetails_ProductId",
                table: "AppUnloadDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnloadDetails_WithdrawalHeaderId",
                table: "AppUnloadDetails",
                column: "WithdrawalHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnloadHeaders_SalesmanId",
                table: "AppUnloadHeaders",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUnloadHeaders_VanId",
                table: "AppUnloadHeaders",
                column: "VanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppWithdrawalDetails_ProductId",
                table: "AppWithdrawalDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppWithdrawalDetails_WithdrawalHeaderId",
                table: "AppWithdrawalDetails",
                column: "WithdrawalHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppWithdrawalHeaders_SalesmanId",
                table: "AppWithdrawalHeaders",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppWithdrawalHeaders_VanId",
                table: "AppWithdrawalHeaders",
                column: "VanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUnloadDetails");

            migrationBuilder.DropTable(
                name: "AppWithdrawalDetails");

            migrationBuilder.DropTable(
                name: "AppUnloadHeaders");

            migrationBuilder.DropTable(
                name: "AppWithdrawalHeaders");
        }
    }
}
