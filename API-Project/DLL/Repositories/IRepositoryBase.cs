using DLL.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null);
        List<T> GetList(Expression<Func<T, bool>> expression = null);
        Task CreateAsync(T entry);
        void Update(T entry);
        void UpdateRange(List<T> entryList);
        void Delete(T entry);   
        void DeleteRange(List<T> entryList);
        Task<T> FindSingLeAsyc(Expression<Func<T, bool>> exception);

    }
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }


        public IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null)
        {
            return expression != null ? _context.Set<T>().AsQueryable().Where(expression).AsNoTracking(): _context.Set<T>().AsQueryable().AsNoTracking();
        }

        public List<T> GetList(Expression<Func<T, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
        public Task CreateAsync(T entry)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entry)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<T> entryList)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindSingLeAsyc(Expression<Func<T, bool>> exception)
        {
            throw new NotImplementedException();
        }
        public void Update(T entry)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(List<T> entryList)
        {
            throw new NotImplementedException();
        }
    }
}
