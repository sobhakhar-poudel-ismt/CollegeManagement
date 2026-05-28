using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagement.Models.Domains.Auth
{
    public abstract class BaseUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }


    public class User : BaseUser
    {
        [Required]
        public string Role { get; set; }
    }

    public abstract class UserProfile
    {
        [Required]
        [Key]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}

