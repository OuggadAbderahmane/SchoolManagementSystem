using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_FinalExam_to_FinalExam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinalExams_Semesters_SemesterId",
                table: "FinalExams");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalExams_Students_StudentId",
                table: "FinalExams");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalExams_Subjects_SubjectId",
                table: "FinalExams");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalExams_Years_YearId",
                table: "FinalExams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinalExams",
                table: "FinalExams");

            migrationBuilder.DropColumn(
                name: "FinalExamNote",
                table: "FinalExams");

            migrationBuilder.RenameTable(
                name: "FinalExams",
                newName: "StudentsEvaluations");

            migrationBuilder.RenameIndex(
                name: "IX_FinalExams_YearId",
                table: "StudentsEvaluations",
                newName: "IX_StudentsEvaluations_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_FinalExams_SubjectId",
                table: "StudentsEvaluations",
                newName: "IX_StudentsEvaluations_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_FinalExams_StudentId_SubjectId_SemesterId_YearId",
                table: "StudentsEvaluations",
                newName: "IX_StudentsEvaluations_StudentId_SubjectId_SemesterId_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_FinalExams_SemesterId",
                table: "StudentsEvaluations",
                newName: "IX_StudentsEvaluations_SemesterId");

            migrationBuilder.AddColumn<decimal>(
                name: "ContinuousAssessment",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Exam",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FirstTest",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SecondTest",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsEvaluations",
                table: "StudentsEvaluations",
                column: "Id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsEvaluations",
                table: "StudentsEvaluations");

            migrationBuilder.DropColumn(
                name: "ContinuousAssessment",
                table: "StudentsEvaluations");

            migrationBuilder.DropColumn(
                name: "Exam",
                table: "StudentsEvaluations");

            migrationBuilder.DropColumn(
                name: "FirstTest",
                table: "StudentsEvaluations");

            migrationBuilder.DropColumn(
                name: "SecondTest",
                table: "StudentsEvaluations");

            migrationBuilder.RenameTable(
                name: "StudentsEvaluations",
                newName: "FinalExams");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsEvaluations_YearId",
                table: "FinalExams",
                newName: "IX_FinalExams_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsEvaluations_SubjectId",
                table: "FinalExams",
                newName: "IX_FinalExams_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsEvaluations_StudentId_SubjectId_SemesterId_YearId",
                table: "FinalExams",
                newName: "IX_FinalExams_StudentId_SubjectId_SemesterId_YearId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentsEvaluations_SemesterId",
                table: "FinalExams",
                newName: "IX_FinalExams_SemesterId");

            migrationBuilder.AddColumn<decimal>(
                name: "FinalExamNote",
                table: "FinalExams",
                type: "decimal(2,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinalExams",
                table: "FinalExams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinalExams_Semesters_SemesterId",
                table: "FinalExams",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalExams_Students_StudentId",
                table: "FinalExams",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalExams_Subjects_SubjectId",
                table: "FinalExams",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalExams_Years_YearId",
                table: "FinalExams",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
