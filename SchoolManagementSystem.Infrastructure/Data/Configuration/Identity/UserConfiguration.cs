﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementSystem.Data.Entities.Identity;

namespace SchoolManagementSystem.Infrastructure.Data.Configuration.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName)
            .IsRequired();

            builder.Property(x => x.PasswordHash)
            .IsRequired();

            builder.HasIndex(x => x.UserName).IsUnique();

            builder.HasIndex(x => x.PersonId).IsUnique();


            builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<IdentityUserRole<int>>();

            builder.HasOne(x => x.Person)
                .WithOne()
                .HasForeignKey<User>(x => x.PersonId);
        }
    }
}
