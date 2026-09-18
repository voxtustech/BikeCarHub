using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers
{
    [ApiController]
    [Route("api/hero")]
    public class HeroApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public HeroApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroSlides()
        {
            var slides = await _context.HeroSlides
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new
                {
                    id = x.HeroSlideId,
                    title = x.Title,
                    subtitle = x.Subtitle,
                    image = x.ImageURL,
                    badge = x.Badge,
                    featured = x.Featured,
                    price = x.Price,
                    displayOrder = x.DisplayOrder
                })
                .ToListAsync();

            return Ok(slides);
        }
    }
}