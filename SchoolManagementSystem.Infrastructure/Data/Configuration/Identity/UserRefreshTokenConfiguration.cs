using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration.Identity
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.RefreshTokenString)
                .IsRequired();

            builder.Property(x => x.ExpireAt)
                .IsRequired();

            builder.HasOne(U => U.User)
                .WithOne(U => U.UserRefreshToken)
                .HasForeignKey<UserRefreshToken>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable("UserRefreshTokens");
        }
    }
}
