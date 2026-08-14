using Azure.Core;
using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly TwoWheelerDB _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewController(
            TwoWheelerDB context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult MyReviews()
        {
            var user = _userManager.GetUserAsync(User).Result;

            var reviews = _context.Reviews
                .Include(r => r.TwoWheeler)
                .Where(r => r.UserID == user.Id)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            return View(reviews);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReview(
        int twoWheelerId,
        int rating,
        string reviewText)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (reviewText.Length < 10 || reviewText.Length > 1000)
            {
                TempData["ReviewError"] =
                    "Review must be between 10 and 1000 characters.";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            var existingReview = _context.Reviews.FirstOrDefault(r =>
            r.UserID == user.Id &&
            r.TwoWheelerID == twoWheelerId);

            if (existingReview != null)
            {
                existingReview.Rating = rating;
                existingReview.ReviewText = reviewText;
                //existingReview.CreatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                TempData["ReviewSuccess"] =
                    "Review updated successfully.";

                return Redirect(Request.Headers["Referer"].ToString());
            }
            Review review = new Review
            {
                TwoWheelerID = twoWheelerId,
                UserID = user.Id,
                Username = user.UserName,
                Rating = rating,
                ReviewText = reviewText,
                CreatedAt = DateTime.Now
            };

            _context.Reviews.Add(review);

            await _context.SaveChangesAsync();

            TempData["ReviewSuccess"] =
                "Review submitted successfully.";

            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            var review = _context.Reviews
                .FirstOrDefault(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            if (review.UserID != user.Id)
            {
                return Unauthorized();
            }

            _context.Reviews.Remove(review);

            await _context.SaveChangesAsync();

            TempData["ReviewSuccess"] =
                "Review deleted successfully.";

            return RedirectToAction("MyReviews");
        }
        [HttpGet]
        [Authorize]
        public IActionResult EditReview(int id)
        {
            var review = _context.Reviews
                .Include(r => r.TwoWheeler)
                .FirstOrDefault(r => r.ReviewID == id);

            if (review == null)
            {
                return NotFound();
            }

            var brand = review.TwoWheeler?.Brand?
                .ToLower()
                .Replace(" ", "-");

            var bikeSlug = review.TwoWheeler?.TwoWheelerName?
                .ToLower()
                .Replace(" ", "-");

            return Redirect($"/{brand}/{bikeSlug}?editReview=true");
        }
    }
}