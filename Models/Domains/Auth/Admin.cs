using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains.Auth
{
    public class Admin : UserProfile
    {
        [Required]
        [StringLength(100)]
        public string Position { get; set; }
    }
}
