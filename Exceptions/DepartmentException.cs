namespace CollegeManagement.Exceptions
{
    //this
    //base

    //For Create
    public class DuplicateDepartmentException : Exception
    {
        public DuplicateDepartmentException(string name)
            : base($"Department '{name}' already exists.")
        {
        }
    }

    //For Update
    public class DepartmentNotFoundException : Exception
    {
        public DepartmentNotFoundException(int id)
        : base($"Department with ID {id} was not found.")
        {
        }
    }


}
