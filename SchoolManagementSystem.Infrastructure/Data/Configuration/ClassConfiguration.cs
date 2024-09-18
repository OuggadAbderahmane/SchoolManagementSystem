using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameOfSpecialization)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .HasDefaultValue(null)
            .IsRequired(false);

            builder.HasOne(x => x.Level)
                .WithMany(x => x.Class)
                .HasForeignKey(x => x.LevelId)
                .IsRequired();

            builder.HasOne(x => x.YearOfLevel)
                .WithMany(x => x.Class)
                .HasForeignKey(x => x.YearOfLevelId)
                .IsRequired();


            builder.ToTable("Classes");

            builder.HasData(_DataClasss());
        }

        private List<Class> _DataClasss()
        {
            return
            [
                // Elementary Scool
                new() { Id = 1 ,YearOfLevelId = 1 ,LevelId = 1 },
                new() { Id = 2 ,YearOfLevelId = 2 ,LevelId = 1 },
                new() { Id = 3 ,YearOfLevelId = 3 ,LevelId = 1 },
                new() { Id = 4 ,YearOfLevelId = 4 ,LevelId = 1 },
                new() { Id = 5 ,YearOfLevelId = 5 ,LevelId = 1 },

                // Middle School
                new() { Id = 6 ,YearOfLevelId = 1 ,LevelId = 2 },
                new() { Id = 7 ,YearOfLevelId = 2 ,LevelId = 2 },
                new() { Id = 8 ,YearOfLevelId = 3 ,LevelId = 2 },
                new() { Id = 9 ,YearOfLevelId = 4 ,LevelId = 2 },

                // First year of High School
                new() { Id = 10 ,YearOfLevelId = 1 ,LevelId = 3 ,NameOfSpecialization = "جدع مشترك علوم وتكنولوجيا"},
                new() { Id = 11 ,YearOfLevelId = 1 ,LevelId = 3 ,NameOfSpecialization = "جدع مشترك آداب"},

                // Second year of High School
                new() { Id = 12 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "علوم تجريبية"},
                new() { Id = 13 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "رياضيات"},
                new() { Id = 14 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة مدنية"},
                new() { Id = 15 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة الطرائق"},
                new() { Id = 16 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة كهربائية"},
                new() { Id = 17 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة ميكانيكية"},
                new() { Id = 18 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "تسيير واقتصاد"},
                new() { Id = 19 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "لغات أجنبية"},
                new() { Id = 20 ,YearOfLevelId = 2 ,LevelId = 3 ,NameOfSpecialization = "آداب وفلسفة"},

                // Third year of High School
                new() { Id = 21 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "علوم تجريبية"},
                new() { Id = 22 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "رياضيات"},
                new() { Id = 23 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة مدنية"},
                new() { Id = 24 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة الطرائق"},
                new() { Id = 25 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة كهربائية"},
                new() { Id = 26 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "تقني رياضي هندسة ميكانيكية"},
                new() { Id = 27 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "تسيير واقتصاد"},
                new() { Id = 28 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "لغات أجنبية"},
                new() { Id = 29 ,YearOfLevelId = 3 ,LevelId = 3 ,NameOfSpecialization = "آداب وفلسفة"}
            ];
        }
    }
}
