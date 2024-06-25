using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Karyera.Application.Features.Auth.Users.Company
{
    public class CompanyCreateCommandRequestHandler : IRequestHandler<CompanyCreateCommandRequest, IdentityResult>
    {
        UserManager<AppUser> _userManager;

        public CompanyCreateCommandRequestHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(CompanyCreateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new AppUser
                {
                    UserName = request.CompanyEmail,
                    Name = request.CompanyName,
                    Email = request.CompanyEmail,
                    IsCompany = true,
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
