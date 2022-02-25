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
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Code).NotNull().NotEmpty();
            
        }

       
    }
}
