using CollegeManagement.Components.Pages.Admin;
using CollegeManagement.Data.Repositories;
using CollegeManagement.Exceptions;
using CollegeManagement.Helper.Mapper;
using CollegeManagement.Models.Domains.Academics;
using CollegeManagement.Models.ViewModels;

namespace CollegeManagement.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task AddAsync(DepartmentViewModel model);
        Task UpdateAsync(DepartmentViewModel model);
        Task DeleteAsync(DepartmentViewModel model);
    }

    public class DepartmentService : IDepartmentService
    {

        //readonly
        //Initialize 
        //Constructor
        //No Change after that
        private readonly IDepartmentRepository repository;

        //Constructor DI
        public DepartmentService(IDepartmentRepository _repo) { 
            repository= _repo;
        }
        public async Task AddAsync(DepartmentViewModel model)
        {
            var domainModel = DepartmentMapper.ToDomainModel(model);
            var exists = await repository.ExistsByNameAsync(domainModel.Name);
            if (exists) {
                throw new DuplicateDepartmentException(domainModel.Name);
            }
            await repository.AddAsync(domainModel);
        }

        public async Task DeleteAsync(DepartmentViewModel model)
        {
            var department = DepartmentMapper.ToDomainModel(model);
            await repository.DeleteAsync(department);
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
           var departments= await repository.GetAllAsync();
           return departments.Select(x => DepartmentMapper.ToViewModel(x)).ToList();
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
