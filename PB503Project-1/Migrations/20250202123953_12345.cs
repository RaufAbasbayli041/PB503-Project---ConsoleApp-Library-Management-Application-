using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB503Project_1.Migrations
{
    /// <inheritdoc />
    public partial class _12345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "BookId",
                table: "LoanItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LoanItems_BookId",
                table: "LoanItems",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanItems_Books_BookId",
                table: "LoanItems",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanItems_Books_BookId",
                table: "LoanItems");

            migrationBuilder.DropIndex(
                name: "IX_LoanItems_BookId",
                table: "LoanItems");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "LoanItems");

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
    }
}
