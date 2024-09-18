using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdduniqueoptioninSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_ClassId",
                table: "Sections");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ClassId_Name",
                table: "Sections",
                columns: new[] { "ClassId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sections_ClassId_Name",
                table: "Sections");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ClassId",
                table: "Sections",
                column: "ClassId");
        }
    }
}
