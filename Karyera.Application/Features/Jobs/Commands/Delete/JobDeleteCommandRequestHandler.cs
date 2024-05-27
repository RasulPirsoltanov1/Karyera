using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Jobs.Commands.Delete
{
    public class JobDeleteCommandRequestHandler : IRequestHandler<JobDeleteCommandRequest, bool>
    {
        IDbContextManager<Job> _dbContextManager;

        public JobDeleteCommandRequestHandler(IDbContextManager<Job> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<bool> Handle(JobDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var job = await _dbContextManager.Table.FirstOrDefaultAsync(x => x.Id == request.JobId);
                if (job == null) return false;
                else
                {
                    _dbContextManager.Table.Remove(job);
                }
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
