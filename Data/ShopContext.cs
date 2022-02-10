using Microsoft.EntityFrameworkCore;
using init_api.Entities;

namespace init_api.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Category> Categories {get;set;}=null!;
        public DbSet<Spu> Spu {get;set;}=null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Spu>().ToTable("Spu");

            modelBuilder.Entity<Category>().Property(x=>x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x=>x.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>()
                .HasOne(x=>x.Category)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.FkCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
