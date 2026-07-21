using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class YamahaController : Controller
    {
        private readonly TwoWheelerDB _context;
        public YamahaController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("yamaha/yamaha-r3")]
        public IActionResult YamahaR3()
        {
            var bikeDetails = GetBikeDetails("Yamaha R3");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaR3.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-r15m")]
        public IActionResult YamahaR15M()
        {
            var bikeDetails = GetBikeDetails("Yamaha R15M");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaR15M.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-r15v4")]
        public IActionResult YamahaR15V4()
        {
            var bikeDetails = GetBikeDetails("Yamaha R15V4");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaR15V4.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-r15s")]
        public IActionResult YamahaR15S()
        {
            var bikeDetails = GetBikeDetails("Yamaha R15S");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaR15S.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-mt-03")]
        public IActionResult YamahaMT03()
        {
            var bikeDetails = GetBikeDetails("Yamaha MT-03");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaMT03.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-mt-15-ver-2.0")]
        public IActionResult YamahaMT15Ver2Point0()
        {
            var bikeDetails = GetBikeDetails("Yamaha MT-15 Ver 2.0");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaMT15Ver2Point0.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-fz-s-fi-ver-4.0-dlx")]
        public IActionResult YamahaFZSFiVer4Point0DLX()
        {
            var bikeDetails = GetBikeDetails("Yamaha FZ-S Fi Ver 4.0 DLX");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaFZSFiVer4Point0DLX.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-fz-s-fi-ver-4.0")]
        public IActionResult YamahaFZSFiVer4Point0()
        {
            var bikeDetails = GetBikeDetails("Yamaha FZ-S Fi Ver 4.0");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaFZSFiVer4Point0.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-fz-s-fi-ver-3.0")]
        public IActionResult YamahaFZSFiVer3Point0()
        {
            var bikeDetails = GetBikeDetails("Yamaha FZ-S Fi Ver 3.0");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaFZSFiVer3Point0.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-fz-fi")]
        public IActionResult YamahaFZFI()
        {
            var bikeDetails = GetBikeDetails("Yamaha FZ-FI");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaFZFI.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-fz-x")]
        public IActionResult YamahaFZX()
        {
            var bikeDetails = GetBikeDetails("Yamaha FZ-X");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaFZX.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-aerox-155-version-s")]
        public IActionResult YamahaAerox155VersionS()
        {
            var bikeDetails = GetBikeDetails("Yamaha Aerox 155 Version S");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaAerox155VersionS.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-aerox-155")]
        public IActionResult YamahaAerox155()
        {
            var bikeDetails = GetBikeDetails("Yamaha Aerox 155");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaAerox155.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-rayzr-125-fi-street-rally")]
        public IActionResult YamahaRayZR125FiStreetRally()
        {
            var bikeDetails = GetBikeDetails("Yamaha RayZR 125 Fi Street Rally");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaRayZR125FiStreetRally.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-rayzr-125-fi")]
        public IActionResult YamahaRayZR125Fi()
        {
            var bikeDetails = GetBikeDetails("Yamaha RayZR 125 Fi");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaRayZR125Fi.cshtml", bikeDetails);
        }
        [Route("yamaha/yamaha-fascino-125-fi")]
        public IActionResult YamahaFascino125Fi()
        {
            var bikeDetails = GetBikeDetails("Yamaha Fascino 125 Fi");
            return View("~/Views/TwoWheeler/Brand/Yamaha/YamahaFascino125Fi.cshtml", bikeDetails);
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
