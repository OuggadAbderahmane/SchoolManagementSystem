using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
    {
        public void Configure(EntityTypeBuilder<Guardian> builder)
        {
            builder.HasOne(x => x.Job)
                .WithMany(x => x.guardians)
                .HasForeignKey(x => x.JobID)
                .IsRequired();


            builder.ToTable("Guardians");
        }
    }
}
