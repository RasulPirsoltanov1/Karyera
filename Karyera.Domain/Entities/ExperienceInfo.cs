using Karyera.Domain.BaseEntities;

namespace Karyera.Domain.Entities
{
    public class ExperienceInfo : BaseEntity
    {
        public int? JobSeekerId { get; set; } // İş axtaranın Id-si
        public string? Position { get; set; }
        public string? Company { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

}
