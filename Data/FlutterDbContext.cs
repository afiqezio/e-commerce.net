using FlutterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FlutterAPI.Data
{
    public class FlutterDbContext : DbContext
    {
        public FlutterDbContext(DbContextOptions<FlutterDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShopProduct> ShopProducts { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.UserID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Shop>().Property(s => s.ShopID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.ProductID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>().Property(o => o.OrderID).ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderDetail>().Property(od => od.OrderDetailID).ValueGeneratedOnAdd();
            modelBuilder.Entity<ShopProduct>().Property(sp => sp.ShopProductID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Cart>().Property(o => o.CartID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().Property(od => od.CategoryID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Wishlist>().Property(sp => sp.WishlistID).ValueGeneratedOnAdd();
        }
    }

}
