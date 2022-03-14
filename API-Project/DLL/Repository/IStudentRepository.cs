using DLL.DbContext;
using DLL.Models;

namespace DLL.UniteOfWork
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
    


    }

    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
