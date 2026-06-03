using CollegeManagement.Models.Domains.Auth;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains.Academics
{
    public class Module
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 30)]
        public int CreditHours { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int? LecturerId { get; set; }
        public Lecturer? Lecturer { get; set; }

        public List<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
        public List<Assessment> Assessments { get; set; } = new List<Assessment>();
    }
}
