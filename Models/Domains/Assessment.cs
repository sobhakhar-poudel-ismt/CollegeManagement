using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.Domains.Auth;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains
{
    public class Assessment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int ModuleId { get; set; }
        public Module? Module { get; set; }

        [Required, StringLength(50)]
        public string AssessmentType { get; set; } = string.Empty;

        [Range(0, 100)]
        public decimal MarksObtained { get; set; }

        [StringLength(5)]
        public string? Grade { get; set; }

        [DataType(DataType.Date)]
        public DateTime AssessmentDate { get; set; } = DateTime.UtcNow;
    }

}
