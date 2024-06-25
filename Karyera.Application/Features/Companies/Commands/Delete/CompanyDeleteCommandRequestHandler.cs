using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;

namespace Karyera.Application.Features.Companies.Commands.Delete
{
    public class CompanyDeleteCommandRequestHandler : IRequestHandler<CompanyDeleteCommandRequest, bool>
    {
        IDbContextManager<Company> _dbContextManager;

        public CompanyDeleteCommandRequestHandler(IDbContextManager<Company> dbContextManager)
        {
            this._dbContextManager = dbContextManager;
        }

        public async Task<bool> Handle(CompanyDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _dbContextManager.Table.FindAsync(request.CompanyId);
                _dbContextManager.Table.Remove(company);
                await _dbContextManager.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
