using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class TVSController : Controller
    {
        private readonly TwoWheelerDB _context;
        public TVSController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("tvs/tvs-apache-rtr-160")]
        public IActionResult TVSApacheRTR160()
        {
            var bikeDetails = GetBikeDetails("TVS Apache RTR 160");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSApacheRTR160.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-apache-rtr-160-4v")]
        public IActionResult TVSApacheRTR1604V()
        {
            var bikeDetails = GetBikeDetails("TVS Apache RTR 160 4V");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSApacheRTR1604V.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-apache-rtr-200-4v")]
        public IActionResult TVSApacheRTR2004V()
        {
            var bikeDetails = GetBikeDetails("TVS Apache RTR 200 4V");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSApacheRTR2004V.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-apache-rtr-180")]
        public IActionResult TVSApacheRTR180()
        {
            var bikeDetails = GetBikeDetails("TVS Apache RTR 180");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSApacheRTR180.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-apache-rtr-310")]
        public IActionResult TVSApacheRTR310()
        {
            var bikeDetails = GetBikeDetails("TVS Apache RTR 310");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSApacheRTR310.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-apache-rr-310")]
        public IActionResult TVSApacheRR310()
        {
            var bikeDetails = GetBikeDetails("TVS Apache RR 310");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSApacheRR310.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-raider-125")]
        public IActionResult TVSRaider125()
        {
            var bikeDetails = GetBikeDetails("TVS Raider 125");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSRaider125.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-radeon")]
        public IActionResult TVSRadeon()
        {
            var bikeDetails = GetBikeDetails("TVS Radeon");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSRadeon.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-ronin")]
        public IActionResult TVSRonin()
        {
            var bikeDetails = GetBikeDetails("TVS Ronin");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSRonin.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-sport")]
        public IActionResult TVSSport()
        {
            var bikeDetails = GetBikeDetails("TVS Sport");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSSport.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-xl-100")]
        public IActionResult TVSXL100()
        {
            var bikeDetails = GetBikeDetails("TVS XL 100");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSXL100.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-jupiter")]
        public IActionResult TVSJupiter()
        {
            var bikeDetails = GetBikeDetails("TVS Jupiter");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSJupiter.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-jupiter-125")]
        public IActionResult TVSJupiter125()
        {
            var bikeDetails = GetBikeDetails("TVS Jupiter 125");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSJupiter125.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-ntorq-125")]
        public IActionResult TVSNtorq125()
        {
            var bikeDetails = GetBikeDetails("TVS Ntorq 125");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSNtorq125.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-scooty-pep-plus")]
        public IActionResult TVSScootyPepPlus()
        {
            var bikeDetails = GetBikeDetails("TVS Scooty Pep Plus");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSScootyPepPlus.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-star-city-plus")]
        public IActionResult TVSStarCityPlus()
        {
            var bikeDetails = GetBikeDetails("TVS Star City Plus");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSStarCityPlus.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-zest-110")]
        public IActionResult TVSZest110()
        {
            var bikeDetails = GetBikeDetails("TVS Zest 110");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSZest110.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-x")]
        public IActionResult TVSX()
        {
            var bikeDetails = GetBikeDetails("TVS X");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSX.cshtml", bikeDetails);
        }
        [Route("tvs/tvs-iqube")]
        public IActionResult TVSiQube()
        {
            var bikeDetails = GetBikeDetails("TVS iQube");
            return View("~/Views/TwoWheeler/Brand/TVS/TVSiQube.cshtml", bikeDetails);
        }
        //private Cars_Bikes.Models.TwoWheeler GetBikeDetails(string bikeName)
        //{
        //    var bike = _context.Twowheelers.Include(b => b.TWVarients)
        //        //.Include(b => b.TWSpecs)
        //        .FirstOrDefault(b => b.TwoWheelerName == bikeName);

        //    if (bike == null)
        //    {
        //        // Handle the case where the bike is not found
        //        return null;
        //    }
        //    var Allbrand = _context.TwowheelerBrands.ToList();
        //    ViewBag.AllBrand = Allbrand;
        //    return bike;
        //}
        private Cars_Bikes.Models.TwoWheeler GetBikeDetails(string bikeName)
        {
            var bike = _context.Twowheelers
                .Include(b => b.TWVarients)
                .FirstOrDefault(b => b.TwoWheelerName == bikeName);

            if (bike == null)
            {
                return null;
            }

            var reviews = _context.Reviews
                .Where(r => r.TwoWheelerID == bike.TwoWheelerId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            ViewBag.Reviews = reviews;
            ViewBag.ReviewCount = reviews.Count;

            ViewBag.AverageRating = reviews.Any()
                ? reviews.Average(r => r.Rating)
                : 0;

            var user = User.Identity?.IsAuthenticated == true
                ? _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name)
                : null;

            Review? userReview = null;

            if (user != null)
            {
                userReview = reviews.FirstOrDefault(r => r.UserID == user.Id);
            }

            ViewBag.UserReview = userReview;

            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.AllBrand = Allbrand;

            return bike;
        }
        [HttpGet]
        public JsonResult GetTWSpecData(int variantId)
        {
            var specs = _context.TWSpec
            .Where(s => s.TWVarientId == variantId)
            .Select(s => new
            {
                s.Varients,
                s.Milage,
                s.FrontBrake,
                s.RearBrake,
                s.FuelCapacity,
                s.TwoWheeler,
                s.BodyType
            })
            .FirstOrDefault();

            var engineAndTransmission = _context.TWEngineAndTransmissions
                .Where(e => e.TWVarientId == variantId)
                .Select(e => new
                {
                    e.EngineType,
                    e.Displacement,
                    e.MaxTorque,
                    e.NumOfCylinders,
                    e.CoolingSystem,
                    e.ValvePerCylinder,
                    e.Starting,
                    e.FuelSupply,
                    e.Clutch,
                    e.GearBox,
                    e.EmissionType,
                    e.CompressionRatio,
                    e.Ignition
                })
                .FirstOrDefault();

            var features = _context.TWFeatures
                .Where(f => f.TWVarientId == variantId)
                .Select(f => new
                {
                    f.ABS,
                    f.Speedometer,
                    f.Tripmeter,
                    f.Tachometer,
                    f.LEDTailLight,
                    f.Odometer,
                    f.FuelGauge,
                    f.InstrumentConsole,
                    f.SeatType,
                    f.BodyGraphics,
                    f.Clock,
                    f.PassengerFootrest,
                    f.AdditionalFeaturesOfVariant,
                    f.DistanceToEmptyIndicator,
                    f.AdjustableWindshield
                })
                .FirstOrDefault();

            var safety = _context.TWSafety
                .Where(s => s.TWVarientId == variantId)
                .Select(s => new
                {
                    s.PassSwitch,
                    s.EngineKillSwitch,
                    s.Display,
                    s.RidingModes,
                    s.TractionControl,
                    s.AdditionalFeatures
                })
                .FirstOrDefault();
            var mileageAndPerformance = _context.TWMileageAndPerformances
            .Where(mp => mp.TWVarientId == variantId)
            .Select(mp => new
            {
                mp.OverallMileage,
                mp.CityMileage,
                mp.HighwayMileage
            })
            .FirstOrDefault();

            var dimensionsAndCapacity = _context.TWDimensionsAndCapacities
                .Where(dc => dc.TWVarientId == variantId)
                .Select(dc => new
                {
                    dc.Width,
                    dc.Length,
                    dc.Height,
                    dc.FuelCapacity,
                    dc.GroundClearance,
                    dc.Wheelbase,
                    dc.KerbWeight,
                    dc.FuelReserve,
                    dc.SaddleHeight
                })
                .FirstOrDefault();

            var electricals = _context.TWElectricals
                .Where(e => e.TWVarientId == variantId)
                .Select(e => new
                {
                    e.Headlight,
                    e.TailLight,
                    e.TurnSignalLamp,
                    e.LEDTailLights,
                    e.LowFuelIndicato,
                    e.PilotLamps,
                    e.DistanceToEmptyIndicator,
                    e.DRLs
                })
                .FirstOrDefault();

            var tyresAndBrakes = _context.TWTyresAndBrakes
                .Where(tb => tb.TWVarientId == variantId)
                .Select(tb => new
                {
                    tb.FrontBrakeDiameter,
                    tb.RearBrakeDiameter,
                    tb.RadialTyre,
                    tb.FrontSuspension,
                    tb.RearSuspension
                })
                .FirstOrDefault();

            var motorAndBattery = _context.TWMotorAndBatteries
                .Where(mb => mb.TWVarientId == variantId)
                .Select(mb => new
                {
                    mb.PeakPower,
                    mb.DriveType,
                    mb.Transmission,
                    mb.BatteryCapacity
                })
                .FirstOrDefault();

            var underpinning = _context.TWUnderpinnings
                .Where(u => u.TWVarientId == variantId)
                .Select(u => new
                {
                    u.SuspensionFront,
                    u.SuspensionRear,
                    u.BrakesFront,
                    u.BrakesRear,
                    u.TyreSize,
                    u.WheelSize,
                    u.WheelType,
                    u.TubelessTyre
                })
                .FirstOrDefault();

            var charging = _context.TWChargings
                .Where(c => c.TWVarientId == variantId)
                .Select(c => new
                {
                    c.ChargingAtHome,
                    c.ChargingAtChargingStation
                })
                .FirstOrDefault();
            return Json(new
            {
                specs,
                engineAndTransmission,
                features,
                safety,
                mileageAndPerformance,
                dimensionsAndCapacity,
                electricals,
                tyresAndBrakes,
                motorAndBattery,
                underpinning,
                charging
            });
        }
    }
}
