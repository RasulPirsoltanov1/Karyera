using Karyera.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.DTOs.AppUser
{
    public class AppUserDTO
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Heading { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public Company? Company { get; set; }
        public string? SurName { get; set; }
        public bool IsCompany { get; set; }
        public string? Address { get; set; }
        public string? About { get; set; }
        public string? ResumeUrl { get; set; } // CV məlumatı
        public List<string>? Skills { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<EducationInfo>? Education { get; set; }
        public int? ExperienceId { get; set; }
        public List<ExperienceInfo>? Experience { get; set; }
        public string? LinkedInProfile { get; set; }
        public List<string>? Roles { get; set; }
        public bool IsActive { get; set; }
    }
}
