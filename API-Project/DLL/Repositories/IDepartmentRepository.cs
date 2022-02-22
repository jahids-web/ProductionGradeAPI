using DLL.DataContext;
using DLL.Models;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IDepartmentRepository
    {
        Department Insert(Department department);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<Department> Insert(Department department)
        {
          await _context.Departments.AddAsync(department);
          await  _context.SaveChangesAsync();
            return department;

        }

        Department IDepartmentRepository.Insert(Department department)
        {
            throw new System.NotImplementedException();
        }
    }
}
