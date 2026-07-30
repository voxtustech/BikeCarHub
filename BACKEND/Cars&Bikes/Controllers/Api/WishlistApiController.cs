using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Authorize]
    [Route("api/wishlist")]
    public class WishlistApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishlistApiController(
            TwoWheelerDB context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("{bikeId}")]
        public async Task<IActionResult> Add(int bikeId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            bool exists = await _context.Wishlist.AnyAsync(x =>
                x.UserID == user.Id &&
                x.TwoWheelerID == bikeId);

            if (!exists)
            {
                _context.Wishlist.Add(new Wishlist
                {
                    UserID = user.Id,
                    Username = user.UserName,
                    TwoWheelerID = bikeId,
                    CreatedAt = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }

            return Ok(new
            {
                success = true,
                isWishlisted = true
            });
        }

        [HttpDelete("{bikeId}")]
        public async Task<IActionResult> Remove(int bikeId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var item = await _context.Wishlist.FirstOrDefaultAsync(x =>
                x.UserID == user.Id &&
                x.TwoWheelerID == bikeId);

            if (item != null)
            {
                _context.Wishlist.Remove(item);
                await _context.SaveChangesAsync();
            }

            return Ok(new
            {
                success = true,
                isWishlisted = false
            });
        }

        [HttpGet("check/{bikeId}")]
        public async Task<IActionResult> Check(int bikeId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Ok(new { isWishlisted = false });

            bool exists = await _context.Wishlist.AnyAsync(x =>
                x.UserID == user.Id &&
                x.TwoWheelerID == bikeId);

            return Ok(new
            {
                isWishlisted = exists
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetWishlist()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var wishlist = await _context.Wishlist
                .Include(x => x.TwoWheelers)
                .Where(x => x.UserID == user.Id)
                .ToListAsync();

            return Ok(wishlist);
        }
    }
}