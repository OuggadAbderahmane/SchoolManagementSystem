using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class YearOfLevelConfiguration : IEntityTypeConfiguration<YearOfLevel>
    {
        public void Configure(EntityTypeBuilder<YearOfLevel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20)
            .IsRequired();

            builder.ToTable("YearOfLevels");

            builder.HasData(_DataYearOfLevels());
        }

        private List<YearOfLevel> _DataYearOfLevels()
        {
            return
            [
                new() { Id = 1 ,Name = "السنة الاولى" },
                new() { Id = 2 ,Name = "السنة الثانية" },
                new() { Id = 3 ,Name = "السنة الثالثة" },
                new() { Id = 4 ,Name = "السنة الرابعة" },
                new() { Id = 5 ,Name = "السنة الخامسة" }
            ];
        }

    }
}