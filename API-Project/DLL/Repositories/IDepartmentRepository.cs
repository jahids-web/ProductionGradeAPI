using DLL.DataContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> InsertAsync(Department department);
        Task<List<Department>> GetAllAsync();
        Task<Department> UpdateAsync(string code, Department department);
        Task<Department> DeleteAsync(string code);
        Task<Department> GetAAsync(string code);
        Task <Department> FindByCode(string code);
        Task <Department> FindByName(string name);
    }

    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<Department> InsertAsync(Department department)
        {
          await _context.Departments.AddAsync(department);
          await  _context.SaveChangesAsync();
            return department;

        }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department> DeleteAsync(string code)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department> GetAAsync(string code)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
        return department;

    }

    public async Task<Department> UpdateAsync(string code,Department department)
    {
        var findDepartment = await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
            findDepartment.Code = department.Code;
            _context.Departments.Update(findDepartment);
            await _context.SaveChangesAsync();
        return department;

    }

        public async Task<Department> FindByCode(string code)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Department> FindByName(string name)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
