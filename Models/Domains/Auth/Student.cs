using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains.Auth
{
    public class Student : UserProfile
    {
        [Required]
        [StringLength(20)]
        public string StudentCode { get; set; }

        [Required]
        [StringLength(15)]
        //+977-xxxxxxxx
        public string PhoneNumber { get; set; } = string.Empty;


        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
