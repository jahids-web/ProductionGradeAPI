﻿using DLL.Models;
using Microsoft.EntityFrameworkCore;


namespace DLL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> students { get; set; }
    }
}
