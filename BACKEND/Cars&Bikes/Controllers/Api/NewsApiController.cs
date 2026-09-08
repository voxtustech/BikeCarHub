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
                .Take(5)
                .Select(x => new
                {
                    id = x.TWLatestNewsId,
                    heading = x.NewsHeading,
                    summary = x.NewsSummary,
                    image = x.ImageURL,
                    date = x.Date,
                    brand = x.BrandName,
                    imageFolder = x.ImageFolderURL,
                    isTwoWheeler = x.IsTwoWheeler,
                    slug = x.ImageURL
                    .Replace("latestnews/", ""),
                })
                .ToListAsync();

            return Ok(news);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNewsById(int id)
        {
            var news = await _context.TWLatestNews
                .Where(x => x.TWLatestNewsId == id)
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
                .FirstOrDefaultAsync();

            if (news == null)
            {
                return NotFound(new
                {
                    message = "News article not found."
                });
            }

            return Ok(news);
        }
        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetNewsBySlug(string slug)
        {
            var news = await _context.TWLatestNews
                .Where(x =>
                    x.NewsHeading
                        .ToLower()
                        .Replace(" ", "-")
                        .Replace(":", "")
                        .Replace("?", "")
                        .Replace(",", "")
                    == slug.ToLower()
                )
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
                .FirstOrDefaultAsync();

            if (news == null)
            {
                return NotFound(new
                {
                    message = "News article not found."
                });
            }

            return Ok(news);
        }
    }
}