using FileUploadExtensionForIFormFile;
using Karyera.Application.Abstractions;
using Karyera.Application.Features.Categories.Commands.Create;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Karyera.Application.Features.Categories.Commands.Update
{
    public class CategoryUpdateCommandRequestHandler : IRequestHandler<CategoryUpdateCommandRequest, bool>
    {

        IDbContextManager<Category> _dbContextManager;

        public CategoryUpdateCommandRequestHandler(IDbContextManager<Category> dbContextManager)
        {
            _dbContextManager = dbContextManager;
        }

        public async Task<bool> Handle(CategoryUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Tapılan kateqoriyanın məlumatlarını bazadan tapırıq
                var existingCategory = await _dbContextManager.Table.FindAsync(request.Id);

                // Əgər kateqoriya tapılıbsa, onun məlumatlarını yeniləyirik
                if (existingCategory != null)
                {
                    // Adı yeniləyirik
                    existingCategory.Name = request.Name;

                    // Şəkil yüklənibsə, onu dəyişdiririk
                    if (request.Image != null)
                    {
                        await IFormFileExtension.DeleteFileAsync(existingCategory.ImageUrl??"");
                        var path = await request.Image.UploadFileToAsync("category");
                        existingCategory.ImageUrl = path;
                    }

                    // Əgər alt kateqoriya varsa, onu əlavə edirik
                    if (request.SubCategoryId != null && request.SubCategoryId > 0)
                    {
                        var subcategory = await _dbContextManager.Table.FindAsync(request.SubCategoryId);
                        if (subcategory != null)
                        {
                            existingCategory.MainCategory = request.SubCategoryId;
                            subcategory.Categories.Add(existingCategory);
                        }
                    }

                    // Yenilənmiş kateqoriyanı məlumat bazasına yazırıq
                    await _dbContextManager.SaveChangesAsync();
                    return true;
                }

                return false; // Əgər kateqoriya tapılmamışdırsa false qaytarırıq
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }
    }

}
