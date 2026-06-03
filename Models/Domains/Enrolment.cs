using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.Domains.Auth;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains
{
    public class Enrolment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int ModuleId { get; set; }
        public Module? Module { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrolmentDate { get; set; } = DateTime.UtcNow;

        [Required, StringLength(50)]
        public string Status { get; set; } = "Active";
    }
}
