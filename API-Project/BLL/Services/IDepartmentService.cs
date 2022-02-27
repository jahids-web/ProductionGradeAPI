using BLL.Request;
using DLL.Models;
using DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.Exceptions;

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
            var department = await _departmentRepository.GetAAsync(code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
            return department;
        }
      
        public async Task<Department> UpdateAsync(string code, Department adepartment)
        {
            var department = await _departmentRepository.GetAAsync(code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
            if (!string.IsNullOrWhiteSpace(adepartment.Code))
            {
                var existsAlreasyCode = await _departmentRepository.FindByCode(adepartment.Code);
                if(existsAlreasyCode!= null)
                {
                    throw new ApplicationValidationException("You updated Code alrady present in our systam");
                }
                department.Code = adepartment.Code;
            }

            if (!string.IsNullOrWhiteSpace(adepartment.Name))
            {
                var existsAlreasyCode = await _departmentRepository.FindByName(adepartment.Name);
                if (existsAlreasyCode != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                department.Name = adepartment.Name;
            }
            if(await _departmentRepository.UpdateAsync(department))
            {
                return department;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }
        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _departmentRepository.GetAAsync(code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
           if( await _departmentRepository.DeleteAsync(department))
            {
                return department;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
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
