using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class StudentEvaluationConfiguration : IEntityTypeConfiguration<StudentEvaluation>
    {
        public void Configure(EntityTypeBuilder<StudentEvaluation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Year)
                .WithMany()
                .HasForeignKey(x => x.YearId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Subject)
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudentEvaluations)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Semester)
                .WithMany()
                .HasForeignKey(x => x.SemesterId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasIndex(x => new { x.StudentId, x.SubjectId, x.SemesterId, x.YearId })
                .IsUnique();


            builder.ToTable("StudentsEvaluations");
        }

    }
}
