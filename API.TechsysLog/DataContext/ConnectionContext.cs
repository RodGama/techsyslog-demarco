using API.TechsysLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.TechsysLog.DataContext
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Server=localhost;" +
                "Database=techsyslog;" +
                "User Id=sa;" +
                "Password=Abc1023123;");
        
        
    }
}
