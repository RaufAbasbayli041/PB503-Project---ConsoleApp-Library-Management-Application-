using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB503Project_1.Migrations
{
    /// <inheritdoc />
    public partial class _1234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Borrowers",
                newName: "LoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "Borrowers",
                newName: "BookId");
        }
    }
}
