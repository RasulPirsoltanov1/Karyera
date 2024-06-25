using AutoMapper;
using Karyera.Application.DTOs.AppUser;
using Karyera.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.Areas.Profile.Controllers
{
    [Area("Profile")]
    
    public class ProfileController : Controller
    {
        UserManager<AppUser> _userManager;
        IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return BadRequest();
            }
            return View(_mapper.Map<AppUserDTO>(user));
        }
    }
}
