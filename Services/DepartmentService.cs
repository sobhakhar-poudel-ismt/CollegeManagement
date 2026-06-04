using CollegeManagement.Models.ViewModels;

namespace CollegeManagement.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task AddAsync(DepartmentViewModel model);
        Task UpdateAsync(DepartmentViewModel model);
        Task DeleteAsync(int id);
    }

    public class DepartmentService : IDepartmentService
    {
        public Task AddAsync(DepartmentViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DepartmentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
