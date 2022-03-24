
using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Request
{
    public class CourseInsertRequestViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Credit  { get; set; }
    }

    public class CourseInsertRequestViewModelValidator : AbstractValidator<CourseInsertRequestViewModel>
    {

        private readonly IServiceProvider _serviceProvider;

        public CourseInsertRequestViewModelValidator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            RuleFor((x => x.Name)).NotNull().NotEmpty()
                .MinimumLength(4).MustAsync(NameExists).WithMessage("name already exists");
            RuleFor((x => x.Code)).NotNull().NotEmpty().MinimumLength(3)
                .MaximumLength(12).MustAsync(CodeExists).WithMessage("code already exists");

            RuleFor((x => x.Credit)).NotNull().NotEmpty();
        }

        private async Task<bool> CodeExists(string code, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return true;
            }

            var departmentService = _serviceProvider.GetRequiredService<ICourseService>();

            return !await departmentService.IsCodeExits(code);
        }

        private async Task<bool> NameExists(string name, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return true;
            }
            var departmentService = _serviceProvider.GetRequiredService<ICourseService>();

            return !await departmentService.IsNameExists(name);
        }
    }

}
