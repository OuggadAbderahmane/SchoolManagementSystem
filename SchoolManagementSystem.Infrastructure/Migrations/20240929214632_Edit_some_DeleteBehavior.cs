using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edit_some_DeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Classes_ClassId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Semesters_SemesterId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Students_StudentId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Subjects_SubjectId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Years_YearId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Classes_ClassId",
                table: "Sections",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Semesters_SemesterId",
                table: "StudentsEvaluations",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Students_StudentId",
                table: "StudentsEvaluations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Subjects_SubjectId",
                table: "StudentsEvaluations",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Years_YearId",
                table: "StudentsEvaluations",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Classes_ClassId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Semesters_SemesterId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Students_StudentId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Subjects_SubjectId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsEvaluations_Years_YearId",
                table: "StudentsEvaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Classes_ClassId",
                table: "Sections",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Semesters_SemesterId",
                table: "StudentsEvaluations",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Students_StudentId",
                table: "StudentsEvaluations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Subjects_SubjectId",
                table: "StudentsEvaluations",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsEvaluations_Years_YearId",
                table: "StudentsEvaluations",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Classes_ClassId",
                table: "Subjects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
