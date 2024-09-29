using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();


            builder.ToTable("Levels");

            builder.HasData(_Datalevels());
        }

        private List<Level> _Datalevels()
        {
            return
            [
                new() { Id = 1 ,Name = "ابتدائي" },
                new() { Id = 2 ,Name = "متوسط" },
                new() { Id = 3 ,Name = "ثانوي" }
            ];
        }
    }
}