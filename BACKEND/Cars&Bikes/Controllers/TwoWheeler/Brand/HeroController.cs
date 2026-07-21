using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class HeroController : Controller
    {
        private readonly TwoWheelerDB _context;
        public HeroController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("hero/hero-splendor-plus")]
        public IActionResult HeroSplendorPlus()
        {
            var bikeDetails = GetBikeDetails("Hero Splendor Plus");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroSplendorPlus.cshtml", bikeDetails);
        }
        [Route("hero/hero-xtreme-125r")]
        public IActionResult HeroXtreme125R()
        {
            var bikeDetails = GetBikeDetails("Hero Xtreme 125R");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroXtreme125R.cshtml", bikeDetails);
        }
        [Route("hero/hero-xpulse-200-4v")]
        public IActionResult HeroXPulse2004V()
        {
            var bikeDetails = GetBikeDetails("Hero XPulse 200 4V");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroXPulse2004V.cshtml", bikeDetails);
        }
        [Route("hero/hero-xpulse-200t-4v")]
        public IActionResult HeroXPulse200T4V()
        {
            var bikeDetails = GetBikeDetails("Hero XPulse 200T 4V");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroXPulse200T4V.cshtml", bikeDetails);
        }
        [Route("hero/hero-karizma-xmr")]
        public IActionResult HeroKarizmaXMR()
        {
            var bikeDetails = GetBikeDetails("Hero Karizma XMR");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroKarizmaXMR.cshtml", bikeDetails);
        }
        [Route("hero/hero-mavrick-440")]
        public IActionResult HeroMavrick440()
        {
            var bikeDetails = GetBikeDetails("Hero Mavrick 440");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroMavrick440.cshtml", bikeDetails);
        }
        [Route("hero/hero-splendor-plus-xtec")]
        public IActionResult HeroSplendorPlusXTEC()
        {
            var bikeDetails = GetBikeDetails("Hero Splendor Plus XTEC");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroSplendorPlusXTEC.cshtml", bikeDetails);
        }
        [Route("hero/hero-hf-deluxe")]
        public IActionResult HeroHFDeluxe()
        {
            var bikeDetails = GetBikeDetails("Hero HF Deluxe");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroHFDeluxe.cshtml", bikeDetails);
        }
        [Route("hero/hero-super-splendor")]
        public IActionResult HeroSuperSplendor()
        {
            var bikeDetails = GetBikeDetails("Hero Super Splendor");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroSuperSplendor.cshtml", bikeDetails);
        }
        [Route("hero/hero-xtreme-160r")]
        public IActionResult HeroXtreme160R()
        {
            var bikeDetails = GetBikeDetails("Hero Xtreme 160R");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroXtreme160R.cshtml", bikeDetails);
        }
        [Route("hero/hero-glamour")]
        public IActionResult HeroGlamour()
        {
            var bikeDetails = GetBikeDetails("Hero Glamour");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroGlamour.cshtml", bikeDetails);
        }
        [Route("hero/hero-super-splendor-xtec")]
        public IActionResult HeroSuperSplendorXTEC()
        {
            var bikeDetails = GetBikeDetails("Hero Super Splendor XTEC");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroSuperSplendorXTEC.cshtml", bikeDetails);
        }
        [Route("hero/hero-pleasure-plus")]
        public IActionResult HeroPleasurePlus()
        {
            var bikeDetails = GetBikeDetails("Hero Pleasure Plus");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroPleasurePlus.cshtml", bikeDetails);
        }
        [Route("hero/hero-xoom-110")]
        public IActionResult HeroXoom110()
        {
            var bikeDetails = GetBikeDetails("Hero Xoom 110");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroXoom110.cshtml", bikeDetails);
        }
        [Route("hero/hero-destini-125")]
        public IActionResult HeroDestini125()
        {
            var bikeDetails = GetBikeDetails("Hero Destini 125");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroDestini125.cshtml", bikeDetails);
        }
        [Route("hero/hero-maestro-edge-125")]
        public IActionResult HeroMaestroEdge125()
        {
            var bikeDetails = GetBikeDetails("Hero Maestro Edge 125");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroMaestroEdge125.cshtml", bikeDetails);
        }
        [Route("hero/hero-destini-prime")]
        public IActionResult HeroDestiniPrime()
        {
            var bikeDetails = GetBikeDetails("Hero Destini Prime");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroDestiniPrime.cshtml", bikeDetails);
        }
        [Route("hero/hero-hf-100")]
        public IActionResult HeroHF100()
        {
            var bikeDetails = GetBikeDetails("Hero HF 100");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroHF100.cshtml", bikeDetails);
        }
        [Route("hero/hero-passion-plus")]
        public IActionResult HeroPASSIONPlus()
        {
            var bikeDetails = GetBikeDetails("Hero PASSION Plus");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroPASSIONPlus.cshtml", bikeDetails);
        }
        [Route("hero/hero-glamour-xtec")]
        public IActionResult HeroGLAMOURXTEC()
        {
            var bikeDetails = GetBikeDetails("Hero GLAMOUR XTEC");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroGLAMOURXTEC.cshtml", bikeDetails);
        }
        [Route("hero/hero-passion-xtec-110-cc")]
        public IActionResult HeroPASSIONXTEC110CC()
        {
            var bikeDetails = GetBikeDetails("Hero PASSION XTEC 110 CC");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroPASSIONXTEC110CC.cshtml", bikeDetails);
        }
        [Route("hero/hero-xtreme-200s-4v")]
        public IActionResult HeroXTREME200S4V()
        {
            var bikeDetails = GetBikeDetails("Hero XTREME 200S 4V");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroXTREME200S4V.cshtml", bikeDetails);
        }
        [Route("hero/hero-xtreme-160r-4v")]
        public IActionResult HeroXTREME160R4V()
        {
            var bikeDetails = GetBikeDetails("Hero XTREME 160R 4V");
            return View("~/Views/TwoWheeler/Brand/Hero/HeroXTREME160R4V.cshtml", bikeDetails);
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
