using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Jobs.Queries
{
    public class JobGetByIdQueryRequestHandler : IRequestHandler<JobGetByIdQueryRequest, Job>
    {
        IDbContextManager<Job> _dbContextManager;

        public JobGetByIdQueryRequestHandler(IDbContextManager<Job> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<Job> Handle(JobGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var job = await _dbContextManager.Table.FirstOrDefaultAsync(x => x.Id == request.JobId);
                if (job == null)
                {
                    return null;
                }
                return job;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
