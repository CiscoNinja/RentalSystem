using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystem.Migrations
{
    public partial class SalePriceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Clients");

            migrationBuilder.AddColumn<double>(
                name: "SalePrice",
                table: "MiscellaneousBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SalePrice",
                table: "FacilityBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "MiscellaneousBookings");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "FacilityBookings");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
