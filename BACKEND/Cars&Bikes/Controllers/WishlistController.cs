using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private readonly TwoWheelerDB _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistController(
            TwoWheelerDB context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            //var userId = _userManager.GetUserId(User);
            var user =
    _userManager.GetUserAsync(User).Result;

            var userId = user.Id;
            var wishlist = _context.Wishlist
                .Include(w => w.TwoWheelers)
                .Where(w => w.UserID == userId)
                .ToList();

            return View(wishlist);
        }
        [HttpPost]
        public IActionResult AddToWishlist(int twoWheelerId)
        {
            //var userId = _userManager.GetUserId(User);
            var user =
    _userManager.GetUserAsync(User).Result;

            var userId = user.Id;
            //var user = _userManager.GetUserAsync(User).Result;
            var exists = _context.Wishlist.Any(w =>
                w.TwoWheelerID == twoWheelerId &&
                w.UserID == userId);

            if (!exists)
            {
                Wishlist wishlist = new Wishlist()
                {
                    TwoWheelerID = twoWheelerId,
                    UserID = userId,
                    Username = user.UserName,
                    CreatedAt = DateTime.Now
                };

                _context.Wishlist.Add(wishlist);
                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveFromWishlist(int twoWheelerId)
        {
            //var userId = _userManager.GetUserId(User);
            var user =
    _userManager.GetUserAsync(User).Result;

            var userId = user.Id;
            var item = _context.Wishlist.FirstOrDefault(w =>
                w.TwoWheelerID == twoWheelerId &&
                w.UserID == userId);

            if (item != null)
            {
                _context.Wishlist.Remove(item);
                _context.SaveChanges();
            }

            return Ok();
        }
        [HttpGet]
        public IActionResult GetWishlistCount()
        {
            //var userId = _userManager.GetUserId(User);
            var user =
    _userManager.GetUserAsync(User).Result;

            var userId = user.Id;
            //if (string.IsNullOrEmpty(userId))
            if (user == null)
            {
                return Json(0);
            }

            var count = _context.Wishlist
                .Count(w => w.UserID == userId);

            return Json(count);
        }
    }
}