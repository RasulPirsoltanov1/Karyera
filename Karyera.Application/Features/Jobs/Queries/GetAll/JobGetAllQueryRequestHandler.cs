using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Jobs.Queries
{
    public class JobGetAllQueryRequestHandler : IRequestHandler<JobGetAllQueryRequest, List<Job>>
    {
        private readonly IDbContextManager<Job> _dbContextManager;

        public JobGetAllQueryRequestHandler(IDbContextManager<Job> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }
        public async Task<List<Job>> Handle(JobGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming _dbContextManager has a method to get all jobs
                var allJobs = await _dbContextManager.Table.ToListAsync();

                // Implement pagination
                var pagedJobs = allJobs
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToList();

                return pagedJobs;
            }
            catch (Exception)
            {

                return new List<Job>();
            }
        }
    }
}
