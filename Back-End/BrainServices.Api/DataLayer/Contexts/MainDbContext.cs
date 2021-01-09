using DataLayer.ContextExtension.Roles;
using DataLayer.ContextExtension.Users;
using DataLayer.Models.Roles;
using DataLayer.Models.Users;
using Microsoft.EntityFrameworkCore;

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
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
