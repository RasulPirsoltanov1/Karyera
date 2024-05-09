﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        // İş axtaran şəxsin xüsusiyyətləri
        public string? Name { get; set; }
        public Company? Company { get; set; } = new Company();
        public string? SurName { get; set; }
        public string? Address { get; set; }
        public string? Resume { get; set; } // CV məlumatı
        public List<string>? Skills { get; set; } = new List<string>();// Bacarıqlar
        public DateTime? DateOfBirth { get; set; }
        public List<EducationInfo>? Education { get; set; } = new List<EducationInfo>();// Təhsil məlumatı
        public int? ExperienceId { get; set; }
        public List<ExperienceInfo>? Experience { get; set; } = new List<ExperienceInfo>();// İş təcrübəsi məlumatı
        public string? LinkedInProfile { get; set; } // LinkedIn profil linki
    }

}
