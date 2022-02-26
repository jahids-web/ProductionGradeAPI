using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Request
{
    public class DepartmentInsertRequestViewModel
    {
        public string Name { get; set; }    
        public string Code { get; set; } 
    }

    public class DepartmentInsertRequestViewModelValidator : AbstractValidator<DepartmentInsertRequestViewModel>
    {
        private readonly IServiceProvider _serviceProvider;

        public DepartmentInsertRequestViewModelValidator(IServiceProvider serviceProvider)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty()
                .MustAsync(NameExists).WithMessage("Name Exists in our system");
            RuleFor(x => x.Code).NotNull().NotEmpty()
                .MustAsync(CodeExists).WithMessage("Code Exists in our system");
        }

        private async Task<bool> CodeExists(string code, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(code))
            {
                return true;
            }
            var requeiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requeiredService.IsCodeExists(code);
        }

        private async Task<bool> NameExists(string name, CancellationToken arg2)
        {
            if (string.IsNullOrEmpty(name))
            {
                return true;
            }
            var requeiredService = _serviceProvider.GetRequiredService<IDepartmentService>();
            return await requeiredService.IsNameExists(name);
        }
    }
}
