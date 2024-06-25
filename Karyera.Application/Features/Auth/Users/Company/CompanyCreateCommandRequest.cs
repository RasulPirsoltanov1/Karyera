using Karyera.Application.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Auth.Users.Company
{
    public class CompanyCreateCommandRequest : IRequest<IdentityResult>
    {
        [EmailAddress]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
