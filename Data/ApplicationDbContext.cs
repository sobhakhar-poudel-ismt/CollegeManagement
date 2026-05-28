using CollegeManagement.Models.Domains.Auth;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { 
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
