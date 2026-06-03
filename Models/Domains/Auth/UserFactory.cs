namespace CollegeManagement.Models.Domains.Auth
{

   public enum Role
    {
        Admin,
        Lecturer,
        Student
    }

    public class UserFactory
    {
        //Factory Method
       public static UserProfile manageUserInstance(Role role) {
            if (role == Role.Admin)
            {
                return new Admin();
            }
            else if (role == Role.Lecturer) {
                return new Lecturer();
            }
            else
            {
                return new Student();
            } 
       }
    }
}
