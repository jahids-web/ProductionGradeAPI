using DLL.Interfaces;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DLL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        private const string IsDeletedProperty = "IsDeleted";

        private static readonly MethodInfo _propertyMethod = typeof(EF)
            .GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        private static LambdaExpression GetIsDeletedRestriction(Type type)
        {
            var parm = Expression.Parameter(type, "it");
            var prop = Expression.Call(_propertyMethod, parm, Expression.Constant(IsDeletedProperty));
            var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, parm);
            return lambda;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType) == true)
                {
                    entity.AddProperty(IsDeletedProperty, typeof(bool));
                    modelBuilder.Entity(entity.ClrType).HasQueryFilter(GetIsDeletedRestriction(entity.ClrType));

                }
            }

            base.OnModelCreating(modelBuilder);
        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    await OnBeforeSaving();
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //private async Task OnBeforeSaving()
        //{
        //    ChangeTracker.DetectChanges();
        //    var entries = ChangeTracker.Entries()
        //        .Where(e => e.State != EntityState.Detached && e.State != EntityState.Unchanged);

        //    foreach (var entry in entries)
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Deleted:
        //                entry.Property(IsDeletedProperty).CurrentValue = true;
        //                entry.State = EntityState.Modified;
        //                break;
        //        }
        //    }
        //}


        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> students { get; set; }
    }
}