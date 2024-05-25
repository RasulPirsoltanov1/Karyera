using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Categories.Commands.Create
{
    public class CategoryUpdateCommandRequest : IRequest<bool>
    {
        [Required]
        public int Id{ get; set; }
        [Required, MinLength(2)]
        public string Name { get; set; }
        public int? SubCategoryId { get; set; }
        public IFormFile? Image{ get; set; }
        public string? ImageUrl{ get; set; }
    }

}
