using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Categories.Commands.Create
{
    public class CategoryCreateCommandRequest : IRequest<bool>
    {
        [Required, MinLength(2)]
        public string Name { get; set; }
    }

}
