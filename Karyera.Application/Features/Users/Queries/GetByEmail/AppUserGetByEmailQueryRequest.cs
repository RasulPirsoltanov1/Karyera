using Karyera.Application.DTOs.AppUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Users.Queries.GetById
{
    public class AppUserGetByEmailQueryRequest : IRequest<AppUserDTO>
    {
        public string Email { get; set; }
    }
}
