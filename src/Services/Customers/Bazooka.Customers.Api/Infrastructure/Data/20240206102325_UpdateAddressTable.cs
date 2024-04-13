using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazooka.Customers.Api.Infrastructure.Data
{
    /// <inheritdoc />
    public partial class UpdateAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "BuildingNo",
                schema: "CTM",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "CTM",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "CTM",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "CTM",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                schema: "CTM",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "CTM",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNo",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                schema: "CTM",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
