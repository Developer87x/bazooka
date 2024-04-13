using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazooka.Customers.Api.Infrastructure.Data
{
    /// <inheritdoc />
    public partial class UpdateCustomerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_MyProperty",
                schema: "CTM",
                table: "customers");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "CTM",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Addresses_customers_CustomerId",
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
                name: "Addresses",
                schema: "CTM");

            migrationBuilder.AddColumn<int>(
                name: "Address_MyProperty",
                schema: "CTM",
                table: "customers",
                type: "int",
                nullable: true);
        }
    }
}
