﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementSystem.Infrastructure.Data;

#nullable disable

namespace SchoolManagementSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240904165756_Edit-PS-config")]
    partial class EditPSconfig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfSpecialization")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("YearOfLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.HasIndex("YearOfLevelId");

                    b.ToTable("Classes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LevelId = 1,
                            YearOfLevelId = 1
                        },
                        new
                        {
                            Id = 2,
                            LevelId = 1,
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 3,
                            LevelId = 1,
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 4,
                            LevelId = 1,
                            YearOfLevelId = 4
                        },
                        new
                        {
                            Id = 5,
                            LevelId = 1,
                            YearOfLevelId = 5
                        },
                        new
                        {
                            Id = 6,
                            LevelId = 2,
                            YearOfLevelId = 1
                        },
                        new
                        {
                            Id = 7,
                            LevelId = 2,
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 8,
                            LevelId = 2,
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 9,
                            LevelId = 2,
                            YearOfLevelId = 4
                        },
                        new
                        {
                            Id = 10,
                            LevelId = 3,
                            NameOfSpecialization = "جدع مشترك علوم وتكنولوجيا",
                            YearOfLevelId = 1
                        },
                        new
                        {
                            Id = 11,
                            LevelId = 3,
                            NameOfSpecialization = "جدع مشترك آداب",
                            YearOfLevelId = 1
                        },
                        new
                        {
                            Id = 12,
                            LevelId = 3,
                            NameOfSpecialization = "علوم تجريبية",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 13,
                            LevelId = 3,
                            NameOfSpecialization = "رياضيات",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 14,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة مدنية",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 15,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة الطرائق",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 16,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة كهربائية",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 17,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة ميكانيكية",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 18,
                            LevelId = 3,
                            NameOfSpecialization = "تسيير واقتصاد",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 19,
                            LevelId = 3,
                            NameOfSpecialization = "لغات أجنبية",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 20,
                            LevelId = 3,
                            NameOfSpecialization = "آداب وفلسفة",
                            YearOfLevelId = 2
                        },
                        new
                        {
                            Id = 21,
                            LevelId = 3,
                            NameOfSpecialization = "علوم تجريبية",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 22,
                            LevelId = 3,
                            NameOfSpecialization = "رياضيات",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 23,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة مدنية",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 24,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة الطرائق",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 25,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة كهربائية",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 26,
                            LevelId = 3,
                            NameOfSpecialization = "تقني رياضي هندسة ميكانيكية",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 27,
                            LevelId = 3,
                            NameOfSpecialization = "تسيير واقتصاد",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 28,
                            LevelId = 3,
                            NameOfSpecialization = "لغات أجنبية",
                            YearOfLevelId = 3
                        },
                        new
                        {
                            Id = 29,
                            LevelId = 3,
                            NameOfSpecialization = "آداب وفلسفة",
                            YearOfLevelId = 3
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.StudentEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("StudentEvaluationNote")
                        .HasColumnType("decimal(2, 2)");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("YearId");

                    b.ToTable("StudentEvaluations", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Jobs", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Levels", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ابتدائي"
                        },
                        new
                        {
                            Id = 2,
                            Name = "متوسط"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ثانوي"
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.PartOfSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("Day")
                        .HasColumnType("smallint");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<short>("Session")
                        .HasColumnType("smallint");

                    b.Property<int>("SubjectTeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectTeacherId");

                    b.HasIndex("Day", "Session", "SubjectTeacherId")
                        .IsUnique();

                    b.HasIndex("SectionId", "Day", "Session")
                        .IsUnique();

                    b.ToTable("PartsOfSchedules", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR");

                    b.Property<bool>("Gender")
                        .HasColumnType("BIT");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("NationalCardNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("People", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId", "Name")
                        .IsUnique();

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Semesters", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "الفصل الاول"
                        },
                        new
                        {
                            Id = 2,
                            Name = "الفصل الثاني"
                        },
                        new
                        {
                            Id = 3,
                            Name = "الفصل الثالث"
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.SubjectTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("SubjectId", "TeacherId")
                        .IsUnique();

                    b.ToTable("SubjectTeachers", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(true);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Years", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.YearOfLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("YearOfLevels", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "السنة الاولى"
                        },
                        new
                        {
                            Id = 2,
                            Name = "السنة الثانية"
                        },
                        new
                        {
                            Id = 3,
                            Name = "السنة الثالثة"
                        },
                        new
                        {
                            Id = 4,
                            Name = "السنة الرابعة"
                        },
                        new
                        {
                            Id = 5,
                            Name = "السنة الخامسة"
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Guardian", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Data.Entities.Person");

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.HasIndex("JobID");

                    b.ToTable("Guardians", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Student", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Data.Entities.Person");

                    b.Property<int?>("GuardianId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasIndex("GuardianId");

                    b.HasIndex("SectionId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Teacher", b =>
                {
                    b.HasBaseType("SchoolManagementSystem.Data.Entities.Person");

                    b.Property<bool>("PermanentWork")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(8,2)");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Class", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Level", "Level")
                        .WithMany("Class")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.YearOfLevel", "YearOfLevel")
                        .WithMany("Class")
                        .HasForeignKey("YearOfLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Level");

                    b.Navigation("YearOfLevel");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.StudentEvaluation", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Semester", "Semester")
                        .WithMany("StudentEvaluations")
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Student", "Student")
                        .WithMany("StudentEvaluations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Subject", "Subject")
                        .WithMany("StudentEvaluations")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Year", "Year")
                        .WithMany("StudentEvaluations")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.PartOfSchedule", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.SubjectTeacher", "SubjectTeacher")
                        .WithMany("PartOfSchedules")
                        .HasForeignKey("SubjectTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("SubjectTeacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Section", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Class", "Class")
                        .WithMany("Sections")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Subject", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Class", "Class")
                        .WithMany("Subjects")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.SubjectTeacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Guardian", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Data.Entities.Guardian", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Job", "Job")
                        .WithMany("guardians")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Guardian", "guardian")
                        .WithMany("Students")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SchoolManagementSystem.Data.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Data.Entities.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Data.Entities.Section", "Section")
                        .WithMany("Students")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Section");

                    b.Navigation("guardian");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Teacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Data.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("SchoolManagementSystem.Data.Entities.Teacher", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Class", b =>
                {
                    b.Navigation("Sections");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Job", b =>
                {
                    b.Navigation("guardians");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Level", b =>
                {
                    b.Navigation("Class");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Section", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Semester", b =>
                {
                    b.Navigation("StudentEvaluations");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Subject", b =>
                {
                    b.Navigation("StudentEvaluations");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.SubjectTeacher", b =>
                {
                    b.Navigation("PartOfSchedules");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Year", b =>
                {
                    b.Navigation("StudentEvaluations");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.YearOfLevel", b =>
                {
                    b.Navigation("Class");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Guardian", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolManagementSystem.Data.Entities.Student", b =>
                {
                    b.Navigation("StudentEvaluations");
                });
#pragma warning restore 612, 618
        }
    }
}
