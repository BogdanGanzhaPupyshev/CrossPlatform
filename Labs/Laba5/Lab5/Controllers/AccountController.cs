using Lab5.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace Lab5.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            if(!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return new SignOutResult(
                new[]
                {
                    OktaDefaults.MvcAuthenticationScheme,
                    CookieAuthenticationDefaults.AuthenticationScheme
                },
                new Microsoft.AspNetCore.Authentication.AuthenticationProperties() { RedirectUri = "/Home/"}
                );
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View(new UserProfileModel()
            {
                FirstName = HttpContext.User.Claims.Where(x => x.Type == "given_name").FirstOrDefault()?.Value,
                LastName = HttpContext.User.Claims.Where(x => x.Type == "family_name").FirstOrDefault()?.Value,
                PrimaryEmail = HttpContext.User.Claims.Where(x => x.Type == "email").FirstOrDefault()?.Value,
                PrimaryPhone = HttpContext.User.Claims.Where(x => x.Type == "phone_number").FirstOrDefault()?.Value,
                UserName = HttpContext.User.Claims.Where(x => x.Type == "name").FirstOrDefault()?.Value
            });
        }
    }
}
