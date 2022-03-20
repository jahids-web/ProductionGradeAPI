using FluentValidation;
using System;

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
            _serviceProvider = serviceProvider;
            RuleFor((x => x.Name)).NotNull().NotEmpty()
                .MinimumLength(4).WithMessage("name already exists");
            RuleFor((x => x.Code)).NotNull().NotEmpty().MinimumLength(4)
                .MaximumLength(12).WithMessage("code already exists");
        }

     
    }
}