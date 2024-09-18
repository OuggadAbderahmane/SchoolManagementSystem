using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();


            builder.ToTable("Semesters");

            builder.HasData(_DataSemesters());
        }

        private List<Semester> _DataSemesters()
        {
            return
            [
                new() { Id = 1 ,Name = "الفصل الاول" },
                new() { Id = 2 ,Name = "الفصل الثاني" },
                new() { Id = 3 ,Name = "الفصل الثالث" }
            ];
        }

    }
}
