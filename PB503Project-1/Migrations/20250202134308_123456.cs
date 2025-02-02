using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB503Project_1.Migrations
{
    /// <inheritdoc />
    public partial class _123456 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Borrowers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "Borrowers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
