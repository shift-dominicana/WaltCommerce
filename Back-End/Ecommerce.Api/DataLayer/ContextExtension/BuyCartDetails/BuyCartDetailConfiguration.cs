using Common.Models.BuyCartDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension.BuyCartDetails
{
    public class BuyCartDetailConfiguration : IEntityTypeConfiguration<BuyCartDetail>
    {
        public void Configure(EntityTypeBuilder<BuyCartDetail> builder)
        {
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn().UseSerialColumn();
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.BuyCart).WithMany(x => x.BuyCartDetails).HasForeignKey(x => x.BuyCartId);
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
        }
    }
}
