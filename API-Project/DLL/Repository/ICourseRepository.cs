using DLL.DbContext;
using DLL.Model;
using DLL.Models;

namespace DLL.UniteOfWork
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
     
    }

    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
