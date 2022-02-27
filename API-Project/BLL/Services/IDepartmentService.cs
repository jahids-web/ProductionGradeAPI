using BLL.Request;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IDepartmentService
    {
        Task<Department> InsertAsync(DepartmentInsertRequestViewModel request);
        Task<List<Department>> GetAllAsync();
        Task<Department> UpdateAsync(string code, Department department);
        Task<Department> DeleteAsync(string code);
        Task<Department> GetAAsync(string code);
        Task<bool>IsCodeExists(string code);
        Task<bool>IsNameExists(string name);
    }

    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> InsertAsync(DepartmentInsertRequestViewModel request)
        {
            Department adepartmet = new Department();
            adepartmet.Code = request.Code;
            adepartmet.Name = request.Name;
            return await _departmentRepository.InsertAsync(adepartmet); 
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }
        public async Task<Department> GetAAsync(string code)
        {
            return await _departmentRepository.GetAAsync(code);
        }
      
        public async Task<Department> UpdateAsync(string code, Department department)
        {
            return await _departmentRepository.UpdateAsync(code, department);
        }
        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _departmentRepository.GetAAsync(code);
            if (department == null)
            {
                throw new Exception("Department not found");
            }
           if( await _departmentRepository.DeleteAsync(department))
            {
                return department;
            }
            throw new Exception("Some Problem for delete data");
        }

        public async Task<bool> IsCodeExists(string code)
        {
           var department = await _departmentRepository.FindByCode(code);
            if(department == null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindByName(name);
            if (department == null)
            {
                return true;
            }
            return false;
        }
    }
}
