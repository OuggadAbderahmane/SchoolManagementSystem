using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAndsomeconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "People",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "People",
                type: "NVARCHAR(40)",
                maxLength: 40,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "People");
        }
    }
}
