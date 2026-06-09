using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.ViewModels;
namespace CollegeManagement.Helper.Mapper
{
    public static class DepartmentMapper
    {
        public static DepartmentViewModel ToViewModel(
            Department department
        )
        {
            return new DepartmentViewModel
            {
                DepartmentId = department.Id,
                Name = department.Name,
                Description = department.Description
            };
        }

        public static Department ToDomainModel(
            DepartmentViewModel model
        )
        {
            return new Department
            {
                Id = model.DepartmentId,
                Name = model.Name,
                Description = model.Description
            };
        }

        public static void UpdateDomainModel(
            Department department,
            DepartmentViewModel model
        )
        {
            department.Name = model.Name;
            department.Description = model.Description;
        }
    }

}

//Department Repo
// Department Service [Incomplete implemetation]
// Department ViewModel
// Mapper
// Razor Component
