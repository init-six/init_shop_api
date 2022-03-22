using Microsoft.EntityFrameworkCore;
using init_api.Entities;
using init_api.Entities.Category;
using init_api.Entities.Order;

namespace init_api.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Orders> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItem { get; set; } = null!;
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
            modelBuilder.Entity<Orders>().ToTable("orders");
            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<Spu>().ToTable("spu");
            modelBuilder.Entity<Sku>().ToTable("sku");
            modelBuilder.Entity<Stock>().ToTable("stock");
            modelBuilder.Entity<SpuDetail>().ToTable("spu_detail");
            modelBuilder.Entity<SecCategory>().ToTable("sec_category");
            modelBuilder.Entity<ThirdCategory>().ToTable("third_category");
            modelBuilder.Entity<OrderItem>().ToTable("order_item");

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

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.parent)
                .WithMany(o => o.items)
                .IsRequired()
                .HasForeignKey(x => x.fkOrderId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.sku)
                .WithMany(s => s.orderitems)
                .IsRequired()
                .HasForeignKey(i => i.fkSkuId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.spu)
                .WithMany(s => s.orderitems)
                .IsRequired()
                .HasForeignKey(i => i.fkSpuId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.user)
                .WithMany(u => u.orders)
                .IsRequired()
                .HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
