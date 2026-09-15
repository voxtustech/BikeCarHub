using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers
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

        // POST: api/contact
        // Contact Us form
        [HttpPost]
        public async Task<IActionResult> SendContactMessage(
            [FromBody] ContactRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Please provide valid information."
                });
            }

            var contact = new TWOrFWContactUs
            {
                Name = request.Name.Trim(),
                PhoneNo = request.PhoneNo?.Trim(),
                Email = request.Email.Trim(),
                Message = request.Message.Trim(),
                FormType = "ContactUs",
                CreatedDateTime = DateTime.Now
            };

            _context.TWOrFWContactUs.Add(contact);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Your message has been submitted successfully."
            });
        }


        // POST: api/contact/question
        // Ask a Question form
        [HttpPost("question")]
        public async Task<IActionResult> SubmitQuestion(
            [FromBody] QuestionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Please provide valid information."
                });
            }

            var question = new TWOrFWContactUs
            {
                Name = request.Name.Trim(),
                PhoneNo = null,
                Email = request.Email.Trim(),
                Message = request.Question.Trim(),
                FormType = "AskQuestion",
                CreatedDateTime = DateTime.Now
            };

            _context.TWOrFWContactUs.Add(question);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Your question has been submitted successfully."
            });
        }
    }


    // Contact Us request
    public class ContactRequest
    {
        public string Name { get; set; }

        public string? PhoneNo { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }


    // Ask Question request
    public class QuestionRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Question { get; set; }
    }
}