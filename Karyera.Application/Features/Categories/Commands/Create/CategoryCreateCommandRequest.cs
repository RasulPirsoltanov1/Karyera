﻿using MediatR;
using Microsoft.AspNetCore.Http;
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
        public int? SubCategoryId { get; set; }
        public IFormFile? Image{ get; set; }
    }

}
