using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/contact")]
    public class ContactApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public ContactApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] TWOrFWContactUs model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Please fill all required fields."
                });
            }

            try
            {
                model.CreatedDateTime = DateTime.Now;

                _context.TWOrFWContactUs.Add(model);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Your message has been sent successfully."
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Something went wrong. Please try again."
                });
            }
        }
    }
}