using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystem.Migrations
{
    public partial class BookedDatesList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isbooked",
                table: "Facilities");

            migrationBuilder.AddColumn<int>(
                name: "QuantityBooked",
                table: "MiscellaneousBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BookedDates",
                table: "FacilityBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookedDates",
                table: "Facilities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityBooked",
                table: "MiscellaneousBookings");

            migrationBuilder.DropColumn(
                name: "BookedDates",
                table: "FacilityBookings");

            migrationBuilder.DropColumn(
                name: "BookedDates",
                table: "Facilities");

            migrationBuilder.AddColumn<bool>(
                name: "Isbooked",
                table: "Facilities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
