using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Xml;

namespace API.TechsysLog.DataContext
{
    public class AdminSeeder
    {
        public static void SeedData(IApplicationBuilder app)
        {
            try
            {

                var context = new ConnectionContext();

                context.Database.Migrate();
                if (!context.Users.Any())
                {
                    context.Users.Add(new Domain.User("admin", "admin@admin.com", BCryptor.Encrypt("techsyslog"), 0));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
            }
        }
    }
}
