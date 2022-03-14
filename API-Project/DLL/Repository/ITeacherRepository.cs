using DLL.DbContext;
using DLL.Model;
using DLL.UniteOfWork;

namespace DLL.Repository
{
    public interface ITeacherRepository:IRepositoryBase<Teacher>
    {

    }

    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
