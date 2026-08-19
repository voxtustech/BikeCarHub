using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Authorize]
    [Route("api/reviews")]
    public class ReviewApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewApiController(
            TwoWheelerDB context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // POST: api/reviews
        [HttpPost]
        public async Task<IActionResult> AddReview(
            [FromBody] ReviewRequest request)
        {
            if (request == null)
            {
                return BadRequest(new
                {
                    message = "Invalid review data."
                });
            }


            // Validate rating
            if (request.Rating < 1 || request.Rating > 5)
            {
                return BadRequest(new
                {
                    message = "Rating must be between 1 and 5."
                });
            }


            // Validate review text
            if (string.IsNullOrWhiteSpace(request.ReviewText) ||
                request.ReviewText.Trim().Length < 10 ||
                request.ReviewText.Trim().Length > 1000)
            {
                return BadRequest(new
                {
                    message =
                        "Review must be between 10 and 1000 characters."
                });
            }


            // Check logged-in user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Please login to submit a review."
                });
            }


            // Check whether bike exists
            var bike = await _context.Twowheelers
                .FirstOrDefaultAsync(x =>
                    x.TwoWheelerId == request.TwoWheelerId);

            if (bike == null)
            {
                return NotFound(new
                {
                    message = "Bike not found."
                });
            }


            // Check existing review
            var existingReview =
                await _context.Reviews.FirstOrDefaultAsync(r =>
                    r.UserID == user.Id &&
                    r.TwoWheelerID == request.TwoWheelerId);


            if (existingReview != null)
            {
                // Update existing review

                existingReview.Rating = request.Rating;

                existingReview.ReviewText =
                    request.ReviewText.Trim();

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Review updated successfully.",
                    isUpdated = true
                });
            }


            // Create new review

            var review = new Review
            {
                TwoWheelerID = request.TwoWheelerId,
                UserID = user.Id,
                Username = user.UserName,
                Rating = request.Rating,
                ReviewText = request.ReviewText.Trim(),
                CreatedAt = DateTime.Now
            };


            _context.Reviews.Add(review);

            await _context.SaveChangesAsync();


            return Ok(new
            {
                success = true,
                message = "Review submitted successfully.",
                isUpdated = false
            });
        }

        // GET: api/reviews/my
        [HttpGet("my")]
        public async Task<IActionResult> GetMyReviews()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "User is not logged in."
                });
            }

            var reviews = await _context.Reviews
                .Where(r => r.UserID == user.Id)
                .Include(r => r.TwoWheeler)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new
                {
                    reviewId = r.ReviewID,

                    twoWheelerId = r.TwoWheelerID,

                    bikeName = r.TwoWheeler != null
                        ? r.TwoWheeler.TwoWheelerName
                        : "",

                    brand = r.TwoWheeler != null
                        ? r.TwoWheeler.Brand
                        : "",

                    image = r.TwoWheeler != null
                        ? r.TwoWheeler.TWImage
                        : null,

                    rating = r.Rating,

                    reviewText = r.ReviewText,

                    createdAt = r.CreatedAt
                })
                .ToListAsync();

            return Ok(reviews);
        }
        // PUT: api/reviews/22
        [HttpPut("{reviewId:int}")]
        public async Task<IActionResult> EditReview(
            int reviewId,
            [FromBody] ReviewRequest request)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Please login."
                });
            }

            if (request.Rating < 1 || request.Rating > 5)
            {
                return BadRequest(new
                {
                    message = "Rating must be between 1 and 5."
                });
            }

            if (string.IsNullOrWhiteSpace(request.ReviewText) ||
                request.ReviewText.Trim().Length < 10 ||
                request.ReviewText.Trim().Length > 1000)
            {
                return BadRequest(new
                {
                    message = "Review must be between 10 and 1000 characters."
                });
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(r =>
                    r.ReviewID == reviewId &&
                    r.UserID == user.Id);

            if (review == null)
            {
                return NotFound(new
                {
                    message = "Review not found."
                });
            }

            review.Rating = request.Rating;
            review.ReviewText = request.ReviewText.Trim();

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Review updated successfully."
            });
        }
        // DELETE: api/reviews/22
        [HttpDelete("{reviewId:int}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Please login."
                });
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(r =>
                    r.ReviewID == reviewId &&
                    r.UserID == user.Id);

            if (review == null)
            {
                return NotFound(new
                {
                    message = "Review not found."
                });
            }

            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                success = true,
                message = "Review deleted successfully."
            });
        }
        // GET: api/reviews/bike/312
        [AllowAnonymous]
        [HttpGet("bike/{twoWheelerId:int}")]
        public async Task<IActionResult> GetBikeReviews(
            int twoWheelerId)
        {
            var reviews = await _context.Reviews
                .Where(r =>
                    r.TwoWheelerID == twoWheelerId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new
                {
                    reviewId = r.ReviewID,
                    username = r.Username,
                    rating = r.Rating,
                    reviewText = r.ReviewText,
                    createdAt = r.CreatedAt
                })
                .ToListAsync();


            var averageRating = reviews.Any()
                ? reviews.Average(r => r.rating)
                : 0;


            return Ok(new
            {
                averageRating =
                    Math.Round(averageRating, 1),

                reviewCount =
                    reviews.Count,

                reviews
            });
        }
    }


    public class ReviewRequest
    {
        public int TwoWheelerId { get; set; }

        public int Rating { get; set; }

        public string ReviewText { get; set; }
            = string.Empty;
    }
}
