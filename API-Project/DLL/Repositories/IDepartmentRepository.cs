using DLL.DataContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IDepartmentRepository
    {
       Task<Department> Insert(Department department);
        Task<List<Department>> GetAll();
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

      public async Task<List<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

   
    }
}
