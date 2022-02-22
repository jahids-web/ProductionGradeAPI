﻿using DLL.DataContext;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL
{
    public class DLLDepandency
    {
        public static void AllDepandency(IServiceCollection services, IConfiguration configuration)
        {
            var mm = configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

            //repository dependency
            services.AddTransient<IDepartmentRepository,DepartmentRepository>();
        }
    }
}
