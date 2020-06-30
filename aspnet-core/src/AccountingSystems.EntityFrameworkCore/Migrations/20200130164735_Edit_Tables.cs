using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Edit_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomers_AppLocations_LocationId",
                table: "AppCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomers_AppVans_VansId",
                table: "AppCustomers");

            migrationBuilder.DropTable(
                name: "AppLocations");

            migrationBuilder.DropIndex(
                name: "IX_AppCustomers_LocationId",
                table: "AppCustomers");

            migrationBuilder.DropIndex(
                name: "IX_AppCustomers_VansId",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "VansId",
                table: "AppCustomers");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Freight",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GrossPrice",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PercentagePriceMargin",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceMargin",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Vat",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "AppCustomers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barangay",
                table: "AppCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "AppCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipality",
                table: "AppCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalCode1",
                table: "AppCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalCode2",
                table: "AppCustomers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "AppCustomers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesmansId",
                table: "AppCustomers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "AppCustomers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomers_SalesmansId",
                table: "AppCustomers",
                column: "SalesmansId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCustomers_AppSalesmans_SalesmansId",
                table: "AppCustomers",
                column: "SalesmansId",
                principalTable: "AppSalesmans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCustomers_AppSalesmans_SalesmansId",
                table: "AppCustomers");

            migrationBuilder.DropIndex(
                name: "IX_AppCustomers_SalesmansId",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Freight",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "GrossPrice",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "PercentagePriceMargin",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "PriceMargin",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Vat",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "Barangay",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "Municipality",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "PrincipalCode1",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "PrincipalCode2",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "SalesmansId",
                table: "AppCustomers");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "AppCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AppCustomers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AppCustomers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AppCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VansId",
                table: "AppCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomers_LocationId",
                table: "AppCustomers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomers_VansId",
                table: "AppCustomers",
                column: "VansId");

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
        }
    }
}
