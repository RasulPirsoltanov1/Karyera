using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Karyera.Application.Features.Users.Commands.SetStatus
{
    public class AppUserSetStatusCommandRequestHandler : IRequestHandler<AppUserSetStatusCommandRequest, bool>
    {
        UserManager<AppUser> _userManager;

        public AppUserSetStatusCommandRequestHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(AppUserSetStatusCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                {
                    return false;
                }
                user.IsActive = !user.IsActive;
                await _userManager.UpdateAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
