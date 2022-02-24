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
            return await _departmentRepository.DeleteAsync(code);
        }
    }
}
