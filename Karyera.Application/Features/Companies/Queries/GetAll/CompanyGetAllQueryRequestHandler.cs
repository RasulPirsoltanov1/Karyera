using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Companies.Queries.GetAll
{
    public class CompanyGetAllQueryRequestHandler : IRequestHandler<CompanyGetAllQueryRequest, List<Company>>
    {
        IDbContextManager<Company> _dbContextManager;

        public CompanyGetAllQueryRequestHandler(IDbContextManager<Company> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<List<Company>> Handle(CompanyGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var compaines = await _dbContextManager.Table.ToListAsync();
                return compaines;
            }
            catch (Exception)
            {
                return new List<Company>();
            }
        }
    }

}
