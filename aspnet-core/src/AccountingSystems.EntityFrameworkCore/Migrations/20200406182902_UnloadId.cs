using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class UnloadId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WithdrawalId",
                table: "AppUnloadHeaders",
                newName: "UnloadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnloadId",
                table: "AppUnloadHeaders",
                newName: "WithdrawalId");
        }
    }
}
