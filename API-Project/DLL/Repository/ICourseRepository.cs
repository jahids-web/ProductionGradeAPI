using DLL.DbContext;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLL.UniteOfWork
{
    public interface ICourseRepository : IRepositoryBase<CourseRepository>
    {
        Task<CourseRepository> GetAAsynce(Func<object, bool> p);
        Task<List<CourseRepository>> GetListAsynce();
    }

    public class CourseRepository : RepositoryBase<CourseRepository>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Task<CourseRepository> GetAAsynce(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public Task<List<CourseRepository>> GetListAsynce()
        {
            throw new NotImplementedException();
        }
    }
}
