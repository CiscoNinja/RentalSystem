using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystem.Migrations
{
    public partial class BookingModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Bookings",
                newName: "CheckedOutDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Bookings",
                newName: "CheckedInDate");

            migrationBuilder.RenameColumn(
                name: "AmountPaid",
                table: "Bookings",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<bool>(
                name: "CheckedIn",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CheckedOut",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedIn",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CheckedOut",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Bookings",
                newName: "AmountPaid");

            migrationBuilder.RenameColumn(
                name: "CheckedOutDate",
                table: "Bookings",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CheckedInDate",
                table: "Bookings",
                newName: "EndDate");
        }
    }
}
