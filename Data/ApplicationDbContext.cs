using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.Domains;
using CollegeManagement.Models.Domains.Auth;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { 
        }

        //Auth User
        public DbSet<User> Users { get; set; }

        //System User
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Admin> Admins { get; set; }


        //Academic
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }

 

        // Academic records
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Assessment> Assessments { get; set; }

    }
}
