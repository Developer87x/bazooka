using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazooka.Customers.Api.Infrastructure.Data
{
    /// <inheritdoc />
    public partial class RenameTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_customers_CustomerId",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "PersonalInformaiton",
                schema: "CTM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                schema: "CTM",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "CTM",
                newName: "addresses",
                newSchema: "CTM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                schema: "CTM",
                table: "addresses",
                column: "CustomerId");

            migrationBuilder.CreateTable(
                name: "personal_informaiton",
                schema: "CTM",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personal_informaiton", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_personal_informaiton_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "CTM",
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_addresses_customers_CustomerId",
                schema: "CTM",
                table: "addresses",
                column: "CustomerId",
                principalSchema: "CTM",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_addresses_customers_CustomerId",
                schema: "CTM",
                table: "addresses");

            migrationBuilder.DropTable(
                name: "personal_informaiton",
                schema: "CTM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                schema: "CTM",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "addresses",
                schema: "CTM",
                newName: "Addresses",
                newSchema: "CTM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                schema: "CTM",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateTable(
                name: "PersonalInformaiton",
                schema: "CTM",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformaiton", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_PersonalInformaiton_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "CTM",
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_customers_CustomerId",
                schema: "CTM",
                table: "Addresses",
                column: "CustomerId",
                principalSchema: "CTM",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
