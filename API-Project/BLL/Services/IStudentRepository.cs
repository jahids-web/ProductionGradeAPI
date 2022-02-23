using DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IStudentRepository
    {
        Task<Student> InsertAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student> UpdateAsync(string email, Student student);
        Task<Student> DeleteAsync(string email);
        Task<Student> GetAAsync(string email);
    }

    public class StudentRepository : IStudentRepository
    {
        private IStudentRepository _studnetRepository;

        public StudentRepository(IStudentRepository studentRepository)
        {
            _studnetRepository = studentRepository;
        }

        public async Task<Student> InsertAsync(Student student)
        {
            return await _studnetRepository.InsertAsync(student);
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _studnetRepository.GetAllAsync();
        }
        public async Task<Student> GetAAsync(string email)
        {
            return await _studnetRepository.GetAAsync(email);
        }
        public async Task<Student> UpdateAsync(string email, Student student)
        {
            return await _studnetRepository.UpdateAsync(email,student);
        }
        public async Task<Student> DeleteAsync(string email)
        {
            return await _studnetRepository.DeleteAsync(email);
        }
    }
}
