using DLL.DataContext;
using System;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public interface IUnitOfWork
    {
        IDepartmentRepository DepartmentRepository { get; }
        IStudentRepository StudentRepository { get; }
        Task<bool> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        private IDepartmentRepository _departmentRepository;
        private IStudentRepository _studentRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public UnitOfWork(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IDepartmentRepository DepartmentRepository =>
            _departmentRepository ?? new DepartmentRepository(_context);

        public IStudentRepository StudentRepository =>
            _studentRepository ?? new StudentRepository(_context);
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
