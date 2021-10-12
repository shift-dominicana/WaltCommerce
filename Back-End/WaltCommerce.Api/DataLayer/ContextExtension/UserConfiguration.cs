using Common.Enums;
using Common.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn().UseSerialColumn();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(32); //HashMD5
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Dob).IsRequired();
            builder.Property(x => x.PersonalIdType).HasDefaultValue(PersonalIdTypeEnum.none);
            builder.Property(x => x.Gender).HasDefaultValue(GenderEnum.none);



        }

    }
}
