using DLL.UniteOfWork;
using Microsoft.Extensions.DependencyInjection;


namespace DLL
{
    public class DLLDepandency
    {
        public static void ALLDependency(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            //services.AddTransient<IUnitOfWork, UniteOfWork.IUnitOfWork>();
            // services.AddTransient<IStudentRepository,StudentRepository>();
            // services.AddTransient<IDepartmentRepository,DepartmentRepository>();
        }
    }
}
