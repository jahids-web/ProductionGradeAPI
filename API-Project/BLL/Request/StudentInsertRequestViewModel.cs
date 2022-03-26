using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Request
{
    public class StudentInsertRequestViewModel
    {
        public string Name { get; set; }    
        public string Email { get; set; }
        public int DepartmentId { get; set; }

        public class StudentInsertRequestViewModelValidator : AbstractValidator<StudentInsertRequestViewModel>
        {

            private readonly IServiceProvider _serviceProvider;

            public StudentInsertRequestViewModelValidator(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
                RuleFor(x => x.Name).NotNull().NotEmpty()
                    .MinimumLength(4).WithMessage("name already exists");

                RuleFor(x => x.Email).NotNull().NotEmpty().MinimumLength(8).MustAsync(EmailExists)
                    .MaximumLength(20).WithMessage("code already exists");

                RuleFor((x => x.DepartmentId)).NotNull().NotEmpty().MustAsync(DepartmentExists)
                  .WithMessage("DepartmentId already exists");
            }

            private async Task<bool> EmailExists(string email, CancellationToken arg2)
            {
                if (string.IsNullOrEmpty(email))
                {
                    return true;
                }
                var requiredService = _serviceProvider.GetRequiredService<IStudentService>();
                return await requiredService.EmailExists(email);
            }

            private async Task<bool> DepartmentExists(int id, CancellationToken arg2)
            {
                var requiredService = _serviceProvider.GetRequiredService<IStudentService>();
                return !await requiredService.IsIdExists(id);
            }
        }

    }
}
