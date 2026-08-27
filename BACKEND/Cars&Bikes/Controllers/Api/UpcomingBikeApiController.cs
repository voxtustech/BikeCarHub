using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/upcoming-bikes")]
    public class UpcomingBikeApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public UpcomingBikeApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetUpcomingBikes()
        //{
        //    var bikes = await _context.UpcomingBikes
        //        .OrderBy(x => x.FilterLaunchDate)
        //        .Take(100)
        //        .Select(x => new
        //        {
        //            id = x.UpcomingBikeId,
        //            title = x.UpcomingBikeName,


        //           slug = x.ImageURL,

        //            image = x.ImageFolderURL,
        //            date = x.ExpectedLaunchDate,
        //            brand = x.BrandName
        //        })
        //        .ToListAsync();

        //    return Ok(bikes);
        //}
        [HttpGet]
        public async Task<IActionResult> GetUpcomingBikes()
        {
            var bikes = await _context.UpcomingBikes
                .OrderBy(x => x.FilterLaunchDate)
                .Take(10)
                .Select(x => new
                {
                    id = x.UpcomingBikeId,

                    title = x.UpcomingBikeName,

                    slug = x.UpcomingBikeName
                        .ToLower()
                        .Replace(" ", "-"),

                    image = x.ImageFolderURL,

                    date = x.ExpectedLaunchDate,

                    brand = x.BrandName
                })
                .ToListAsync();

            return Ok(bikes);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetUpcomingBike(string slug)
        {
            slug = slug.ToLower();

            var bike = await _context.UpcomingBikes
                .FirstOrDefaultAsync(x =>
                    x.UpcomingBikeName
                        .ToLower()
                        .Replace(" ", "-") == slug
                );

            if (bike == null)
            {
                return NotFound(new
                {
                    message = "Upcoming bike article not found."
                });
            }

            return Ok(new
            {
                id = bike.UpcomingBikeId,

                title = bike.UpcomingBikeName,

                slug = bike.UpcomingBikeName
                    .ToLower()
                    .Replace(" ", "-"),

                image = bike.ImageFolderURL,

                date = bike.ExpectedLaunchDate,

                brand = bike.BrandName,

                details = bike.UpcomingBikeDetails
            });
        }
    }
}