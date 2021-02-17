using Common.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ContextExtension.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.MainImageUrl).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Identificator).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(x => x.ProductCategory);//.WithMany(x => x.Products).HasForeignKey(x => x.ProductCategoryFKey);
            builder.Property(x => x.isNewProduct).IsRequired();
            builder.Property(x => x.SharedId).HasMaxLength(8);
        }
    }
}
