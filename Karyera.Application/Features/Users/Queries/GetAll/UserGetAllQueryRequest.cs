using Karyera.Application.Abstractions;
using Karyera.Application.DTOs.AppUser;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application.Features.Users.Queries.GetAll
{
    public class UserGetAllQueryRequest : IRequest<List<AppUserDTO>>
    {
        public int PageNumber { get; set; } = 1; // Default to first page
        public int PageSize { get; set; } = 10; // Default to 10 items per page
    }
}
