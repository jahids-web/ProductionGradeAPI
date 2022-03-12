using DLL.DbContext;
using DLL.UniteOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
//using System.Configuration;

namespace DLL
{
    public class DLLDepandency
    {
        public static void ALLDependency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            
            // services.AddTransient<IStudentRepository,StudentRepository>();
            // services.AddTransient<IDepartmentRepository,DepartmentRepository>();
        }
    }
}
