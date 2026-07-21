using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class KTMController : Controller
    {
        private readonly TwoWheelerDB _context;
        public KTMController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("ktm/ktm-390-duke")]
        public IActionResult KTM390Duke()
        {
            var bikeDetails = GetBikeDetails("KTM 390 Duke");
            return View("~/Views/TwoWheeler/Brand/KTM/KTM390Duke.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-250-duke")]
        public IActionResult KTM250Duke()
        {
            var bikeDetails = GetBikeDetails("KTM 250 Duke");
            return View("~/Views/TwoWheeler/Brand/KTM/KTM250Duke.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-200-duke")]
        public IActionResult KTM200DUKE()
        {
            var bikeDetails = GetBikeDetails("KTM 200 DUKE");
            return View("~/Views/TwoWheeler/Brand/KTM/KTM200DUKE.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-125-duke")]
        public IActionResult KTM125DUKE()
        {
            var bikeDetails = GetBikeDetails("KTM 125 DUKE");
            return View("~/Views/TwoWheeler/Brand/KTM/KTM125DUKE.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-rc-390-gp")]
        public IActionResult KTMRC390GP()
        {
            var bikeDetails = GetBikeDetails("KTM RC 390 GP");
            return View("~/Views/TwoWheeler/Brand/KTM/KTMRC390GP.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-rc-200-gp")]
        public IActionResult KTMRC200GP()
        {
            var bikeDetails = GetBikeDetails("KTM RC 200 GP");
            return View("~/Views/TwoWheeler/Brand/KTM/KTMRC200GP.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-rc-390")]
        public IActionResult KTMRC390()
        {
            var bikeDetails = GetBikeDetails("KTM RC 390");
            return View("~/Views/TwoWheeler/Brand/KTM/KTMRC390.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-rc-200")]
        public IActionResult KTMRC200()
        {
            var bikeDetails = GetBikeDetails("KTM RC 200");
            return View("~/Views/TwoWheeler/Brand/KTM/KTMRC200.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-rc-125")]
        public IActionResult KTMRC125()
        {
            var bikeDetails = GetBikeDetails("KTM RC 125");
            return View("~/Views/TwoWheeler/Brand/KTM/KTMRC125.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-390-adventure")]
        public IActionResult KTM390ADVENTURE()
        {
            var bikeDetails = GetBikeDetails("KTM 390 ADVENTURE");
            return View("~/Views/TwoWheeler/Brand/KTM/KTM390ADVENTURE.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-390-adventure-x")]
        public IActionResult KTM390ADVENTUREX()
        {
            var bikeDetails = GetBikeDetails("KTM 390 ADVENTURE X");
            return View("~/Views/TwoWheeler/Brand/KTM/KTM390ADVENTUREX.cshtml", bikeDetails);
        }
        [Route("ktm/ktm-250-adventure")]
        public IActionResult KTM250ADVENTURE()
        {
            var bikeDetails = GetBikeDetails("KTM 250 ADVENTURE");
            return View("~/Views/TwoWheeler/Brand/KTM/KTM250ADVENTURE.cshtml", bikeDetails);
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
