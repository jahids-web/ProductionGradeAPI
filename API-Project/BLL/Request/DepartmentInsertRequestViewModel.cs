using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Request
{
    public class DepartmentInsertRequestViewModel
    {
        public string Name { get; set; }    
        public string Code { get; set; } 
    }

    public class DepartmentInsertRequestViewModelValidator : AbstractValidator<DepartmentInsertRequestViewModel>
    {
        public DepartmentInsertRequestViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(4).MinimumLength(25);
            RuleFor(x => x.Code).NotNull().NotEmpty().MinimumLength(3).MaximumLength(10);
            
        }

       
    }
}
