using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Categories.Queries.GetAll
{
    public class CategoryGetByIdRequestHandler : IRequestHandler<CategoryGetByIdRequest, Category>
    {
        IDbContextManager<Category> _dbContextManager;

        public CategoryGetByIdRequestHandler(IDbContextManager<Category> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<Category> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _dbContextManager.Table.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (category == null)
                {
                    return new Category();
                }
                return category;
            }
            catch (Exception)
            {
                return new Category();
            }
        }
    }
}
