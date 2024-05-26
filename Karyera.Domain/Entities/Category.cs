using Karyera.Domain.BaseEntities;

namespace Karyera.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category>? SubCategories { get; set; }
        public Category()
        {
            SubCategories = new List<Category>();
        }
    }
}
