using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.Domains.Auth;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains
{
    public class Attendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int ModuleId { get; set; }
        public Module? Module { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required, StringLength(20)]
        public string Status { get; set; } = "Present";
    }
}
