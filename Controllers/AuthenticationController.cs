using HMS.Abstraction;
using HMS.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HMS.Data.ViewModels;

namespace HMS.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUsersService _userService;

        private readonly IConfigurationService _configurationService;
        public AuthenticationController(
            IUsersService userService,
            IConfigurationService configurationService)
        {
            _userService = userService;
            _configurationService = configurationService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            _userService.Register(user);

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {

            User? user = _userService.GetUser(model.EmailOrUserName, model.PassWord);

            if (user != null)
            {
                int expiryTimeFram = _configurationService.GetExpiryTimeframeInMinutes();

                List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.EmailOrUserName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Country, "Pakistan"),
                new Claim(ClaimTypes.Sid,user.UserId.ToString())

            };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = model.KeepLoggedIn,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(expiryTimeFram)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "User not found";

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Authentication");
        }


       
    }

}
