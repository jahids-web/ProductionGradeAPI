
using BLL.Request;
using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace BLL
{
    public static class BLLDepandency
    {
        public static void AllDepandency(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ICourseService, CourseService>();

            AllFluentValidationDepandency(services);
        }

        private static void AllFluentValidationDepandency(IServiceCollection services)
        {
            services.AddTransient<IValidator<DepartmentInsertRequestViewModel>,DepartmentInsertRequestViewModelValidator>();
            services.AddTransient<IValidator<StudentInsertRequestViewModel>, StudentInsertRequestViewModel.StudentInsertRequestViewModelValidator>();
            services.AddTransient<IValidator<CourseInsertRequestViewModel>, CourseInsertRequestViewModelValidator>();
        }
    }
}
