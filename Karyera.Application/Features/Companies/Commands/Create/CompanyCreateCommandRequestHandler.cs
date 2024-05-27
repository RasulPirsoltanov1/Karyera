using FileUploadExtensionForIFormFile;
using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;

namespace Karyera.Application.Features.Companies.Commands.Create
{
    public class CompanyCreateCommandRequestHandler : IRequestHandler<CompanyCreateCommandRequest, bool>
    {
        IDbContextManager<Company> _dbContextManager;

        public CompanyCreateCommandRequestHandler(IDbContextManager<Company> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<bool> Handle(CompanyCreateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newCompany = new Company
                {
                    ContactEmail = request.ContactEmail,
                    Description = request.Description,
                    Industry = request.Industry,
                    Location = request.Location,
                    Website = request.Website,
                    Name = request.Name,
                };
                if (request.Image != null)
                {
                    var path = await request.Image.UploadFileToAsync("company");
                    newCompany.ImageUrl = path;
                }
                await _dbContextManager.Table.AddAsync(newCompany);
                var result = await _dbContextManager.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
