using Karyera.Domain.BaseEntities;

namespace Karyera.Domain.Entities
{
    public class Company : BaseEntity
    {
        // Şirkətin xüsusiyyətləri
        public string? Name { get; set; }
        public int? AppUserId{ get; set; }
        public AppUser? AppUser { get; set; }
        public string? Industry { get; set; } // Sənaye
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? ContactEmail { get; set; }
        public string? Website { get; set; }
    }

}
