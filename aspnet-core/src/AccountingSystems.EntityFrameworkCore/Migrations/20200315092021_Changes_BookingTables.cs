using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingSystems.Migrations
{
    public partial class Changes_BookingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceCode",
                table: "AppBookingHeaders");

            migrationBuilder.DropColumn(
                name: "InvoiceDate",
                table: "AppBookingHeaders");

            migrationBuilder.AddColumn<string>(
                name: "BookingCode",
                table: "AppBookingHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "AppBookingHeaders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingCode",
                table: "AppBookingHeaders");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "AppBookingHeaders");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceCode",
                table: "AppBookingHeaders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InvoiceDate",
                table: "AppBookingHeaders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
