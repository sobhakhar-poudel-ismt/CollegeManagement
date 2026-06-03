using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CollegeManagement.Models.Domains.Auth;

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
























/*public enum UserRole
{
    Admin,
    Lecturer,
    Student
}*/
/*public static class UserProfileFactory
{
    public static UserProfile CreateProfile(UserRole role)
    {
        return role switch
        {
            UserRole.Admin => new Admin(),
            UserRole.Lecturer => new Lecturer(),
            UserRole.Student => new Student(),
            _ => throw new ArgumentException("Invalid user role")
        };
    }
}*/



/*public interface IStudentObserver
{
    void Update(string message);
}

public class StudentObserver : IStudentObserver
{
    public string Name { get; }

    public StudentObserver(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{Name} received notification: {message}");
    }
}

public class ModuleSubject
{
    private readonly List<IStudentObserver> _students = new();

    public string ModuleName { get; }

    public ModuleSubject(string moduleName)
    {
        ModuleName = moduleName;
    }

    public void Attach(IStudentObserver student)
    {
        _students.Add(student);
    }

    public void Detach(IStudentObserver student)
    {
        _students.Remove(student);
    }

    public void Notify(string message)
    {
        foreach (var student in _students)
        {
            student.Update(message);
        }
    }

    public void UploadAssignment(string assignmentTitle)
    {
        Console.WriteLine($"Assignment uploaded in {ModuleName}");

        Notify($"New assignment: {assignmentTitle} in {ModuleName}");
    }
}

var module = new ModuleSubject("Object Oriented Programming");

var ram = new StudentObserver("Ram");
var sita = new StudentObserver("Sita");
var hari = new StudentObserver("Hari");

module.Attach(ram);
module.Attach(sita);
module.Attach(hari);

module.UploadAssignment("Observer Pattern Homework");*/