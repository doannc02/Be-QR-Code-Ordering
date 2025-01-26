using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderEats.Library.Models.Entities
{
    public class OrderEatsDbContext : DbContext
    {
        public OrderEatsDbContext(DbContextOptions<OrderEatsDbContext> options)
            : base(options) { }

        // Các DbSet cho các thực thể trong ứng dụng
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<OrderItemNote> OrderItemsNote { get; set; }
        public DbSet<TableHistory> TableHistories { get; set; }
        public DbSet<NotificationLog> NotificationLog { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Counter> Counters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình Notification với Fluent API
            modelBuilder.Entity<Notification>()
                .ToTable("Notifications")
                .HasKey(n => n.Id); // Thay NotificationId thành Id

            modelBuilder.Entity<Notification>()
                .Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<Notification>()
                .Property(n => n.NotificationDate)
                .IsRequired();

            modelBuilder.Entity<Notification>()
                .Property(n => n.Type)
                .HasConversion<int>();

            modelBuilder.Entity<Notification>()
                .Property(n => n.IsDeleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<Notification>()
                .Property(n => n.IsRead)
                .HasDefaultValue(false);

            // Cấu hình Order với Fluent API
            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(o => o.Id); // Thay OrderId thành Id

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Cấu hình OrderItem với Fluent API
            modelBuilder.Entity<OrderItem>()
                .ToTable("OrderItems")
                .HasKey(oi => oi.Id); // Thay OrderItemId thành Id

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Notes)
                .HasMaxLength(200);

            // Cấu hình FoodItem với Fluent API
            modelBuilder.Entity<FoodItem>()
                .ToTable("FoodItems")
                .HasKey(fi => fi.Id); // Thay FoodItemId thành Id

            modelBuilder.Entity<FoodItem>()
                .Property(fi => fi.Price)
                .HasColumnType("decimal(18,2)");

            // Cấu hình Category với Fluent API
            modelBuilder.Entity<Category>()
                .ToTable("Categories")
                .HasKey(c => c.Id); // Thay CategoryId thành Id

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Cấu hình Table với Fluent API
            modelBuilder.Entity<Table>()
                .ToTable("Tables")
                .HasKey(t => t.Id); // Thay TableId thành Id

            modelBuilder.Entity<Table>()
                .Property(t => t.TableNumber)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Table>()
                .Property(t => t.QRCode)
                .IsRequired()
                .HasMaxLength(500);

            // Cấu hình Payment với Fluent API
            modelBuilder.Entity<Payment>()
                .ToTable("Payments")
                .HasKey(p => p.Id); // Thay PaymentId thành Id

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            // Cấu hình Address với Fluent API
            modelBuilder.Entity<Address>()
                .ToTable("Addresses")
                .HasKey(a => a.Id); // Thay AddressId thành Id

            modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Address>()
                .Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
