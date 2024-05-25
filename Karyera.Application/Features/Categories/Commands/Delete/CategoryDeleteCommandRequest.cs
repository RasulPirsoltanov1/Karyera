using Karyera.Application.Abstractions;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Categories.Commands.Delete
{
    public class CategoryDeleteCommandRequest:IRequest<bool>
    {
        public int CategoryId { get; set; }
    }
    public class CategoryDeleteCommandRequestHandler : IRequestHandler<CategoryDeleteCommandRequest,bool>
    {
        IDbContextManager<Category> _dbContextManager;

        public CategoryDeleteCommandRequestHandler(IDbContextManager<Category> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<bool> Handle(CategoryDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var dbCategory = await _dbContextManager.Table.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
                if (dbCategory == null)
                {
                    return false;
                }
                var result = _dbContextManager.Table.Remove(dbCategory);
                await _dbContextManager.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
