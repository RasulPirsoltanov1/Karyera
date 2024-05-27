using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Jobs.Commands.Create
{
    public class JobCreateCommandRequestHandler : IRequestHandler<JobCreateCommandRequest, bool>
    {
        IDbContextManager<Job> _jobContextManager;
        IDbContextManager<Category> _catgeoryContextManager;

        public JobCreateCommandRequestHandler(IDbContextManager<Job> dbContextManager, IDbContextManager<Category> catgeoryContextManager)
        {
            _jobContextManager = dbContextManager;
            _catgeoryContextManager = catgeoryContextManager;
        }

        public async Task<bool> Handle(JobCreateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newJob = new Job
                {
                    Company = request.Company,
                    ContactEmail = request.ContactEmail,
                    Description = request.Description,
                    IsRemote = request.IsRemote,
                    Location = request.Location,
                    EndDate = request.EndDate,
                    Salary = request.Salary ?? 0,
                    Requirements = request.Requirements,
                    Title = request.Title,
                };
                var category = await _catgeoryContextManager.Table.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
                if (category != null)
                {
                    newJob.Category = category;
                    newJob.CategoryId = category.Id;
                }
                await _jobContextManager.Table.AddAsync(newJob);
                var x = await _jobContextManager.SaveChangesAsync();
                if (x > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
