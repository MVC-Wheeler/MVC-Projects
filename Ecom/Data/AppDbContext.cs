using Ecom.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(o => o.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<Order>().HasMany(o=>o.OrderItems).WithOne(i=>i.Order).HasForeignKey(i=>i.OrderID);
            modelBuilder.Entity<Product>().HasMany(o=>o.OrderItems).WithOne(i=>i.Product).HasForeignKey(i=>i.ProductID);


        }
    }
}
