
using FluentValidation;
using System;

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
            RuleFor(x => x.Name).NotNull().NotEmpty()
                .MinimumLength(4).WithMessage("name already exists");

            RuleFor(x => x.Code).NotNull().NotEmpty().MinimumLength(4)
                .MaximumLength(12).WithMessage("code already exists");

            RuleFor(x => x.Credit).NotNull().NotEmpty();
        }


    }
}