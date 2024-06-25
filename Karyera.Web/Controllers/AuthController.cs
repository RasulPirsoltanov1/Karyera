using Azure.Core;
using Karyera.Application.Features.Auth.Users.Create;
using Karyera.Application.Features.Auth.Users.Login;
using Karyera.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Karyera.Web.Controllers
{
    public class AuthController : Controller
    {
        IMediator _mediator;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public AuthController(IMediator mediator, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mediator = mediator;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserCreateCommandRequest userCreateCommandRequest)
        {
            if (!ModelState.IsValid)
                return View(userCreateCommandRequest);
            var result = await _mediator.Send(userCreateCommandRequest);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("All", err.Description);
            }
            return View(userCreateCommandRequest);
        }

        public IActionResult Login() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginCommandRequest userLoginCommandRequest)
        {
            //var result = await _mediator.Send(userLoginCommandRequest);
            //if (!result.Succeeded)
            //{
            //    return View(userLoginCommandRequest);
            //}

            try
            {
                var user = await _userManager.FindByEmailAsync(userLoginCommandRequest.Email);
                if (user == null) { return null; }
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginCommandRequest.Password, false);
                if (result.Succeeded)
                {
                    await _signInManager.PasswordSignInAsync(user, userLoginCommandRequest.Password, true, false);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index","Home");
        }
    }
}
