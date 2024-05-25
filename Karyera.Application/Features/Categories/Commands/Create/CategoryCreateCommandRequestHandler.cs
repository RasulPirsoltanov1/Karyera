using FileUploadExtensionForIFormFile;
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
                Category category = new Category
                {
                    Name = request.Name,
                };
                if (request.Image != null)
                {
                    var path = await request.Image.UploadFileToAsync("category");
                    category.ImageUrl = path;
                }
                if (request.SubCategoryId != null && request.SubCategoryId > 0)
                {
                    var subcategory = await _dbContextManager.Table.FindAsync(request.SubCategoryId);
                    if (subcategory != null)
                    {
                        category.MainCategory = request.SubCategoryId;
                        await _dbContextManager.Table.AddAsync(category);
                        subcategory?.Categories?.Add(category);
                        await _dbContextManager.SaveChangesAsync();
                        return true;
                    }
                }

                var affectedRows = await _dbContextManager.Table.AddAsync(category);
                var results = await _dbContextManager.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
