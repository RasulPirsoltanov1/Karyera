using Karyera.Application.Features.Users.Commands.SetStatus;
using Karyera.Application.Features.Users.Queries.GetAll;
using Karyera.Application.Features.Users.Queries.GetById;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IMediator _mediator;
        UserManager<AppUser> _userManager;
        RoleManager<AppRole> _roleManager;
        public UserController(IMediator mediator, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _mediator = mediator;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            ViewBag.PageNumber = pageNumber;
            ViewBag.TotalJobs = _userManager.Users.Count();
            var result = await _mediator.Send(new UserGetAllQueryRequest
            {
                PageNumber = pageNumber ?? 1,
            });
            return View(result);
        }


        public async Task<IActionResult> Edit(string email)
        {
            ViewBag.AllRoles = _roleManager.Roles.Select(r => r.Name).ToList();
            var user = await _mediator.Send(new AppUserGetByEmailQueryRequest
            {
                Email = email
            });
            if (user == null)
            {
                return BadRequest();
            }
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(int userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var existingRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, existingRoles);
                foreach (var item in roles)
                {
                    if (!(await _userManager.IsInRoleAsync(user, item)))
                    {
                        await _userManager.AddToRoleAsync(user, item);
                    }
                }

                return RedirectToAction("Edit", new { email = user.Email });
            }

            return BadRequest();
        }




        [HttpPost]
        public async Task<IActionResult> SetStatus([FromBody] AppUserSetStatusCommandRequest appUserSetStatusCommandRequest)
        {
            var result = await _mediator.Send(appUserSetStatusCommandRequest);
            return Json(result);
        }
    }
}
