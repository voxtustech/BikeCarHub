using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars_Bikes.Data;

namespace Cars_Bikes.Controllers
{
    public class AdminLogin : Controller
    {
        private readonly TwoWheelerDB _context;
        public AdminLogin(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.TWVarients = _context.TWVarients
        .Select(v => new SelectListItem
        {
            Value = v.TWVarientId.ToString(),
            Text = v.TWName
        }).ToList();
            return View();
        }
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Hardcoded username and password
            if (username == "admin" && password == "admin123")
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

                var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");

                var authProperties = new AuthenticationProperties
                {
                    // Optional settings
                };

                await HttpContext.SignInAsync("MyCookieAuth",
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                //return RedirectToAction("Create", "TWBrands");
                return RedirectToAction("Index", "AdminLogin");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }
        [Authorize]
        public IActionResult Form()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login", "AdminLogin");
        }
        public IActionResult LoadCreateForms()
        {
            return PartialView("Partials/_CreateForms");
        }

        public IActionResult LoadUpdateForms()
        {
            var variants = _context.TWVarients
                .Select(v => new SelectListItem
                {
                    Value = v.TWVarientId.ToString(),
                    Text = v.TWName
                }).ToList();

            ViewBag.Variants = variants;
            return PartialView("Partials/_UpdateForms");
        }
    }
}
