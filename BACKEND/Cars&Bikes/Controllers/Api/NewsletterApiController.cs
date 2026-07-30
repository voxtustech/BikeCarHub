using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/newsletter")]
    public class NewsletterApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public NewsletterApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        public class NewsletterRequest
        {
            public string Email { get; set; } = "";
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(
            [FromBody] NewsletterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Email is required."
                });
            }

            request.Email = request.Email.Trim();

            bool exists = await _context.NewsLetters
                .AnyAsync(x => x.Email == request.Email);

            if (exists)
            {
                return Ok(new
                {
                    success = true,
                    message = "You're already subscribed."
                });
            }

            _context.NewsLetters.Add(new NewsLetter
            {
                Email = request.Email
            });

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Subscribed successfully."
            });
        }
    }
}