using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.HasOne(x => x.guardian)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.GuardianId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(x => x.Section)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.SectionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


            builder.ToTable("Students");
        }

    }
}
