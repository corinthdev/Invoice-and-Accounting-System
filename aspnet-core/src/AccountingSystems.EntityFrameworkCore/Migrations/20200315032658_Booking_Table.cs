using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Booking_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppBookingHeaders",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
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
                    InvoiceCode = table.Column<string>(nullable: true),
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
                    InvoiceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBookingHeaders", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_AppBookingHeaders_AppCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppBookingHeaders_AppSalesmans_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "AppSalesmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppBookingDetails",
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
                    BookingHeaderId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_AppBookingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBookingDetails_AppBookingHeaders_BookingHeaderId",
                        column: x => x.BookingHeaderId,
                        principalTable: "AppBookingHeaders",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppBookingDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBookingDetails_BookingHeaderId",
                table: "AppBookingDetails",
                column: "BookingHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBookingDetails_ProductId",
                table: "AppBookingDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBookingHeaders_CustomerId",
                table: "AppBookingHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppBookingHeaders_SalesmanId",
                table: "AppBookingHeaders",
                column: "SalesmanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppBookingDetails");

            migrationBuilder.DropTable(
                name: "AppBookingHeaders");
        }
    }
}
