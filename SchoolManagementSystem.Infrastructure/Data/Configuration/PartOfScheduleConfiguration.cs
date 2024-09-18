using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class PartOfScheduleConfiguration : IEntityTypeConfiguration<PartOfSchedule>
    {
        public void Configure(EntityTypeBuilder<PartOfSchedule> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(x => x.SubjectTeacher)
                .WithMany(x => x.PartOfSchedules)
                .HasForeignKey(x => x.SubjectTeacherId);

            builder.HasOne(x => x.Section)
                .WithMany()
                .HasForeignKey(x => x.SectionId);

            builder.HasIndex(e => new { e.SectionId, e.Day, e.Session })
                .IsUnique();

            builder.ToTable("PartsOfSchedules");
        }
    }
    public class GetPartsOfScheduleResponseConfiguration : IEntityTypeConfiguration<GetPartsOfScheduleView>
    {
        public void Configure(EntityTypeBuilder<GetPartsOfScheduleView> builder)
        {
            builder.HasNoKey();
        }
    }
}
