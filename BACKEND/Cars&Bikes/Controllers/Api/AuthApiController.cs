using System;
using System.Runtime.InteropServices;
using Azure.Core;
using Cars_Bikes.Models;
using Cars_Bikes.Services;
using Cars_Bikes.ViewModels;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/auth")]
    public class AuthApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EmailService _emailService;

        public AuthApiController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        
        // ==========================================
        // LOGIN
        // ==========================================

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user =
                await _userManager.FindByEmailAsync(model.EmailOrPhone);

            if (user == null)
            {
                user =
                    await _userManager.FindByNameAsync(model.EmailOrPhone);
            }

            if (user == null)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Account not found."
                });
            }

            var result =
                await _signInManager.PasswordSignInAsync(
                    user.UserName,
                    model.Password,
                    model.RememberMe,
                    false);

            if (!result.Succeeded)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Incorrect password."
                });
            }

            return Ok(new
            {
                success = true,
                user = new
                {
                    fullName = user.FullName,
                    userName = user.UserName,
                    email = user.Email
                }
            });
        }

        // ==========================================
        // CURRENT USER
        // ==========================================

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Unauthorized();
            }

            var user =
                await _userManager.GetUserAsync(User);

            return Ok(new
            {
                fullName = user!.FullName,
                userName = user.UserName,
                email = user.Email
            });
        }

        // ==========================================
        // LOGOUT
        // ==========================================

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return Ok(new
            {
                success = true
            });
        }

        // ==========================================
        // REGISTER
        // ==========================================

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result =
                await _userManager.CreateAsync(
                    user,
                    model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = result.Errors.Select(x => x.Description)
                });
            }

            await _signInManager.SignInAsync(
                user,
                false);

            return Ok(new
            {
                success = true,
                user = new
                {
                    user.FullName,
                    user.UserName,
                    user.Email
                }
            });
        }

        // ==========================================
        // FORGOT PASSWORD
        // ==========================================

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(
    [FromBody] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user =
                await _userManager.FindByEmailAsync(
                    model.EmailOrUsername);

            if (user == null)
            {
                user =
                    await _userManager.FindByNameAsync(
                        model.EmailOrUsername);
            }

            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Account not found."
                });
            }

            var token =
                await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink =
    $"https://localhost:44473/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(user.Email)}";

            var body =
        $@"
<h2>Reset Password</h2>

<p>
Click below to reset your password.
</p>

<a href=""{resetLink}"">
Reset Password
</a>";

            await _emailService.SendEmailAsync(
                user.Email,
                "Reset Password",
                body);


            return Ok(new
            {
                success = true,
                message = "Password reset email sent."
            });
        }

        // ==========================================
        // RESET PASSWORD
        // ==========================================

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(
            [FromBody] ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user =
                await _userManager.FindByEmailAsync(
                    model.Email);

            if (user == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "User not found."
                });
            }

            var result =
                await _userManager.ResetPasswordAsync(
                    user,
                    model.Token,
                    model.NewPassword);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    success = false,
                    errors = result.Errors.Select(x => x.Description)
                });
            }

            return Ok(new
            {
                success = true,
                message = "Password reset successfully."
            });
        }
    }
}