using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystem.Migrations
{
    public partial class MiscellaneousEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Facilities_FacilityId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FacilityId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FacilityId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FaclityId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "OrganisationName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FacilityBookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityBookings", x => new { x.FacilityId, x.BookingId });
                    table.ForeignKey(
                        name: "FK_FacilityBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityBookings_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Miscellaneous",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscellaneous", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiscellaneousBookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    MiscellaneousId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscellaneousBookings", x => new { x.MiscellaneousId, x.BookingId });
                    table.ForeignKey(
                        name: "FK_MiscellaneousBookings_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiscellaneousBookings_Miscellaneous_MiscellaneousId",
                        column: x => x.MiscellaneousId,
                        principalTable: "Miscellaneous",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilityBookings_BookingId",
                table: "FacilityBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_MiscellaneousBookings_BookingId",
                table: "MiscellaneousBookings",
                column: "BookingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilityBookings");

            migrationBuilder.DropTable(
                name: "MiscellaneousBookings");

            migrationBuilder.DropTable(
                name: "Miscellaneous");

            migrationBuilder.DropColumn(
                name: "OrganisationName",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "FacilityId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FaclityId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FacilityId",
                table: "Bookings",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Facilities_FacilityId",
                table: "Bookings",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
