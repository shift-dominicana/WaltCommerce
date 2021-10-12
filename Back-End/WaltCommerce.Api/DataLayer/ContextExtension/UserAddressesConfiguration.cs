using Common.Models.UsersAddresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension
{
    class UserAddressesConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn().UseSerialColumn();
        }
    }
}
