using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace session14C_
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>(e =>
            {
                e.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            // Product (Many-to-One with Category)
            modelBuilder.Entity<Product>(e =>
            {
                e.Property(p => p.Name).IsRequired().HasMaxLength(100);
                e.Property(p => p.Price).HasColumnType("decimal(18,2)");

                e.HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.CategoryId);
            });

            // Customer
            modelBuilder.Entity<Customer>(e =>
            {
                e.Property(c => c.Name).IsRequired().HasMaxLength(100);
                e.Property(c => c.Email).IsRequired().HasMaxLength(150);
            });

            // Order (Many-to-One with Customer)
            modelBuilder.Entity<Order>(e =>
            {
                e.HasOne(o => o.Customer)
                 .WithMany(c => c.Orders)
                 .HasForeignKey(o => o.CustomerId);
            });

            // OrderDetail (Many-to-Many between Order and Product)
            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.HasKey(od => new { od.OrderId, od.ProductId }); // Composite Primary Key

                e.HasOne(od => od.Order)
                 .WithMany(o => o.OrderDetails)
                 .HasForeignKey(od => od.OrderId);

                e.HasOne(od => od.Product)
                 .WithMany(p => p.OrderDetails)
                 .HasForeignKey(od => od.ProductId);
            });
        }
    }
    }
