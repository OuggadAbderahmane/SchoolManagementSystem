using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Gender)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasColumnType("DATETIME");

            builder.Property(x => x.Email)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Address)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.ImagePath)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);


            builder.ToTable("People");
        }
    }
}
