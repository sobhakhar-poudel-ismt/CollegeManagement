using CollegeManagement.Models.Domains.Academics;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Data.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(Department department);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Department department)
        {
           await _context.Departments.AddAsync(department);
           await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Department department)
        {
            _context.Departments.Remove(department);
           await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            return _context.Departments.AnyAsync(d => d.Name == name);
        }

        public Task<List<Department>> GetAllAsync()
        {
          Task<List<Department>> a =  _context.Departments.ToListAsync();
            return a;
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
          return await  _context.Departments.FindAsync(id);
        }

        public Task UpdateAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
