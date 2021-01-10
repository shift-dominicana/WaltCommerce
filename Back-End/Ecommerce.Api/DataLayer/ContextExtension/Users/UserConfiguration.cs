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

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.IdCard).IsRequired();
            builder.Property(x => x.IdCardType).IsRequired();
            builder.Property(x => x.Dob).IsRequired();
            builder.Property(x => x.CellPhone).IsRequired();
        }
    }
}
