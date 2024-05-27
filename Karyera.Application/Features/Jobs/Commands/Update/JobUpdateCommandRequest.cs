﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Jobs.Commands.Update
{
    public class JobUpdateCommandRequest:IRequest<bool>
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string? Company { get; set; }

        public string? Location { get; set; }

        public string? Description { get; set; }

        public DateTime? EndDate { get; set; }

        public List<string>? Requirements { get; set; }

        [EmailAddress]
        public string? ContactEmail { get; set; }

        public int? CategoryId { get; set; }

        public bool IsRemote { get; set; } = false;

        [Range(0, double.MaxValue)]
        public decimal? Salary { get; set; }
    }
}
