using System.Runtime.InteropServices;
using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.Api
{
    [ApiController]
    [Route("api/bikes")]
    public class BikeDetailsApiController : ControllerBase
    {
        private readonly TwoWheelerDB _context;

        public BikeDetailsApiController(TwoWheelerDB context)
        {
            _context = context;
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetBikeDetails(int id)
        {
            var bike = await _context.Twowheelers
                .Include(x => x.TwoWheelerBrands)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.TwoWheelerId == id);

            if (bike == null)
                return NotFound();

            var bikeDto = new
            {
                id = bike.TwoWheelerId,
                name = bike.TwoWheelerName,
                brand = bike.Brand,
                price = bike.Price,
                basePrice = bike.BasePrice,
                topPrice = bike.TopPrice,
                image = bike.TWImage,
                description = bike.Discription == "NULL" ? "" : bike.Discription,
                launchDate = bike.LaunchDate,
                type = bike.Type,
                isEV = bike.IsEV
            };

            // -----------------------------
            // Variants
            // -----------------------------

            var variants = await _context.TWVarients
    .AsNoTracking()
    .Where(x => x.TwoWheelerId == id)
    .Select(x => new
    {
        id = x.TWVarientId,
        name = x.Varients
    })
    .ToListAsync();

            // -----------------------------
            // Specifications
            // -----------------------------

            var specs = await _context.TWSpec
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    mileage = x.Milage,
                    fuelCapacity = x.FuelCapacity,
                    frontBrake = x.FrontBrake,
                    rearBrake = x.RearBrake,
                    bodyType = x.BodyType
                })
                .ToListAsync();

            // -----------------------------
            // Engine & Transmission
            // -----------------------------

            var engine = await _context.TWEngineAndTransmissions
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,
                    engineType = x.EngineType,
                    displacement = x.Displacement,
                    maxTorque = x.MaxTorque,
                    cylinders = x.NumOfCylinders,
                    coolingSystem = x.CoolingSystem,
                    valvesPerCylinder = x.ValvePerCylinder,
                    starting = x.Starting,
                    fuelSupply = x.FuelSupply,
                    clutch = x.Clutch,
                    gearbox = x.GearBox,
                    ignition = x.Ignition,
                    compressionRatio = x.CompressionRatio,
                    emissionType = x.EmissionType
                })
                .ToListAsync();

            // -----------------------------
            // Features
            // -----------------------------

            var features = await _context.TWFeatures
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    abs = x.ABS,
                    speedometer = x.Speedometer,
                    tripmeter = x.Tripmeter,
                    tachometer = x.Tachometer,
                    ledTailLight = x.LEDTailLight,
                    odometer = x.Odometer,
                    fuelGauge = x.FuelGauge,
                    instrumentConsole = x.InstrumentConsole,
                    seatType = x.SeatType,
                    bodyGraphics = x.BodyGraphics,
                    clock = x.Clock,
                    passengerFootrest = x.PassengerFootrest,
                    additionalFeatures = x.AdditionalFeaturesOfVariant,
                    distanceToEmpty = x.DistanceToEmptyIndicator,
                    adjustableWindshield = x.AdjustableWindshield
                })
                .ToListAsync();

            // -----------------------------
            // Safety
            // -----------------------------

            var safety = await _context.TWSafety
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    passSwitch = x.PassSwitch,
                    engineKillSwitch = x.EngineKillSwitch,
                    display = x.Display,
                    ridingModes = x.RidingModes,
                    tractionControl = x.TractionControl,
                    additionalFeatures = x.AdditionalFeatures
                })
                .ToListAsync();

            // -----------------------------
            // Mileage & Performance
            // -----------------------------

            var performance = await _context.TWMileageAndPerformances
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    overallMileage = x.OverallMileage,
                    cityMileage = x.CityMileage,
                    highwayMileage = x.HighwayMileage
                })
                .ToListAsync();

            // -----------------------------
            // Dimensions & Capacity
            // -----------------------------

            var dimensions = await _context.TWDimensionsAndCapacities
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    width = x.Width,
                    length = x.Length,
                    height = x.Height,
                    fuelCapacity = x.FuelCapacity,
                    groundClearance = x.GroundClearance,
                    wheelbase = x.Wheelbase,
                    kerbWeight = x.KerbWeight,
                    fuelReserve = x.FuelReserve,
                    saddleHeight = x.SaddleHeight
                })
                .ToListAsync();

            // -----------------------------
            // Electricals
            // -----------------------------

            var electricals = await _context.TWElectricals
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    headlight = x.Headlight,
                    tailLight = x.TailLight,
                    turnSignalLamp = x.TurnSignalLamp,
                    ledTailLights = x.LEDTailLights,
                    lowFuelIndicator = x.LowFuelIndicato,
                    pilotLamps = x.PilotLamps,
                    distanceToEmptyIndicator = x.DistanceToEmptyIndicator,
                    drls = x.DRLs
                })
                .ToListAsync();

            // -----------------------------
            // Tyres & Brakes
            // -----------------------------
            var tyres = await _context.TWTyresAndBrakes
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    frontBrakeDiameter = x.FrontBrakeDiameter,
                    rearBrakeDiameter = x.RearBrakeDiameter,
                    radialTyre = x.RadialTyre,
                    frontSuspension = x.FrontSuspension,
                    rearSuspension = x.RearSuspension
                })
                .ToListAsync();

            // -----------------------------
            // Motor & Battery
            // -----------------------------

            var motorBattery = await _context.TWMotorAndBatteries
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    peakPower = x.PeakPower,
                    driveType = x.DriveType,
                    transmission = x.Transmission,
                    batteryCapacity = x.BatteryCapacity
                })
                .ToListAsync();

            // -----------------------------
            // Charging
            // -----------------------------

            var charging = await _context.TWChargings
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    chargingAtHome = x.ChargingAtHome,
                    chargingAtChargingStation = x.ChargingAtChargingStation
                })
                .ToListAsync();

            // -----------------------------
            // Underpinnings
            // -----------------------------

            var underpinnings = await _context.TWUnderpinnings
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    variantId = x.TWVarientId,
                    variant = x.Varients,

                    suspensionFront = x.SuspensionFront,
                    suspensionRear = x.SuspensionRear,
                    brakesFront = x.BrakesFront,
                    brakesRear = x.BrakesRear,
                    tyreSize = x.TyreSize,
                    wheelSize = x.WheelSize,
                    wheelType = x.WheelType,
                    tubelessTyre = x.TubelessTyre
                })
                .ToListAsync();

            // -----------------------------
            // Images
            // -----------------------------

            
             var images = await _context.TWImageColorPrices
                .AsNoTracking()
                .Where(x => x.TwoWheelerId == id)
                .Select(x => new
                {
                    image = x.ImageURL,
                    color = x.Color,
                    price = x.Price,
                    variantId = x.TWVarientId,
                    topColorCode = x.TopColorCode,
                    bottomColorCode = x.BottomColorCode
                })
                .ToListAsync();
            

            
            // If no colour images exist, use hero image


            // -----------------------------
            // Similar Bikes
            // -----------------------------

            var similarBikes = await _context.Twowheelers
                .AsNoTracking()
                .Where(x =>
                    x.TwoWheelerId != bike.TwoWheelerId &&
                    x.Type == bike.Type &&
                    x.IsActive == true)
                .OrderBy(x => x.BasePrice)
                .Take(8)
                .Select(x => new
                {
                    id = x.TwoWheelerId,
                    name = x.TwoWheelerName,
                    image = x.TWImage,
                    price = x.Price,
                    brand = x.Brand
                })
                .ToListAsync();

            // -----------------------------
            // Latest News
            // -----------------------------

            var news = await _context.TWLatestNews
                .AsNoTracking()
                .Where(x => x.BrandName == bike.Brand)
                .OrderByDescending(x => x.Date)
                .Take(5)
                .Select(x => new
                {
                    id = x.TWLatestNewsId,
                    title = x.NewsHeading,
                    image = x.ImageURL,
                    summary = x.NewsSummary,
                    date = x.Date
                })
                .ToListAsync();

            // -----------------------------
            // Blogs
            // -----------------------------

            var blogs = await _context.Blogs
                .AsNoTracking()
                .Where(x => x.IsTwoWheeler == true)
                .OrderByDescending(x => x.Date)
                .Take(6)
                .Select(x => new
                {
                    id = x.BlogId,
                    title = x.BlogHeading,
                    summary = x.BlogSummary,
                    image = x.ImageURL,
                    date = x.Date
                })
                .ToListAsync();

            // -----------------------------
            // Reviews
            // -----------------------------

            var reviews = await _context.Reviews
    .AsNoTracking()
    .Where(x => x.TwoWheelerID == id)
    .OrderByDescending(x => x.CreatedAt)
    .Take(10)
    .Select(x => new
    {
        id = x.ReviewID,
        user = x.Username,
        rating = x.Rating,
        review = x.ReviewText,
        date = x.CreatedAt
    })
    .ToListAsync();

            // -----------------------------
            // Rating
            // -----------------------------

            double rating = reviews.Any()
    ? Math.Round(reviews.Average(x => (double)x.rating), 1)
    : 0;

            var reviewCount = reviews.Count;

            // -----------------------------
            // Wishlist
            // -----------------------------

            bool isWishlisted = false;

            // TODO:
            // Replace this once authentication is integrated.
            // Example:
            //
            // if(User.Identity.IsAuthenticated)
            // {
            //     var userId = ...
            //     isWishlisted = await _context.Wishlist.AnyAsync(...);
            // }

            // -----------------------------
            // Return Result
            // -----------------------------

            return Ok(new
            {
                bike = new
                {
                    bikeDto.id,
                    bikeDto.name,
                    bikeDto.brand,
                    bikeDto.price,
                    bikeDto.basePrice,
                    bikeDto.topPrice,
                    bikeDto.image,
                    bikeDto.description,
                    bikeDto.launchDate,
                    bikeDto.type,
                    bikeDto.isEV,

                    rating,
                    reviewCount,
                    isWishlisted
                },

                variants,

                specs,

                engine,

                features,

                safety,

                performance,

                dimensions,

                electricals,

                tyres,

                motorBattery,

                charging,

                underpinnings,

                images,

                similarBikes,

                news,

                blogs,

                reviews
            });

        }
    }
}