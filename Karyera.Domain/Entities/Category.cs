using Karyera.Domain.BaseEntities;

namespace Karyera.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int? MainCategory { get; set; }
        public List<Category>? Categories { get; set; }
        public Category()
        {
            Categories = new List<Category>();
        }
    }
}
