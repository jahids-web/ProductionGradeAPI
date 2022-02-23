using DLL.DataContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> InsertAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student> UpdateAsync(string code, Student student);
        Task<Student> DeleteAsync(string code);
        Task<Student> GetAAsync(string code);


    }

    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> InsertAsync(Student student)
        {
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;

        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Student> DeleteAsync(string email)
        {
            var student = await _context.students.FirstOrDefaultAsync(x => x.Email == email);

            _context.students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetAAsync(string email)
        {
            var student = await _context.students.FirstOrDefaultAsync(x => x.Email == email);
            return student;

        }

        public async Task<Student> UpdateAsync(string email, Student student)
        {
            var findStudent = await _context.students.FirstOrDefaultAsync(x => x.Email == email);
            findStudent.Name = student.Name;
            _context.students.Update(findStudent);
            await _context.SaveChangesAsync();
            return findStudent;

        }




    }
}
