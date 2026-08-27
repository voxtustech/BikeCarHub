using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/latest-news")]
    public class NewsApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public NewsApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        // GET: api/news
        [HttpGet]
        public async Task<IActionResult> GetNews()
        {
            var news = await _context.TWLatestNews
                .OrderByDescending(x => x.Date)
                .Take(10)
                .Select(x => new
                {
                    id = x.TWLatestNewsId,
                    heading = x.NewsHeading,
                    summary = x.NewsSummary,
                    image = x.ImageURL,
                    date = x.Date,
                    brand = x.BrandName,
                    imageFolder = x.ImageFolderURL,
                    isTwoWheeler = x.IsTwoWheeler
                })
                .ToListAsync();

            return Ok(news);
        }
    }
}