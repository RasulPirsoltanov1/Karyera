using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Users.Commands.SetStatus
{
    public class AppUserSetStatusCommandRequest : IRequest<bool>
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
