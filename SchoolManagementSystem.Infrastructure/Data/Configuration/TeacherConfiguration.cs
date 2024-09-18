using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {


            builder.Property(x => x.Salary)
                .HasColumnType("decimal(8,2)")
                .IsRequired();

            builder.Property(x => x.PermanentWork)
                .HasColumnType("BIT")
                .HasDefaultValue(false)
                .IsRequired();

            builder.ToTable("Teachers");
        }
    }
}
