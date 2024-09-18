using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class FinalExamConfiguration : IEntityTypeConfiguration<FinalExam>
    {
        public void Configure(EntityTypeBuilder<FinalExam> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Year)
                .WithMany()
                .HasForeignKey(x => x.YearId)
                .IsRequired();

            builder.HasOne(x => x.Subject)
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.FinalExams)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            builder.HasOne(x => x.Semester)
                .WithMany()
                .HasForeignKey(x => x.SemesterId)
                .IsRequired();

            builder.Property(x => x.FinalExamNote)
                .HasColumnType("decimal(2, 2)")
                .IsRequired();

            builder.HasIndex(x => new { x.StudentId, x.SubjectId, x.SemesterId, x.YearId })
                .IsUnique();


            builder.ToTable("FinalExams");
        }

    }
}
