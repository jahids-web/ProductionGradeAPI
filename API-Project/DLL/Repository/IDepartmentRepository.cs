using DLL.DbContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
