using System.Runtime.InteropServices;
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

        // GET: /api/blogs
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _context.Blogs
                .OrderByDescending(b => b.Date)
                .ToListAsync();

            return Ok(blogs);
        }

        // GET: /api/blogs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        // GET /api/blogs/{slug}
        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetBlog(string slug)
        {
            var blog = await _context.Blogs
                .FirstOrDefaultAsync(b => b.URL.EndsWith(slug));

            if (blog == null)
                return NotFound();

            return Ok(blog);

        } 
    }
}