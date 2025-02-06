﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PB503Project_1.Migrations
{
    /// <inheritdoc />
    public partial class _123456789 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBorrow",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBorrow",
                table: "Books");
        }
    }
}
