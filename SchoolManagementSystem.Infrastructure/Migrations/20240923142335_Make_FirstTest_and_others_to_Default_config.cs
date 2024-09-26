using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Make_FirstTest_and_others_to_Default_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SecondTest",
                table: "StudentsEvaluations",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FirstTest",
                table: "StudentsEvaluations",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Exam",
                table: "StudentsEvaluations",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ContinuousAssessment",
                table: "StudentsEvaluations",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SecondTest",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FirstTest",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Exam",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ContinuousAssessment",
                table: "StudentsEvaluations",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
