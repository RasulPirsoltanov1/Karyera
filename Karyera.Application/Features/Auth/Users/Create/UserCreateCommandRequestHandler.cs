using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Karyera.Application.Features.Auth.Users.Create
{
    public class UserCreateCommandRequestHandler : IRequestHandler<UserCreateCommandRequest, IdentityResult>
    {
        UserManager<AppUser> _userManager;
        public UserCreateCommandRequestHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Handle(UserCreateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new AppUser
                {
                    UserName = request.Email,
                    Name = request.Name,
                    SurName = request.Surname,
                    Email = request.Email,
                    IsCompany = false,
                };
                var result = await _userManager.CreateAsync(newUser, request.Password);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
