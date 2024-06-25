using AutoMapper;
using Karyera.Application.DTOs.AppUser;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Karyera.Application.Features.Users.Queries.GetById
{
    public class AppUserGetByEmailQueryRequestHandler : IRequestHandler<AppUserGetByEmailQueryRequest, AppUserDTO>
    {
        UserManager<AppUser> _userManager;
        IMapper _mapper;

        public AppUserGetByEmailQueryRequestHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AppUserDTO> Handle(AppUserGetByEmailQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    return null;
                }

                var dto = _mapper.Map<AppUserDTO>(user);
                dto.Roles = await _userManager.GetRolesAsync(user) as List<string>;
                return dto;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
