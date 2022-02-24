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
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Spu> Spu { get; set; } = null!;
        public DbSet<Sku> Sku { get; set; } = null!;
        public DbSet<Stock> Stock { get; set; } = null!;
        public DbSet<SpuDetail> SpuDetail { get; set; } = null!;
        public DbSet<SecCategory> SecCategories { get; set; } = null!;
        public DbSet<ThirdCategory> ThirdCategories { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Order>().ToTable("order");
            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<Spu>().ToTable("spu");
            modelBuilder.Entity<Sku>().ToTable("sku");
            modelBuilder.Entity<Stock>().ToTable("stock");
            modelBuilder.Entity<SpuDetail>().ToTable("spuDetail");
            modelBuilder.Entity<SecCategory>().ToTable("secCategory");
            modelBuilder.Entity<ThirdCategory>().ToTable("thirdCategory");

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

            modelBuilder.Entity<SecCategory>()
                .HasOne(s => s.Parent)
                .WithMany(c => c.children)
                .HasForeignKey(s => s.ParentId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ThirdCategory>()
                .HasOne(t => t.Parent)
                .WithMany(s => s.Children)
                .HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
