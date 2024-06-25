using AutoMapper;
using Karyera.Application.DTOs.AppUser;
using Karyera.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Mapping
{
    public class MyMapping : Profile
    {
        public MyMapping()
        {
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
        }
    }
}
