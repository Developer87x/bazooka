using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazooka.Customers.Api.Infrastructure.Data
{
    /// <inheritdoc />
    public partial class AddJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "job_informaiton",
                schema: "CTM",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Occuption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employeer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allownace = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_informaiton", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_job_informaiton_customers_CustomerId",
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
                name: "job_informaiton",
                schema: "CTM");
        }
    }
}
