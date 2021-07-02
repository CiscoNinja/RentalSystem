using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystem.Migrations
{
    public partial class IMayHaveTenant2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Miscellaneous",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Facilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Clients",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Miscellaneous");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Facilities");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Clients");
        }
    }
}
