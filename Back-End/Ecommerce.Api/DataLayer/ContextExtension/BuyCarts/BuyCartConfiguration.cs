using Common.Enums;
using Common.Models.BuyCarts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension.BuyCarts
{
    public class BuyCartConfiguration : IEntityTypeConfiguration<BuyCart>
    {
        public void Configure(EntityTypeBuilder<BuyCart> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn().UseSerialColumn();
            builder.Property(x => x.isPickup).HasDefaultValue(false);
            builder.Property(x => x.payMode).HasDefaultValue(PayModeEnum.CASH);
            builder.Property(x => x.taxReceipt).HasDefaultValue(false);
            builder.HasOne(x => x.User).WithOne().HasForeignKey<BuyCart>(x => x.UserId);
            builder.HasMany(x => x.BuyCartDetails);
        }
    }
}
