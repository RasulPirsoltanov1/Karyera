using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Karyera.Application.Features.Auth.Users.Login
{
    public class UserLoginCommandRequestHandler : IRequestHandler<UserLoginCommandRequest, SignInResult>
    {
        SignInManager<AppUser> _signInManager;
        UserManager<AppUser> _userManager;

        public UserLoginCommandRequestHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null) { return null; }
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
