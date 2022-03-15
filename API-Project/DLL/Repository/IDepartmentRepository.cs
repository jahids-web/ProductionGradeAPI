using DLL.DbContext;
using DLL.Models;

namespace DLL.UniteOfWork
{
    public interface IDepartmentRepository:IRepositoryBase<Department>
    {
     
    }

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
