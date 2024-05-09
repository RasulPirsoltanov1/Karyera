using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Categories.Queries.GetAll
{
    public class CategoryGetAllQueryRequestHnadler : IRequestHandler<CategoryGetAllQueryRequest, List<Category>>
    {
        IDbContextManager<Category> _dbContextManager;

        public CategoryGetAllQueryRequestHnadler(IDbContextManager<Category> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<List<Category>> Handle(CategoryGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _dbContextManager.Table.ToListAsync();
                return categories;
            }
            catch (Exception ex)
            {
                return new List<Category>();
            }
        }
    }
}
