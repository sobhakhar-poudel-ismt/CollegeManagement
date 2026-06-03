using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains.Academics
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Level { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Duration { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public List<Module> Modules { get; set; } = new List<Module>();
        public List<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}
