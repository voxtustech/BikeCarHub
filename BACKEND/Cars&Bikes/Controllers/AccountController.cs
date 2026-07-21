//using Cars_Bikes.Data;
//using Google.Apis.Drive.v3.Data;
//using Microsoft.AspNetCore.Mvc;
//using Cars_Bikes.Models;

//namespace Cars_Bikes.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly TwoWheelerDB _context;

//        public AccountController(TwoWheelerDB context)
//        {
//            _context = context;
//        }
//            [HttpPost]
//            public IActionResult Login(string username)
//            {
//                if (!string.IsNullOrEmpty(username)) // Just checking if username is provided
//                {
//                    HttpContext.Session.SetString("Username", username);
//                    return RedirectToAction("Dashboard", "Home"); // Redirect to a different page
//                }

//                ViewBag.Error = "Please enter a username!";
//                return View();
//            }

//            public IActionResult Logout()
//            {
//                HttpContext.Session.Clear(); // Clear session when user logs out
//                return RedirectToAction("Login");
//            }
//        public IActionResult Dashboard()
//        {
//            if (HttpContext.Session.GetString("Username") == null)
//            {
//                return RedirectToAction("Login", "Account");
//            }
//            return View();
//        }
//        //[HttpPost]
//        //public ActionResult Login(string username, string password)
//        //{
//        //    if (Users.ContainsKey(username) && Users[username] == password)
//        //    {
//        //        Session["Username"] = username;
//        //        return Json(new { success = true });
//        //    }
//        //    return Json(new { success = false, message = "Invalid username or password" });
//        //}
//        //public ActionResult Logout()
//        //{
//        //    Session.Clear();
//        //    return RedirectToAction("Index", "Home");
//        //}
//    }
//}

//New
using Cars_Bikes.Models;
using Cars_Bikes.Services;
using Cars_Bikes.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using System;


namespace Cars_Bikes.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailService;

        public AccountController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        // ================= REGISTER =================

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    FullName = model.FullName,
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        // ================= LOGIN =================
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find user by email OR username
                var user = await _userManager.FindByEmailAsync(model.EmailOrPhone);

                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(model.EmailOrPhone);
                }

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        user.UserName,
                        model.Password,
                        model.RememberMe,
                        false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                //ModelState.AddModelError("", "Invalid login attempt");
                if (user == null)
                {
                    ModelState.AddModelError("",
                        "Account not found. Register now.");
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        user.UserName,
                        model.Password,
                        model.RememberMe,
                        false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Incorrect password.");
                }
            }

            return View(model);
        }
        //=============Forgot Password==============
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(
        ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid){
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.EmailOrUsername);

            if (user == null)
            {
                user = await _userManager.FindByNameAsync(model.EmailOrUsername);
            }

            if (user == null)
            {
                ViewBag.Error = "No account found with this email or username.";
                return View(model);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = Url.Action(
                "ResetPassword",
                "Account",
                new
                {
                    token,
                    email = user.Email
                },
                Request.Scheme);

                var body = $@"
                    <h2>Reset Your Password</h2>

                    <p>
                    Click below to reset password:
                    </p>

                    <a href='{resetLink}'>
                    Reset Password
                    </a>";

            await _emailService.SendEmailAsync(
                user.Email,
                "Reset Password",
                body);

            //ViewBag.Message = "Reset link has been sent to your email.";
            var emailParts = user.Email.Split('@');

            var hiddenEmail =
                emailParts[0].Substring(0, 2) +
                "***@" +
                emailParts[1];

            ViewBag.Message = $"Reset link has been sent to: {hiddenEmail}";

            return View(model);
        }
        //==================Reset Password==============
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(
    ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _userManager.ResetPasswordAsync(
                user,
                model.Token,
                model.NewPassword);

            if (result.Succeeded)
            {
                TempData["Success"] = "Password reset successful.";

                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
        // ================= LOGOUT =================

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        // ================= DASHBOARD =================

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}