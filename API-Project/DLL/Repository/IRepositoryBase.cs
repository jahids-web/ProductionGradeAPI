using DLL.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DLL.UniteOfWork
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> QueryAll(Expression<Func<T, bool>> expression = null);
        Task<List<T>> GetList(Expression<Func<T, bool>> expression = null);
        Task CreateAsync(T entry);
        Task CreateAsyncRange(List<T> entryList);
        void Update(T entry);
        void UpdateRange(List<T> entryList);
        void Delete(T entry);   
        void DeleteRange(List<T> entryList);
        Task<T> FindSingLeAsync(Expression<Func<T, bool>> exception);
        Task<bool> SaveCompletedAsync();
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

        public async Task<List<T>> GetList(Expression<Func<T, bool>> expression = null)
        {
            return  expression != null ? await _context.Set<T>().AsQueryable().Where(expression).AsNoTracking().ToListAsync() :
              await  _context.Set<T>().AsQueryable().AsNoTracking().ToListAsync();
        }
        public async Task CreateAsync(T entry)
        {
            await _context.Set<T>().AddAsync(entry);
        }
        public async Task CreateAsyncRange(List<T> entryList)
        {
           await _context.Set<T>().AddRangeAsync(entryList);
        }
        public void Delete(T entry)
        {
            _context.Set<T>().Remove(entry);
        }

        public void DeleteRange(List<T> entryList)
        {
            _context.Set<T>().RemoveRange(entryList);
        }

        public async Task<T> FindSingLeAsync(Expression<Func<T, bool>> exception)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(exception);
        }
        public void Update(T entry)
        {
            _context.Set<T>().Update(entry);
        }

        public void UpdateRange(List<T> entryList)
        {
            _context.Set<T>().UpdateRange(entryList);
        }

        public async Task<bool> SaveCompletedAsync()
        {
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
