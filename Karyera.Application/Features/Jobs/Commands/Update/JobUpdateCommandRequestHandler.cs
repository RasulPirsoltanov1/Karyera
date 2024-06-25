using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Jobs.Commands.Update
{
    public class JobUpdateCommandRequestHandler : IRequestHandler<JobUpdateCommandRequest, bool>
    {
        IDbContextManager<Job> _jobDbContextManager;
        IDbContextManager<Category> _categoryDbContextManager;

        public JobUpdateCommandRequestHandler(IDbContextManager<Job> dbContextManager, IDbContextManager<Category> categoryDbContextManager)
        {
            _jobDbContextManager = dbContextManager;
            _categoryDbContextManager = categoryDbContextManager;
        }

        public async Task<bool> Handle(JobUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var existingJob = await _jobDbContextManager.Table.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (existingJob == null)
                {
                    return false;
                }
                existingJob.Requirements = request.Requirements;
                existingJob.Salary = request.Salary;
                existingJob.Location = request.Location;
                existingJob.EndDate = request.EndDate;
                existingJob.Description = request.Description;
                existingJob.Company = request.Company;
                existingJob.ContactEmail = request.ContactEmail;
                existingJob.Title = request.Title;
                if (request.CategoryId != null)
                {
                    var category = await _categoryDbContextManager.Table.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
                    if (category != null)
                    {
                        existingJob.Category = category;
                    }
                }
                var result = await _categoryDbContextManager.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
