using Common.Models.Brands;
using Common.Models.BuyCartDetails;
using Common.Models.BuyCarts;
using Common.Models.PersonTypeCategories;
using Common.Models.ProductCategories;
using Common.Models.ProductsColors;
using Common.Models.ProductsImages;
using Common.Models.ProductsSpecifications;
using Common.Models.Roles;
using Common.Models.Sizes;
using Common.Models.Users;
using DataLayer.ContextExtension.Brands;
using DataLayer.ContextExtension.BuyCartDetails;
using DataLayer.ContextExtension.BuyCarts;
using DataLayer.ContextExtension.PersonTypeCategories;
using DataLayer.ContextExtension.ProductCategories;
using DataLayer.ContextExtension.ProductColors;
using DataLayer.ContextExtension.Products;
using DataLayer.ContextExtension.ProductsImages;
using DataLayer.ContextExtension.ProductsSizes;
using DataLayer.ContextExtension.ProductsSpecifications;
using DataLayer.ContextExtension.Roles;
using DataLayer.ContextExtension.Users;
using Common.Models.Products;
using Microsoft.EntityFrameworkCore;
using Common.Models.UsersAddresses;
using DataLayer.ContextExtension.UserAddresses;
using Common.Models.Orders;
using Common.Models.OrderDetails;

namespace DataLayer.Contexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PersonTypeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSpecificationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductColorConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new BuyCartConfiguration());
            modelBuilder.ApplyConfiguration(new BuyCartDetailConfiguration());
            modelBuilder.ApplyConfiguration(new UserAddressesConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductCategory> ProductsCategories { get; set; }
        public DbSet<PersonTypeCategory> PersonsTypeCategories { get; set; }
        public DbSet<ProductImage> ProductsImages { get; set; }
        public DbSet<ProductSpecification> Specifications { get; set; }
        public DbSet<ProductColor> ProductsColors { get; set; }
        public DbSet<ProductSize> ProductsSizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BuyCart> BuyCarts { get; set; }
        public DbSet<BuyCartDetail> BuyCartDetails { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }


    }
}
