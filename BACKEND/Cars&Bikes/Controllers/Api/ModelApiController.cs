using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/models")]
    public class ModelApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public ModelApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        [HttpGet("{brand}")]
        public async Task<IActionResult> GetModels(string brand)
        {
            var models = await _context.Twowheelers
    .Where(x =>
    x.TwoWheelerBrands.BrandName == brand &&
    x.IsActive == true)
    .OrderBy(x => x.TwoWheelerName)
    .Select(x => new
    {
        id = x.TwoWheelerId,

        label = x.TwoWheelerName,

        value = x.TwoWheelerName
    })
    .Distinct()
    .ToListAsync();

            return Ok(models);
        }
    }
}