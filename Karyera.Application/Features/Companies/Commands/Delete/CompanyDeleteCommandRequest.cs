using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Companies.Commands.Delete
{
    public class CompanyDeleteCommandRequest:IRequest<bool>
    {
        public int CompanyId { get; set; }
    }
    public class CompanyDeleteCommandRequestHandler : IRequestHandler<CompanyDeleteCommandRequest, bool>
    {
        public Task<bool> Handle(CompanyDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
