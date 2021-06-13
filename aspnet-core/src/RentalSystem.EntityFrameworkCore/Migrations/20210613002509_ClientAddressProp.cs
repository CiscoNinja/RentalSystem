using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalSystem.Migrations
{
    public partial class ClientAddressProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clients",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line1",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line2",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clients_Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address_Line1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address_Line2",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OtherName",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Clients",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
