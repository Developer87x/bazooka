using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazooka.Customers.Api.Infrastructure.Data
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                schema: "CTM",
                table: "customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PersonalInformaiton",
                schema: "CTM",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalInformaiton",
                schema: "CTM");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                schema: "CTM",
                table: "customers");
        }
    }
}
