using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class RetainEnv_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AppSuppliers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AppSalesmans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AppProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "AppCustomers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppRetailEnvironment",
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
                    Code = table.Column<string>(nullable: true),
                    RetailEnvironmentCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustomerType = table.Column<string>(nullable: true),
                    Reserved = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRetailEnvironment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRetailEnvironment");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppSuppliers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppSalesmans");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppProducts");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppCustomers");
        }
    }
}
