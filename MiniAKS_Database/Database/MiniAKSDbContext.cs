using Microsoft.EntityFrameworkCore;
using MiniAKS_Database.Models;

namespace MiniAKS_Database.Database
{
    public class MiniAKSDbContext : DbContext
    {
        public MiniAKSDbContext(DbContextOptions<MiniAKSDbContext> options) : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Customization> Customizations { get; set; }
        public DbSet<SalesChannel> SalesChannels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<StationQueue> StationQueues { get; set; }


        // Add DbSet for OrderProductCustomization
        public DbSet<OrderProductCustomization> OrderProductCustomizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key for ProductItem (ProductId + ItemId)
            modelBuilder.Entity<ProductItem>()
                .HasKey(pi => new { pi.ProductId, pi.ItemId });

            modelBuilder.Entity<ProductItem>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductItems)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductItem>()
                .HasOne(pi => pi.Item)
                .WithMany(i => i.ProductItems)
                .HasForeignKey(pi => pi.ItemId);

            // Composite key for OrderProduct (OrderId + ProductId)
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            // Composite key for OrderProductCustomization (OrderId + ProductId + CustomizationId)
            modelBuilder.Entity<OrderProductCustomization>()
                .HasKey(opc => new { opc.OrderId, opc.ProductId, opc.CustomizationId });

            modelBuilder.Entity<OrderProductCustomization>()
                .HasOne(opc => opc.OrderProduct)
                .WithMany(op => op.OrderProductCustomizations)
                .HasForeignKey(opc => new { opc.OrderId, opc.ProductId });

            modelBuilder.Entity<OrderProductCustomization>()
                .HasOne(opc => opc.Customization)
                .WithMany()
                .HasForeignKey(opc => opc.CustomizationId);

            // Station and Items relationship
            modelBuilder.Entity<Station>()
                .HasMany(s => s.Items)
                .WithOne(i => i.Station)
                .HasForeignKey(i => i.StationId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<StationQueue>()
            .HasOne(scq => scq.Station)
            .WithMany(s => s.StationQueues)
            .HasForeignKey(scq => scq.StationId)
            .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<StationQueue>()
            .HasOne(scq => scq.Item)
            .WithMany(i => i.StationQueues)
            .HasForeignKey(scq => scq.ItemId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}


//using Microsoft.EntityFrameworkCore;
//using MiniAKS_Database.Models;

//namespace MiniAKS_Database.Database
//{
//    public class MiniAKSDbContext : DbContext
//    {
//        public MiniAKSDbContext(DbContextOptions<MiniAKSDbContext> options) : base(options)
//        {
//        }


//        public DbSet<Station> Stations { get; set; }
//        public DbSet<Item> Items { get; set; }
//        public DbSet<Product> Products { get; set; }
//        public DbSet<ProductItem> ProductItems { get; set; }
//        public DbSet<Customization> Customizations { get; set; }
//        public DbSet<SalesChannel> SalesChannels { get; set; }
//        public DbSet<Order> Orders { get; set; }
//        public DbSet<OrderProduct> OrderProducts { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<ProductItem>()
//                .HasKey(pi => new {pi.ProductId, pi.ItemId});

//            modelBuilder.Entity<ProductItem>()
//                .HasOne(pi => pi.Product)
//                .WithMany(p => p.ProductItems)
//                .HasForeignKey(pi => pi.ProductId);

//            modelBuilder.Entity<ProductItem>()
//                .HasOne(pi => pi.Item)
//                .WithMany(i=>i.ProductItems)
//                .HasForeignKey(pi => pi.ItemId);

//            modelBuilder.Entity<OrderProduct>()
//                .HasKey(op => new {op.OrderId, op.ProductId});

//            modelBuilder.Entity<OrderProduct>()
//                .HasOne(op => op.Order)
//                .WithMany(o => o.OrderProducts)
//                .HasForeignKey(op => op.OrderId);

//            modelBuilder.Entity<OrderProduct>()
//                .HasOne(op => op.Product)
//                .WithMany(p => p.OrderProducts)
//                .HasForeignKey(op => op.ProductId);


//            modelBuilder.Entity<Station>()
//                .HasMany(s=>s.Items)
//                .WithOne(i => i.Station)
//                .HasForeignKey(i=>i.StationId);
//        }

//    }
//}
