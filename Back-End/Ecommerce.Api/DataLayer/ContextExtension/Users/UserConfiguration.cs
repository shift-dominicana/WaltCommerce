using DataLayer.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.ContextExtension.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.Email).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(32); //HashMD5
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.PersonalId).IsRequired();
            builder.Property(x => x.PersonalIdType).IsRequired();
            builder.Property(x => x.Dob).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
        }
    }
}
