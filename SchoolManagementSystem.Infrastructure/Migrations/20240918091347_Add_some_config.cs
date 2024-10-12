using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_some_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FinalExams_StudentId",
                table: "FinalExams");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Years",
                newName: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_FinalExams_StudentId_SubjectId_SemesterId_YearId",
                table: "FinalExams",
                columns: new[] { "StudentId", "SubjectId", "SemesterId", "YearId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FinalExams_StudentId_SubjectId_SemesterId_YearId",
                table: "FinalExams");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Years",
                newName: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_FinalExams_StudentId",
                table: "FinalExams",
                column: "StudentId");
        }
    }
}
