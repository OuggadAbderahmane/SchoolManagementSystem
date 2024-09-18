using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCardNumber = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<bool>(type: "BIT", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    ImagePath = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearOfLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearOfLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    IsAvtive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guardians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guardians_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Guardians_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PermanentWork = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfSpecialization = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    YearOfLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Classes_YearOfLevels_YearOfLevelId",
                        column: x => x.YearOfLevelId,
                        principalTable: "YearOfLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: true),
                    GuardianId = table.Column<int>(type: "int", nullable: true),
                    IsAvtive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Guardians_GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "Guardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
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

            migrationBuilder.CreateTable(
                name: "SectionSubjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false)
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
                name: "SubjectTeachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeachers", x => new { x.SubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectTeachers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinalExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    FinalExamNote = table.Column<decimal>(type: "decimal(2,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalExams_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalExams_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalExams_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalExams_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "الابتدائي" },
                    { 2, "المتوسط" },
                    { 3, "الثانوي" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "الفصل الاول" },
                    { 2, "الفصل الثاني" },
                    { 3, "الفصل الثالث" }
                });

            migrationBuilder.InsertData(
                table: "YearOfLevels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "السنة الاولى" },
                    { 2, "السنة الثانية" },
                    { 3, "السنة الثالثة" },
                    { 4, "السنة الرابعة" },
                    { 5, "السنة الخامسة" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "LevelId", "NameOfSpecialization", "YearOfLevelId" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 2, 1, null, 2 },
                    { 3, 1, null, 3 },
                    { 4, 1, null, 4 },
                    { 5, 1, null, 5 },
                    { 6, 2, null, 1 },
                    { 7, 2, null, 2 },
                    { 8, 2, null, 3 },
                    { 9, 2, null, 4 },
                    { 10, 3, "جدع مشترك علوم وتكنولوجيا", 1 },
                    { 11, 3, "جدع مشترك آداب", 1 },
                    { 12, 3, "علوم تجريبية", 2 },
                    { 13, 3, "رياضيات", 2 },
                    { 14, 3, "تقني رياضي هندسة مدنية", 2 },
                    { 15, 3, "تقني رياضي هندسة الطرائق", 2 },
                    { 16, 3, "تقني رياضي هندسة كهربائية", 2 },
                    { 17, 3, "تقني رياضي هندسة ميكانيكية", 2 },
                    { 18, 3, "تسيير واقتصاد", 2 },
                    { 19, 3, "لغات أجنبية", 2 },
                    { 20, 3, "آداب وفلسفة", 2 },
                    { 21, 3, "علوم تجريبية", 3 },
                    { 22, 3, "رياضيات", 3 },
                    { 23, 3, "تقني رياضي هندسة مدنية", 3 },
                    { 24, 3, "تقني رياضي هندسة الطرائق", 3 },
                    { 25, 3, "تقني رياضي هندسة كهربائية", 3 },
                    { 26, 3, "تقني رياضي هندسة ميكانيكية", 3 },
                    { 27, 3, "تسيير واقتصاد", 3 },
                    { 28, 3, "لغات أجنبية", 3 },
                    { 29, 3, "آداب وفلسفة", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_LevelId",
                table: "Classes",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_YearOfLevelId",
                table: "Classes",
                column: "YearOfLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalExams_SemesterId",
                table: "FinalExams",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalExams_StudentId",
                table: "FinalExams",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalExams_SubjectId",
                table: "FinalExams",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalExams_YearId",
                table: "FinalExams",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Guardians_JobID",
                table: "Guardians",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ClassId",
                table: "Sections",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionSubjects_SubjectId",
                table: "SectionSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GuardianId",
                table: "Students",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SectionId",
                table: "Students",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ClassId",
                table: "Subjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeachers_TeacherId",
                table: "SubjectTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSections_SectionId",
                table: "TeacherSections",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalExams");

            migrationBuilder.DropTable(
                name: "SectionSubjects");

            migrationBuilder.DropTable(
                name: "SubjectTeachers");

            migrationBuilder.DropTable(
                name: "TeacherSections");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Years");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Guardians");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "YearOfLevels");
        }
    }
}
