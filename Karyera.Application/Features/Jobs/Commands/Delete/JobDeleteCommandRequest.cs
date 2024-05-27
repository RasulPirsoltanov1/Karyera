using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Jobs.Commands.Delete
{
    public class JobDeleteCommandRequest : IRequest<bool>
    {
        public int JobId { get; set; }
    }
}
