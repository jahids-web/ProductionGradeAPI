using DLL.Models;
using DLL.UniteOfWork;
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

    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;


        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> InsertAsync(Department department)
        {
            await _unitOfWork.DepartmentRepository.CreateAsync(department);
            if (await _unitOfWork.DepartmentRepository.SaveCompletedAsync())
            {
                return department;
            }
            throw new ApplicationValidationException("Depatment insert has some problem");
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _unitOfWork.DepartmentRepository.GetList();
        }
        public async Task<Department> GetAAsync(string code)
        {
            var department = await _unitOfWork.DepartmentRepository.FindSingLeAsync( x=>x.Code==code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
            return department;
        }
      
        public async Task<Department> UpdateAsync(string code, Department adepartment)
        {
            var department = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.Code == code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
            if (!string.IsNullOrWhiteSpace(adepartment.Code))
            {
                var existsAlreasyCode = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.Code == code);
                if (existsAlreasyCode!= null)
                {
                    throw new ApplicationValidationException("You updated Code alrady present in our systam");
                }
                department.Code = adepartment.Code;
            }

            if (!string.IsNullOrWhiteSpace(adepartment.Name))
            {
                var existsAlreasyCode = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.Name == adepartment.Name);
                if (existsAlreasyCode != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                department.Name = adepartment.Name;
            }
            _unitOfWork.DepartmentRepository.Update(department);
            if(await _unitOfWork.DepartmentRepository.SaveCompletedAsync())
            {
                return department;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }
        public async Task<Department> DeleteAsync(string code)
        {
            var department = await _unitOfWork.DepartmentRepository.FindSingLeAsync(x => x.Code == code);
            if (department == null)
            {
                throw new ApplicationValidationException("Depatment Not Found");
            }
            _unitOfWork.DepartmentRepository.Delete(department);
            if (await _unitOfWork.DepartmentRepository.SaveCompletedAsync())
            {
                return department;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }
        
      
    }
}
