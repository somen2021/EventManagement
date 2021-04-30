using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagement.Migrations
{
    public partial class AddBookingEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "tblBookingEvent",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMailId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBookingEvent", x => x.BookingId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "tblBookingEvent");

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
        }
    }
}
