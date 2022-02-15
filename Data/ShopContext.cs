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
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Spu> Spu { get; set; } = null!;
        public DbSet<Sku> Sku { get; set; } = null!;
        public DbSet<Stock> Stock { get; set; } = null!;
        public DbSet<SpuDetail> SpuDetail { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Spu>().ToTable("Spu");
            modelBuilder.Entity<Sku>().ToTable("Sku");
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<SpuDetail>().ToTable("SpuDetail");

            modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.FkCategoryId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Sku>()
                .HasOne(p => p.Spu)
                .WithMany(s => s.Skus)
                .IsRequired()
                .HasForeignKey(x => x.fkSpuId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Sku>()
                .HasOne(s => s.Stock)
                .WithOne(o => o.Sku)
                .HasForeignKey<Stock>(o => o.fkSkuId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Spu>()
                .HasOne(s => s.SpuDetail)
                .WithOne(d => d.Spu)
                .HasForeignKey<SpuDetail>(d => d.fkSpuId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
