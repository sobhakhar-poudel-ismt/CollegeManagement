using BCrypt.Net;
using CollegeManagement.Models.Domains.Auth;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(IServiceProvider services)
        {
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();

                await context.Database.MigrateAsync();

                // Check existing admin user
                var existingAdmin = await context.Users
                    .FirstOrDefaultAsync(x => x.Role == "Admin");

                if (existingAdmin != null)
                    return;

                // Create User
                var user = new User
                {
                    FullName = "System Administrator",
                    Email = "admin@college.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    Role = "Admin"
                };

                context.Users.Add(user);

                await context.SaveChangesAsync();

                // Create Admin Profile
                var admin = new Admin
                {
                    UserId = user.Id,
                    Position = "Principal"
                };

                context.Set<Admin>().Add(admin);

                await context.SaveChangesAsync();

                Console.WriteLine("Default admin seeded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while seeding admin user.");
                Console.WriteLine(ex.Message);

                // Optional:
                // Console.WriteLine(ex.StackTrace);

                throw;
            }
        }
    }
}