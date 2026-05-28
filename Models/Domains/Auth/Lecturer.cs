using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains.Auth
{
    public class Lecturer : UserProfile
    {
        [Required]
        [StringLength(20)]
        public string LecturerCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Qualification { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        //+977-xxxxxxxx
        public string PhoneNumber { get; set; } = string.Empty;


    }
}
