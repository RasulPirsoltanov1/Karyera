using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Categories.Commands.Create
{
    public class CategoryCreateCommandRequestValidator:AbstractValidator<CategoryCreateCommandRequest>
    {
        public CategoryCreateCommandRequestValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(50).NotNull();
        }
    }
}
