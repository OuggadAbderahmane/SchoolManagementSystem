using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Class)
                .WithMany(x => x.Subjects)
                .HasForeignKey(x => x.ClassId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasMany(c => c.Teachers)
                .WithMany(x => x.Subjects)
                .UsingEntity<SubjectTeacher>(
                    j => j.HasOne(e => e.Teacher).WithMany().HasForeignKey(e => e.TeacherId).OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne(e => e.Subject).WithMany().HasForeignKey(e => e.SubjectId).OnDelete(DeleteBehavior.Restrict)
                );


            builder.ToTable("Subjects");
        }

    }
}
