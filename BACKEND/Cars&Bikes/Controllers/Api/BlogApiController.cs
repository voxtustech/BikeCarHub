using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public BlogApiController(TwoWheelerDB context)
        {
            _context = context;
        }


        // =========================================================
        // GET: api/blogs
        // Get all blogs for listing page
        // =========================================================

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _context.Blogs
                .OrderByDescending(x => x.Date)
                .Take(5)
                .Select(x => new
                {
                    id = x.BlogId,

                    title = x.BlogHeading,

                    summary = x.BlogSummary,

                    date = x.Date,

                    image = x.ImageURL,

                   
                    slug = x.URL.StartsWith("blogs/")
                        ? x.URL.Substring(6)
                        : x.URL,

                    isTwoWheeler = x.IsTwoWheeler
                })
                .ToListAsync();

            return Ok(blogs);
        }


        // =========================================================
        // GET: api/blogs/{slug}
        // Get complete blog article
        // =========================================================

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBlogBySlug(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
            {
                return BadRequest(new
                {
                    message = "Blog slug is required."
                });
            }


            /*
             * React sends:
             *
             * /api/blogs/nissan-tekton
             *
             * Database contains:
             *
             * blogs/nissan-tekton
             */


            var databaseUrl = $"blogs/{slug}";


            var blog = await _context.Blogs
                .FirstOrDefaultAsync(x =>
                    x.URL == databaseUrl ||
                    x.URL == slug
                );


            if (blog == null)
            {
                return NotFound(new
                {
                    message = "Blog article not found."
                });
            }


            return Ok(new
            {
                id = blog.BlogId,

                title = blog.BlogHeading,

                summary = blog.BlogSummary,

                detail = blog.BlogDetail,

                date = blog.Date,

                image = blog.ImageURL,

                slug = blog.URL.StartsWith("blogs/")
                    ? blog.URL.Substring(6)
                    : blog.URL,

                isTwoWheeler = blog.IsTwoWheeler
            });
        }
    }
}