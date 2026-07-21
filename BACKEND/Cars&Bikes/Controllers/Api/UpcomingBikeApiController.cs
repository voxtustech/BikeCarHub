using System.Runtime.InteropServices;
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
                    slug = "triumphtigersport800",
                    image = x.ImageURL,
                    date = x.ExpectedLaunchDate,
                    brand = x.BrandName
                })
                .ToListAsync();

            return Ok(bikes);
        }
    }
}