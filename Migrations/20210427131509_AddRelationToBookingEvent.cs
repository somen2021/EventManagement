using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagement.Migrations
{
    public partial class AddRelationToBookingEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEvent_tblBookingEvent_BookingEventBookingId",
                table: "tblEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFood_tblBookingEvent_BookingEventBookingId",
                table: "tblFood");

            migrationBuilder.DropForeignKey(
                name: "FK_tblVenue_tblBookingEvent_BookingEventBookingId",
                table: "tblVenue");

            migrationBuilder.DropIndex(
                name: "IX_tblVenue_BookingEventBookingId",
                table: "tblVenue");

            migrationBuilder.DropIndex(
                name: "IX_tblFood_BookingEventBookingId",
                table: "tblFood");

            migrationBuilder.DropIndex(
                name: "IX_tblEvent_BookingEventBookingId",
                table: "tblEvent");

            migrationBuilder.DropColumn(
                name: "BookingEventBookingId",
                table: "tblVenue");

            migrationBuilder.DropColumn(
                name: "BookingEventBookingId",
                table: "tblFood");

            migrationBuilder.DropColumn(
                name: "BookingEventBookingId",
                table: "tblEvent");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "tblBookingEvent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "tblBookingEvent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VenueID",
                table: "tblBookingEvent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblBookingEvent_EventID",
                table: "tblBookingEvent",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_tblBookingEvent_FoodID",
                table: "tblBookingEvent",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_tblBookingEvent_VenueID",
                table: "tblBookingEvent",
                column: "VenueID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBookingEvent_tblEvent_EventID",
                table: "tblBookingEvent",
                column: "EventID",
                principalTable: "tblEvent",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblBookingEvent_tblFood_FoodID",
                table: "tblBookingEvent",
                column: "FoodID",
                principalTable: "tblFood",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblBookingEvent_tblVenue_VenueID",
                table: "tblBookingEvent",
                column: "VenueID",
                principalTable: "tblVenue",
                principalColumn: "VenueID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBookingEvent_tblEvent_EventID",
                table: "tblBookingEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBookingEvent_tblFood_FoodID",
                table: "tblBookingEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBookingEvent_tblVenue_VenueID",
                table: "tblBookingEvent");

            migrationBuilder.DropIndex(
                name: "IX_tblBookingEvent_EventID",
                table: "tblBookingEvent");

            migrationBuilder.DropIndex(
                name: "IX_tblBookingEvent_FoodID",
                table: "tblBookingEvent");

            migrationBuilder.DropIndex(
                name: "IX_tblBookingEvent_VenueID",
                table: "tblBookingEvent");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "tblBookingEvent");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "tblBookingEvent");

            migrationBuilder.DropColumn(
                name: "VenueID",
                table: "tblBookingEvent");

            migrationBuilder.AddColumn<int>(
                name: "BookingEventBookingId",
                table: "tblVenue",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingEventBookingId",
                table: "tblFood",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingEventBookingId",
                table: "tblEvent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblVenue_BookingEventBookingId",
                table: "tblVenue",
                column: "BookingEventBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFood_BookingEventBookingId",
                table: "tblFood",
                column: "BookingEventBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_BookingEventBookingId",
                table: "tblEvent",
                column: "BookingEventBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEvent_tblBookingEvent_BookingEventBookingId",
                table: "tblEvent",
                column: "BookingEventBookingId",
                principalTable: "tblBookingEvent",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFood_tblBookingEvent_BookingEventBookingId",
                table: "tblFood",
                column: "BookingEventBookingId",
                principalTable: "tblBookingEvent",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblVenue_tblBookingEvent_BookingEventBookingId",
                table: "tblVenue",
                column: "BookingEventBookingId",
                principalTable: "tblBookingEvent",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
