using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {
        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasIndex(s => new { s.SubjectId, s.TeacherId }).IsUnique();


            builder.ToTable("SubjectTeachers");
        }
    }
}
