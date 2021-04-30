using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagement.Migrations
{
    public partial class AddBookingDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserMailId",
                table: "tblBookingEvent");

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "tblBookingEvent",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "tblBookingEvent");

            migrationBuilder.AddColumn<string>(
                name: "UserMailId",
                table: "tblBookingEvent",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
