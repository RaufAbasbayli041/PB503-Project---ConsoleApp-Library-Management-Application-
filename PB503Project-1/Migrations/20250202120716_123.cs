using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB503Project_1.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_LoanItems_LoanItemId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LoanItemId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LoanItemId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Books_BookId",
                table: "Loans",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Books_BookId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_BookId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Loans");

            migrationBuilder.AddColumn<int>(
                name: "LoanItemId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LoanItemId",
                table: "Books",
                column: "LoanItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_LoanItems_LoanItemId",
                table: "Books",
                column: "LoanItemId",
                principalTable: "LoanItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
