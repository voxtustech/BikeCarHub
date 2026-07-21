using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class TriumphController : Controller
    {
        private readonly TwoWheelerDB _context;
        public TriumphController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("triumph/triumph-new-tiger-1200")]
        public IActionResult TriumphNewTiger1200()
        {
            var bikeDetails = GetBikeDetails("Triumph New Tiger 1200");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphNewTiger1200.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-new-tiger-900-range")]
        public IActionResult TriumphNEWTIGER900RANGE()
        {
            var bikeDetails = GetBikeDetails("Triumph NEW TIGER 900 RANGE");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphNEWTIGER900RANGE.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-tiger-sport-660")]
        public IActionResult TriumphTIGERSPORT660()
        {
            var bikeDetails = GetBikeDetails("Triumph TIGER SPORT 660");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphTIGERSPORT660.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-tiger-850-sport")]
        public IActionResult TriumphTIGER850SPORT()
        {
            var bikeDetails = GetBikeDetails("Triumph TIGER 850 SPORT");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphTIGER850SPORT.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-new-speed-t4")]
        public IActionResult TriumphNEWSPEEDT4()
        {
            var bikeDetails = GetBikeDetails("Triumph NEW SPEED T4");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphNEWSPEEDT4.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-new-speed-twin-1200")]
        public IActionResult TriumphNEWSPEEDTWIN1200()
        {
            var bikeDetails = GetBikeDetails("Triumph NEW SPEED TWIN 1200");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphNEWSPEEDTWIN1200.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-speed-400")]
        public IActionResult TriumphSPEED400()
        {
            var bikeDetails = GetBikeDetails("Triumph SPEED 400");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphSPEED400.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-scrambler-400-x")]
        public IActionResult TriumphSCRAMBLER400X()
        {
            var bikeDetails = GetBikeDetails("Triumph SCRAMBLER 400 X");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphSCRAMBLER400X.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-speed-twin-900")]
        public IActionResult TriumphSPEEDTWIN900()
        {
            var bikeDetails = GetBikeDetails("Triumph SPEED TWIN 900");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphSPEEDTWIN900.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-bonneville-t100")]
        public IActionResult TriumphBONNEVILLET100()
        {
            var bikeDetails = GetBikeDetails("Triumph BONNEVILLE T100");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphBONNEVILLET100.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-scrambler-900")]
        public IActionResult TriumphSCRAMBLER900()
        {
            var bikeDetails = GetBikeDetails("Triumph SCRAMBLER 900");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphSCRAMBLER900.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-scrambler-1200")]
        public IActionResult TriumphSCRAMBLER1200()
        {
            var bikeDetails = GetBikeDetails("Triumph SCRAMBLER 1200");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphSCRAMBLER1200.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-bonneville-T120")]
        public IActionResult TriumphBONNEVILLET120()
        {
            var bikeDetails = GetBikeDetails("Triumph BONNEVILLE T120");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphBONNEVILLET120.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-bonneville-bobber")]
        public IActionResult TriumphBONNEVILLEBOBBER()
        {
            var bikeDetails = GetBikeDetails("Triumph BONNEVILLE BOBBER");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphBONNEVILLEBOBBER.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-bonneville-speedmaster")]
        public IActionResult TriumphBONNEVILLESPEEDMASTER()
        {
            var bikeDetails = GetBikeDetails("Triumph BONNEVILLE SPEEDMASTER");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphBONNEVILLESPEEDMASTER.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-trident-660")]
        public IActionResult TriumphTRIDENT660()
        {
            var bikeDetails = GetBikeDetails("Triumph TRIDENT 660");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphTRIDENT660.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-street-triple-765")]
        public IActionResult TriumphSTREETTRIPLE765()
        {
            var bikeDetails = GetBikeDetails("Triumph STREET TRIPLE 765");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphSTREETTRIPLE765.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-speed-triple-1200-rs")]
        public IActionResult TriumphSPEEDTRIPLE1200RS()
        {
            var bikeDetails = GetBikeDetails("Triumph SPEED TRIPLE 1200 RS");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphSPEEDTRIPLE1200RS.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-rocket-3-storm")]
        public IActionResult TriumphROCKET3STORM()
        {
            var bikeDetails = GetBikeDetails("Triumph ROCKET 3 STORM");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphROCKET3STORM.cshtml", bikeDetails);
        }
        [Route("triumph/triumph-all-new-daytona-660")]
        public IActionResult TriumphALLNEWDAYTONA660()
        {
            var bikeDetails = GetBikeDetails("Triumph ALL-NEW DAYTONA 660");
            return View("~/Views/TwoWheeler/Brand/Triumph/TriumphALLNEWDAYTONA660.cshtml", bikeDetails);
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
