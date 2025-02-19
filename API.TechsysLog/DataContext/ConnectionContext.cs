using API.TechsysLog.Domain;
using API.TechsysLog.Models;
using Microsoft.EntityFrameworkCore;

namespace API.TechsysLog.DataContext
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<UserOrders> UserOrders { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public ConnectionContext(DbContextOptions<ConnectionContext> options)
        : base(options) 
        {
        }
        public ConnectionContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Server=localhost,1433;" +
                "Database=techsyslog;" +
                "User Id=sa;" +
                "Password=Abc1023123;" +
                "TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Delivery>().ToTable("Delivery");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<UserOrders>().ToTable("User_order");
            modelBuilder.Entity<Notification>().ToTable("Notification");

        }

    }
}
