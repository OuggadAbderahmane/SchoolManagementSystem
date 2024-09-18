using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPartOfSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionSubjects");

            migrationBuilder.DropTable(
                name: "TeacherSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeachers",
                table: "SubjectTeachers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubjectTeachers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeachers",
                table: "SubjectTeachers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PartsOfSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false),
                    Session = table.Column<short>(type: "smallint", nullable: false),
                    SubjectTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartsOfSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartsOfSchedules_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartsOfSchedules_SubjectTeachers_SubjectTeacherId",
                        column: x => x.SubjectTeacherId,
                        principalTable: "SubjectTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeachers_SubjectId_TeacherId",
                table: "SubjectTeachers",
                columns: new[] { "SubjectId", "TeacherId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartsOfSchedules_SectionId",
                table: "PartsOfSchedules",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartsOfSchedules_SubjectTeacherId",
                table: "PartsOfSchedules",
                column: "SubjectTeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartsOfSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeachers",
                table: "SubjectTeachers");

            migrationBuilder.DropIndex(
                name: "IX_SubjectTeachers_SubjectId_TeacherId",
                table: "SubjectTeachers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubjectTeachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeachers",
                table: "SubjectTeachers",
                columns: new[] { "SubjectId", "TeacherId" });

            migrationBuilder.CreateTable(
                name: "SectionSubjects",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionSubjects", x => new { x.SectionId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SectionSubjects_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SectionSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSections",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSections", x => new { x.TeacherId, x.SectionId });
                    table.ForeignKey(
                        name: "FK_TeacherSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherSections_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionSubjects_SubjectId",
                table: "SectionSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSections_SectionId",
                table: "TeacherSections",
                column: "SectionId");
        }
    }
}
