using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Companies.Commands.Create
{
    public class CompanyCreateCommandRequest : IRequest<bool>
    {
        // Şirkətin xüsusiyyətləri
        public string? Name { get; set; }
        public IFormFile? Image { get; set; }
        public string? Industry { get; set; } // Sənaye
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? ContactEmail { get; set; }
        public string? Website { get; set; }
    }
}
