using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/brands")]
    public class BrandApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public BrandApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context.TwowheelerBrands
                .OrderBy(x => x.BrandName)
                .Select(x => new
                {
                    id = x.TWBrandId,
                    name = x.BrandName,
                    logo = x.BrandLogoURL,
                    petrol = x.IsPetrol,
                    ev = x.IsEV
                })
                .ToListAsync();

            return Ok(brands);
        }

        [HttpGet("{brandId:int}")]
        public async Task<IActionResult> GetBrand(int brandId)
        {
            var brand = await _context.TwowheelerBrands
                .Where(x => x.TWBrandId == brandId)
                .Select(x => new
                {
                    id = x.TWBrandId,
                    name = x.BrandName,
                    logo = x.BrandLogoURL,
                    petrol = x.IsPetrol,
                    ev = x.IsEV
                })
                .FirstOrDefaultAsync();

            if (brand == null)
                return NotFound();

            return Ok(brand);
        }

        [HttpGet("{brandId:int}/bikes")]
        public async Task<IActionResult> GetBrandBikes(int brandId)
        {
            var bikes = await _context.Twowheelers
                .Include(x => x.TwoWheelerBrands)
                .Where(x => x.TwoWBrandId == brandId && x.IsActive == true)
                .OrderBy(x => x.BasePrice)
                .Select(x => new
                {
                    id = x.TwoWheelerId,
                    name = x.TwoWheelerName,
                    //image = x.TWImage,
                    image = _context.TWImageColorPrices
                        .Where(i => i.TwoWheelerId == x.TwoWheelerId)
                        .OrderBy(i => i.TWImageColorPriceId)
                        .Select(i => i.ImageURL)
                        .FirstOrDefault(),
                    price = x.Price,
                    launchDate = x.LaunchDate,
                    brand = x.Brand,
                    brandId = x.TwoWBrandId
                })
                .ToListAsync();

            return Ok(bikes);
        }

        [HttpGet("popular")]
        public async Task<IActionResult> PopularBrands()
        {
            var brands = await _context.TwowheelerBrands
                .OrderBy(x => x.BrandName)
                .Select(x => new
                {
                    id = x.TWBrandId,
                    name = x.BrandName,
                    logo = x.BrandLogoURL
                })
                .ToListAsync();

            return Ok(brands);
        }
    }
}