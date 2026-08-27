/*
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/valueformoney")]
    public class ValueForMoneyApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public ValueForMoneyApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _context.ValueForMoney
                .OrderByDescending(x => x.Date)
                .Select(x => new
                {
                    id = x.VFMId,
                    heading = x.VFMHeading,
                    image = x.ImageURL,
                    url = x.URL,
                    date = x.Date,
                    isTwoWheeler = x.IsTwoWheeler
                })
                .ToListAsync();

            return Ok(articles);
        }
    }
}
*/

/*
using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/valueformoney")]
    public class ValueForMoneyApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public ValueForMoneyApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        // ============================================================
        // GET : api/valueformoney
        // ============================================================

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _context.ValueForMoney

                .OrderByDescending(x => x.Date)

                .Select(x => new
                {
                    id = x.VFMId,

                    title = x.VFMHeading,

                    slug = x.URL,

                    image = x.ImageURL,

                    date = x.Date,

                    isTwoWheeler = x.IsTwoWheeler
                })

                .ToListAsync();

            return Ok(articles);
        }

        // ============================================================
        // GET : api/valueformoney/related/{slug}
        // ============================================================

        [HttpGet("related/{slug}")]
        public async Task<IActionResult> GetRelated(string slug)
        {
            var articles = await _context.ValueForMoney

                .Where(x => x.URL != slug)

                .OrderByDescending(x => x.Date)

                .Take(3)

                .Select(x => new
                {
                    id = x.VFMId,

                    title = x.VFMHeading,

                    slug = x.URL,

                    image = x.ImageURL,

                    date = x.Date,

                    isTwoWheeler = x.IsTwoWheeler
                })

                .ToListAsync();

            return Ok(articles);
        }

        // ============================================================
        // GET : api/valueformoney/{slug}
        // ============================================================

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetArticle(string slug)
        {
            var article = await _context.ValueForMoney

                .Where(x => x.URL == slug)

                .Select(x => new
                {
                    id = x.VFMId,

                    title = x.VFMHeading,

                    slug = x.URL,

                    image = x.ImageURL,

                    date = x.Date,

                    isTwoWheeler = x.IsTwoWheeler,

                    // Temporary values
                    description = "",

                    readTime = "8 min read",

                    sections = new object[] { },

                    tables = new object[] { },

                    faqs = new object[] { },

                    verdict = (object?)null
                })

                .FirstOrDefaultAsync();

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }
    }
}
*/

using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/valueformoney")]
    public class ValueForMoneyApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public ValueForMoneyApiController(
            TwoWheelerDB context)
        {
            _context = context;
        }

        // ============================================================
        // GET : api/valueformoney
        // ============================================================

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _context.ValueForMoney
                .OrderByDescending(x => x.Date)
                .Select(x => new
                {
                    id = x.VFMId,
                    title = x.VFMHeading,
                    slug = x.URL,
                    image = x.ImageURL,
                    date = x.Date,
                    isTwoWheeler = x.IsTwoWheeler
                })
                .ToListAsync();

            return Ok(articles);
        }

        // ============================================================
        // GET : api/valueformoney/related/{slug}
        // ============================================================

        [HttpGet("related/{slug}")]
        public async Task<IActionResult> GetRelated(string slug)
        {
            var articles = await _context.ValueForMoney
                .Where(x => x.URL != slug)
                .OrderByDescending(x => x.Date)
                .Take(3)
                .Select(x => new
                {
                    id = x.VFMId,
                    title = x.VFMHeading,
                    slug = x.URL,
                    image = x.ImageURL,
                    date = x.Date,
                    isTwoWheeler = x.IsTwoWheeler
                })
                .ToListAsync();

            return Ok(articles);
        }

        // ============================================================
        // GET : api/valueformoney/{slug}
        // ============================================================

        /*
        [HttpGet("{slug}")]
        public IActionResult GetArticle(string slug)
        {
            var article = _valueForMoneyService.GetArticle(slug);

            if (article == null)
            {
                return NotFound(new
                {
                    message = $"Article '{slug}' not found."
                });
            }

            return Ok(article);
        }
        */

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetArticle(string slug)
        {
            var article = await _context.ValueForMoney

                .Where(x => x.URL == slug)

                .Select(x => new
                {
                    id = x.VFMId,

                    title = x.VFMHeading,

                    slug = x.URL,

                    image = x.ImageURL,

                    date = x.Date,

                    isTwoWheeler = x.IsTwoWheeler,

                    // Temporary values
                    description = "",

                    readTime = "8 min read",

                    sections = new object[] { },

                    tables = new object[] { },

                    faqs = new object[] { },

                    verdict = (object?)null
                })

                .FirstOrDefaultAsync();

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }
    }
}