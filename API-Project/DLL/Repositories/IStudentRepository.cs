using DLL.DataContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLL.Repositories
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
