using FluentValidation;
using Karyera.Application.Features.Categories.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Categories.Commands.Update
{
    public class CategoryUpdateCommandRequestValidator:AbstractValidator<CategoryUpdateCommandRequest>
    {
        public CategoryUpdateCommandRequestValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).MaximumLength(50).NotNull();
        }
    }
}
