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
        Task<Department> InsertAsync(Department department);
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

        public async Task<Department> InsertAsync(Department department)
        {
            //Department adepartmet = new Department();
        
            await _departmentRepository.CreateAsync(department);
            if (await _departmentRepository.SaveCompletedAsync())
            {
                return department;
            }
            throw new ApplicationValidationException("Depatment insert has some problem");
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetList();
        }
        public async Task<Department> GetAAsync(string code)
        {
            var department = await _departmentRepository.FindSingLeAsync( x=>x.Code==code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
            return department;
        }
      
        public async Task<Department> UpdateAsync(string code, Department adepartment)
        {
            var department = await _departmentRepository.FindSingLeAsync(x => x.Code == code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
            if (!string.IsNullOrWhiteSpace(adepartment.Code))
            {
                var existsAlreasyCode = await _departmentRepository.FindSingLeAsync(x => x.Code == code);
                if (existsAlreasyCode!= null)
                {
                    throw new ApplicationValidationException("You updated Code alrady present in our systam");
                }
                department.Code = adepartment.Code;
            }

            if (!string.IsNullOrWhiteSpace(adepartment.Name))
            {
                var existsAlreasyCode = await _departmentRepository.FindSingLeAsync(x => x.Name == adepartment.Name);
                if (existsAlreasyCode != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                department.Name = adepartment.Name;
            }
            _departmentRepository.Update(department);
            if(await _departmentRepository.SaveCompletedAsync())
            {
                return department;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }
        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _departmentRepository.FindSingLeAsync(x => x.Code == code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
                _departmentRepository.Delete(department);
            if (await _departmentRepository.SaveCompletedAsync())
            {
                return department;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }

        public async Task<bool> IsCodeExists(string code)
        {
           var department = await _departmentRepository.FindSingLeAsync(x => x.Code == code);
            if (department == null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.FindSingLeAsync(x => x.Name == name);
            if (department == null)
            {
                return true;
            }
            return false;
        }
    }
}
