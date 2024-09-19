using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(_DataRoles());
        }
        private List<Role> _DataRoles()
        {
            return [
                new() { Id = 1, Name = "admin", NormalizedName = "ADMIN" },
                new() { Id = 2, Name = "user", NormalizedName = "USER" }
                ];
        }

    }
}
