using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;

namespace Karyera.Application.Features.Categories.Commands.Create
{
    public class CategoryCreateCommandRequestHandler : IRequestHandler<CategoryCreateCommandRequest, bool>
    {

        IDbContextManager<Category> _dbContextManager;

        public CategoryCreateCommandRequestHandler(IDbContextManager<Category> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<bool> Handle(CategoryCreateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var affectedRows = await _dbContextManager.Table.AddAsync(new Category
                {
                    Name = request.Name,
                });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
