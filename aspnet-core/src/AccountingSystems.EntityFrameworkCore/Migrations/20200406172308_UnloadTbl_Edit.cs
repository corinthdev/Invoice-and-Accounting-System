using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class UnloadTbl_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUnloadDetails_AppUnloadHeaders_WithdrawalHeaderId",
                table: "AppUnloadDetails");

            migrationBuilder.DropIndex(
                name: "IX_AppUnloadDetails_WithdrawalHeaderId",
                table: "AppUnloadDetails");

            migrationBuilder.DropColumn(
                name: "WithdrawalCode",
                table: "AppUnloadHeaders");

            migrationBuilder.DropColumn(
                name: "WithdrawalHeaderId",
                table: "AppUnloadDetails");

            migrationBuilder.AddColumn<string>(
                name: "UnloadCode",
                table: "AppUnloadHeaders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnloadHeaderId",
                table: "AppUnloadDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUnloadDetails_UnloadHeaderId",
                table: "AppUnloadDetails",
                column: "UnloadHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUnloadDetails_AppUnloadHeaders_UnloadHeaderId",
                table: "AppUnloadDetails",
                column: "UnloadHeaderId",
                principalTable: "AppUnloadHeaders",
                principalColumn: "WithdrawalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUnloadDetails_AppUnloadHeaders_UnloadHeaderId",
                table: "AppUnloadDetails");

            migrationBuilder.DropIndex(
                name: "IX_AppUnloadDetails_UnloadHeaderId",
                table: "AppUnloadDetails");

            migrationBuilder.DropColumn(
                name: "UnloadCode",
                table: "AppUnloadHeaders");

            migrationBuilder.DropColumn(
                name: "UnloadHeaderId",
                table: "AppUnloadDetails");

            migrationBuilder.AddColumn<string>(
                name: "WithdrawalCode",
                table: "AppUnloadHeaders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WithdrawalHeaderId",
                table: "AppUnloadDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUnloadDetails_WithdrawalHeaderId",
                table: "AppUnloadDetails",
                column: "WithdrawalHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUnloadDetails_AppUnloadHeaders_WithdrawalHeaderId",
                table: "AppUnloadDetails",
                column: "WithdrawalHeaderId",
                principalTable: "AppUnloadHeaders",
                principalColumn: "WithdrawalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
