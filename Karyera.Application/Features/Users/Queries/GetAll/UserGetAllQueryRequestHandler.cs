using AutoMapper;
using Karyera.Application.DTOs.AppUser;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Karyera.Application.Features.Users.Queries.GetAll
{
    public class UserGetAllQueryRequestHandler : IRequestHandler<UserGetAllQueryRequest, List<AppUserDTO>>
    {
        UserManager<AppUser> _userManager;
        IMapper _mapper;

        public UserGetAllQueryRequestHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<AppUserDTO>> Handle(UserGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userManager.Users.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync(cancellationToken);

                var userDtos = new List<AppUserDTO>();

                foreach (var user in users)
                {
                    var userDto = _mapper.Map<AppUserDTO>(user);
                    var roles = await _userManager.GetRolesAsync(user);
                    userDto.Roles = roles.ToList();
                    userDtos.Add(userDto);
                }

                return userDtos;
            }
            catch (Exception)
            {
                return new List<AppUserDTO>();
            }

        }
    }
}
