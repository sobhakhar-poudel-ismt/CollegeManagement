namespace CollegeManagement.Helper
{

        public  class NavigationItem
        {
        public string Url;
        public string Title;

        public NavigationItem()
        {
        }

        public NavigationItem(string Title, string Url)
        {
            this.Url = Url;
            this.Title = Title;
        }
    }
    public static class NavigationProvider
    {
        public static List<NavigationItem> GetMenu(string role)
        {
            return role switch
            {
                "Admin" => new()
            {
                new() { Title = "Dashboard", Url = "/admin/dashboard" },
                new() { Title = "Manage Students", Url = "/admin/students" },
                new() { Title = "Manage Lecturers", Url = "/admin/lecturers" },
                new() { Title = "Manage Departments", Url = "/admin/departments" }
            },
                "Lecturer" => new()
            {
                new() { Title = "Dashboard", Url = "/lecturer/dashboard" },
                new() { Title = "Modules", Url = "/lecturer/modules" },
                new() { Title = "Attendance", Url = "/lecturer/attendance" }
            },

                "Student" => new()
            {
                new() { Title = "Dashboard", Url = "/student/dashboard" },
                new() { Title = "Courses", Url = "/student/courses" },
                new() { Title = "Attendance", Url = "/student/attendance" }
            },

                _ => []
            };
        }
    }

}
