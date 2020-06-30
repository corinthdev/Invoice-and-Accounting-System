using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class SIPOCMDM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Vans_VansId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Vans_Salesmen_SalesmanId",
                table: "Vans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vans",
                table: "Vans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salesmen",
                table: "Salesmen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Vans",
                newName: "AppVans");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "AppSuppliers");

            migrationBuilder.RenameTable(
                name: "Salesmen",
                newName: "AppSalesmans");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "AppProducts");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "AppLocations");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "AppCustomers");

            migrationBuilder.RenameIndex(
                name: "IX_Vans_SalesmanId",
                table: "AppVans",
                newName: "IX_AppVans_SalesmanId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierId",
                table: "AppProducts",
                newName: "IX_AppProducts_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_VansId",
                table: "AppCustomers",
                newName: "IX_AppCustomers_VansId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_LocationId",
                table: "AppCustomers",
                newName: "IX_AppCustomers_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppVans",
                table: "AppVans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSuppliers",
                table: "AppSuppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSalesmans",
                table: "AppSalesmans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProducts",
                table: "AppProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLocations",
                table: "AppLocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AppCreditMemoHeaders",
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
                    Code = table.Column<string>(nullable: true),
                    IsGood = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false),
                    TotalCase = table.Column<int>(nullable: false),
                    TotalPiece = table.Column<int>(nullable: false),
                    TotalCasePrice = table.Column<decimal>(nullable: false),
                    TotalPiecePrice = table.Column<decimal>(nullable: false),
                    TotalGross = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<string>(nullable: true),
                    TotalNet = table.Column<decimal>(nullable: false),
                    Vatable = table.Column<decimal>(nullable: false),
                    TwelvePercentVat = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCreditMemoHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCreditMemoHeaders_AppCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCreditMemoHeaders_AppSalesmans_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "AppSalesmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppDebitMemoHeaders",
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
                    Code = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    TotalCase = table.Column<int>(nullable: false),
                    TotalPiece = table.Column<int>(nullable: false),
                    TotalCasePrice = table.Column<decimal>(nullable: false),
                    TotalPiecePrice = table.Column<decimal>(nullable: false),
                    TotalGross = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<string>(nullable: true),
                    TotalNet = table.Column<decimal>(nullable: false),
                    Vatable = table.Column<decimal>(nullable: false),
                    TwelvePercentVat = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDebitMemoHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDebitMemoHeaders_AppSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "AppSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppInvoiceHeaders",
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
                    Code = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false),
                    TotalCase = table.Column<int>(nullable: false),
                    TotalPiece = table.Column<int>(nullable: false),
                    TotalCasePrice = table.Column<decimal>(nullable: false),
                    TotalPiecePrice = table.Column<decimal>(nullable: false),
                    TotalGross = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<string>(nullable: true),
                    TotalNet = table.Column<decimal>(nullable: false),
                    Vatable = table.Column<decimal>(nullable: false),
                    TwelvePercentVat = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoiceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInvoiceHeaders_AppCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AppCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppInvoiceHeaders_AppSalesmans_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "AppSalesmans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPurchaseOrderHeaders",
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
                    Code = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    TotalCase = table.Column<int>(nullable: false),
                    TotalPiece = table.Column<int>(nullable: false),
                    TotalCasePrice = table.Column<decimal>(nullable: false),
                    TotalPiecePrice = table.Column<decimal>(nullable: false),
                    TotalGross = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<string>(nullable: true),
                    TotalNet = table.Column<decimal>(nullable: false),
                    Vatable = table.Column<decimal>(nullable: false),
                    TwelvePercentVat = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPurchaseOrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPurchaseOrderHeaders_AppSuppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "AppSuppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppCreditMemoDetails",
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
                    CreditMemoHeaderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    CasePrice = table.Column<decimal>(nullable: false),
                    PiecePrice = table.Column<decimal>(nullable: false),
                    Gross = table.Column<decimal>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    Net = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCreditMemoDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCreditMemoDetails_AppCreditMemoHeaders_CreditMemoHeaderId",
                        column: x => x.CreditMemoHeaderId,
                        principalTable: "AppCreditMemoHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppCreditMemoDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppDebitMemoDetails",
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
                    DebitMemoHeaderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    CasePrice = table.Column<decimal>(nullable: false),
                    PiecePrice = table.Column<decimal>(nullable: false),
                    Gross = table.Column<decimal>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    Net = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDebitMemoDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppDebitMemoDetails_AppDebitMemoHeaders_DebitMemoHeaderId",
                        column: x => x.DebitMemoHeaderId,
                        principalTable: "AppDebitMemoHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppDebitMemoDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppInvoiceDetails",
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
                    InvoiceHeaderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    CasePrice = table.Column<decimal>(nullable: false),
                    PiecePrice = table.Column<decimal>(nullable: false),
                    Gross = table.Column<decimal>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    Net = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppInvoiceDetails_AppInvoiceHeaders_InvoiceHeaderId",
                        column: x => x.InvoiceHeaderId,
                        principalTable: "AppInvoiceHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppInvoiceDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppPurchaseOrderDetails",
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
                    PurchaseOrderHeaderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Case = table.Column<int>(nullable: false),
                    Piece = table.Column<int>(nullable: false),
                    CasePrice = table.Column<decimal>(nullable: false),
                    PiecePrice = table.Column<decimal>(nullable: false),
                    Gross = table.Column<decimal>(nullable: false),
                    Discount = table.Column<string>(nullable: true),
                    Net = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPurchaseOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPurchaseOrderDetails_AppProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AppProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppPurchaseOrderDetails_AppPurchaseOrderHeaders_PurchaseOrde~",
                        column: x => x.PurchaseOrderHeaderId,
                        principalTable: "AppPurchaseOrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCreditMemoDetails_CreditMemoHeaderId",
                table: "AppCreditMemoDetails",
                column: "CreditMemoHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCreditMemoDetails_ProductId",
                table: "AppCreditMemoDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCreditMemoHeaders_CustomerId",
                table: "AppCreditMemoHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCreditMemoHeaders_SalesmanId",
                table: "AppCreditMemoHeaders",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDebitMemoDetails_DebitMemoHeaderId",
                table: "AppDebitMemoDetails",
                column: "DebitMemoHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDebitMemoDetails_ProductId",
                table: "AppDebitMemoDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppDebitMemoHeaders_SupplierId",
                table: "AppDebitMemoHeaders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceDetails_InvoiceHeaderId",
                table: "AppInvoiceDetails",
                column: "InvoiceHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceDetails_ProductId",
                table: "AppInvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceHeaders_CustomerId",
                table: "AppInvoiceHeaders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AppInvoiceHeaders_SalesmanId",
                table: "AppInvoiceHeaders",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPurchaseOrderDetails_ProductId",
                table: "AppPurchaseOrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPurchaseOrderDetails_PurchaseOrderHeaderId",
                table: "AppPurchaseOrderDetails",
                column: "PurchaseOrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPurchaseOrderHeaders_SupplierId",
                table: "AppPurchaseOrderHeaders",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomers_AppLocations_LocationId",
                table: "AppCustomers",
                column: "LocationId",
                principalTable: "AppLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomers_AppVans_VansId",
                table: "AppCustomers",
                column: "VansId",
                principalTable: "AppVans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppSuppliers_SupplierId",
                table: "AppProducts",
                column: "SupplierId",
                principalTable: "AppSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppVans_AppSalesmans_SalesmanId",
                table: "AppVans",
                column: "SalesmanId",
                principalTable: "AppSalesmans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomers_AppLocations_LocationId",
                table: "AppCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomers_AppVans_VansId",
                table: "AppCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppSuppliers_SupplierId",
                table: "AppProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_AppVans_AppSalesmans_SalesmanId",
                table: "AppVans");

            migrationBuilder.DropTable(
                name: "AppCreditMemoDetails");

            migrationBuilder.DropTable(
                name: "AppDebitMemoDetails");

            migrationBuilder.DropTable(
                name: "AppInvoiceDetails");

            migrationBuilder.DropTable(
                name: "AppPurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "AppCreditMemoHeaders");

            migrationBuilder.DropTable(
                name: "AppDebitMemoHeaders");

            migrationBuilder.DropTable(
                name: "AppInvoiceHeaders");

            migrationBuilder.DropTable(
                name: "AppPurchaseOrderHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppVans",
                table: "AppVans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSuppliers",
                table: "AppSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSalesmans",
                table: "AppSalesmans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProducts",
                table: "AppProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLocations",
                table: "AppLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers");

            migrationBuilder.RenameTable(
                name: "AppVans",
                newName: "Vans");

            migrationBuilder.RenameTable(
                name: "AppSuppliers",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "AppSalesmans",
                newName: "Salesmen");

            migrationBuilder.RenameTable(
                name: "AppProducts",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "AppLocations",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "AppCustomers",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_AppVans_SalesmanId",
                table: "Vans",
                newName: "IX_Vans_SalesmanId");

            migrationBuilder.RenameIndex(
                name: "IX_AppProducts_SupplierId",
                table: "Products",
                newName: "IX_Products_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_AppCustomers_VansId",
                table: "Customers",
                newName: "IX_Customers_VansId");

            migrationBuilder.RenameIndex(
                name: "IX_AppCustomers_LocationId",
                table: "Customers",
                newName: "IX_Customers_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vans",
                table: "Vans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salesmen",
                table: "Salesmen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Vans_VansId",
                table: "Customers",
                column: "VansId",
                principalTable: "Vans",
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
    }
}
