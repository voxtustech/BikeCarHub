using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/search")]

    public class SearchApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public SearchApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        // GET: api/search?term=royal
        [HttpGet]
        public async Task<IActionResult> Search(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return Ok(new List<object>());

            var bikes = await _context.Twowheelers
                .Where(x =>
                    x.IsActive == true &&
                    x.TwoWheelerName.Contains(term))
                .Select(x => new
                {
                    id = x.TwoWheelerId,
                    label = x.TwoWheelerName,
                    type = "Bike"
                })
                .Take(10)
                .ToListAsync();

            var brands = await _context.TwowheelerBrands
                .Where(x =>
                    x.IsTWBrand == true &&
                    x.BrandName.Contains(term))
                .Select(x => new
                {
                    id = x.TWBrandId,
                    label = x.BrandName,
                    type = "Brand"
                })
                .Take(10)
                .ToListAsync();

            var compare = await _context.CompareItems
                .Where(x => x.Topic.Contains(term))
                .Select(x => new
                {
                    id = 0,   // <-- change if your PK has a different name
                    label = x.Topic,
                    type = "Compare"
                })
                .Take(5)
                .ToListAsync();

            return Ok(
                brands
                    .Concat(bikes)
                    .Concat(compare)
            );
        }

        // GET: api/search/details?name=Hunter 350
        [HttpGet("details")]
        public async Task<IActionResult> GetDetails(string name)
        {
            var bike = await _context.Twowheelers
                .Where(x =>
                    x.TwoWheelerName == name &&
                    x.IsActive == true)
                .Select(x => new
                {
                    brandId = x.TwoWheelerBrands.TWBrandId,
                    modelId = x.TwoWheelerId,
                    brandName = x.Brand.ToLower().Replace(" ", "-"),
                    bikeName = x.TwoWheelerName.ToLower().Replace(" ", "-")
                })
                .FirstOrDefaultAsync();

            if (bike == null)
                return NotFound();

            return Ok(bike);
        }

        [HttpGet("variants/{bikeId:int}")]
        public async Task<IActionResult> GetVariants(int bikeId)
        {
            var variants = await _context.TWVarients
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == bikeId)
                .OrderBy(x => x.TWVarientId)
                .Select(x => new
                {
                    id = x.TWVarientId,
                    bikeId = x.TwoWheelerId,
                    name = x.Varients ?? x.TWName,
                    price = _context.TWImageColorPrices
                        .Where(p =>
                            p.TwoWheelerId == bikeId &&
                            p.TWVarientId == x.TWVarientId)
                        .OrderBy(p => p.TWImageColorPriceId)
                        .Select(p => p.Price)
                        .FirstOrDefault()
                })
                .ToListAsync();

            return Ok(variants);
        }
    }

}
