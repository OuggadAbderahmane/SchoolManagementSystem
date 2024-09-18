using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class YearConfiguration : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Value)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnType("BIT")
                .HasDefaultValue(true)
                .IsRequired();


            builder.ToTable("Years");
        }
    }
}
