using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagement.Migrations
{
    public partial class ModifyBookingEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "VenueID",
                table: "tblBookingEvent",
                newName: "VenueId");

            migrationBuilder.RenameColumn(
                name: "FoodID",
                table: "tblBookingEvent",
                newName: "FoodId");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "tblBookingEvent",
                newName: "EventId");

            migrationBuilder.AlterColumn<int>(
                name: "VenueId",
                table: "tblBookingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FoodId",
                table: "tblBookingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "tblBookingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberofPeople",
                table: "tblBookingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCost",
                table: "tblBookingEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberofPeople",
                table: "tblBookingEvent");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "tblBookingEvent");

            migrationBuilder.RenameColumn(
                name: "VenueId",
                table: "tblBookingEvent",
                newName: "VenueID");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "tblBookingEvent",
                newName: "FoodID");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "tblBookingEvent",
                newName: "EventID");

            migrationBuilder.AlterColumn<int>(
                name: "VenueID",
                table: "tblBookingEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FoodID",
                table: "tblBookingEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "tblBookingEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
