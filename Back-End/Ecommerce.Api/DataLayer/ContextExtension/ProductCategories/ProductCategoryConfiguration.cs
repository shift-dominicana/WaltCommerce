using Common.Models.ProductCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension.ProductCategories
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {

            builder.Property(x => x.Id).IsRequired().UseIdentityColumn().UseSerialColumn();
            builder.HasMany(x => x.Products);
        }
    }
}
