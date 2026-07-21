using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class RoyalEnfieldController : Controller
    {
        private readonly TwoWheelerDB _context;
        public RoyalEnfieldController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("royal-enfield/royal-enfield-shotgun-650")]
        public IActionResult REShotgun650()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Shotgun 650");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REShotgun650.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-himalyan")]
        public IActionResult REHimalyan()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Himalyan");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REHimalyan.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-bullet-350")]
        public IActionResult REBullet350()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Bullet 350");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REBullet350.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-super-meteor-650")]
        public IActionResult RESuperMeteor650()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Super Meteor 650");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/RESuperMeteor650.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-hunter-350")]
        public IActionResult REHunter350()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Hunter 350");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REHunter350.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-scram-411")]
        public IActionResult REScram411()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Scram 411");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REScram411.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-classic-350")]
        public IActionResult REClassic350()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Classic 350");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REClassic350.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-meteor-350")]
        public IActionResult REMeteor350()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Meteor 350");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REMeteor350.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-interceptor-650")]
        public IActionResult REInterceptor650()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Interceptor 650");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REInterceptor650.cshtml", bikeDetails);
        }
        [Route("royal-enfield/royal-enfield-continental-gt-650")]
        public IActionResult REContinentalGT650()
        {
            var bikeDetails = GetBikeDetails("Royal Enfield Continental GT 650");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/REContinentalGT650.cshtml", bikeDetails);
        }
        [Route("royal-enfield/flying-flea")]
        public IActionResult FlyingFlea()
        {
            var bikeDetails = GetBikeDetails("Flying Flea");
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield/FlyingFlea.cshtml", bikeDetails);
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
