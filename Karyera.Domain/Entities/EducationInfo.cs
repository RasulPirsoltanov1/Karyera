using Karyera.Domain.BaseEntities;
using Karyera.Domain.Enums;

namespace Karyera.Domain.Entities
{
    public class EducationInfo : BaseEntity
    {
        public AppUser? AppUser { get; set; }
        public int AppUserId { get; set; } // İş axtaranın Id-si
        public DegreeType? Degree { get; set; }
        public string? School { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
