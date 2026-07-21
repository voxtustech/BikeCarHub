using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class BajajController : Controller
    {
        private readonly TwoWheelerDB _context;
        public BajajController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [Route("bajaj/bajaj-pulsar-150")]
        public IActionResult BajajPulsar150()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar 150");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsar150.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-ns200")]
        public IActionResult BajajPulsarNS200()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar NS200");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarNS200.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-220-f")]
        public IActionResult BajajPulsar220F()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar 220 F");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsar220F.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-avenger-cruise-220")]
        public IActionResult BajajAvengerCruise220()
        {
            var bikeDetails = GetBikeDetails("Bajaj Avenger Cruise 220");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajAvengerCruise220.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-rs200")]
        public IActionResult BajajPulsarRS200()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar RS200");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarRS200.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-ns160")]
        public IActionResult BajajPulsarNS160()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar NS160");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarNS160.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-ns400z")]
        public IActionResult BajajPulsarNS400Z()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar NS400Z");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarNS400Z.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-n250")]
        public IActionResult BajajPulsarN250()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar N250");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarN250.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-n150")]
        public IActionResult BajajPulsarN150()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar N150");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarN150.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-n160")]
        public IActionResult BajajPulsarN160()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar N160");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarN160.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-ns125")]
        public IActionResult BajajPulsarNS125()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar NS125");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsarNS125.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-pulsar-125")]
        public IActionResult BajajPulsar125()
        {
            var bikeDetails = GetBikeDetails("Bajaj Pulsar 125");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPulsar125.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-dominar-400")]
        public IActionResult BajajDominar400()
        {
            var bikeDetails = GetBikeDetails("Bajaj Dominar 400");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajDominar400.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-dominar-250")]
        public IActionResult BajajDominar250()
        {
            var bikeDetails = GetBikeDetails("Bajaj Dominar 250");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajDominar250.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-avenger-160-street")]
        public IActionResult BajajAvenger160Street()
        {
            var bikeDetails = GetBikeDetails("Bajaj Avenger 160 Street");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajAvenger160Street.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-avenger-220-street")]
        public IActionResult BajajAvenger220Street()
        {
            var bikeDetails = GetBikeDetails("Bajaj Avenger 220 Street");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajAvenger220Street.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-platina-110")]
        public IActionResult BajajPlatina110()
        {
            var bikeDetails = GetBikeDetails("Bajaj Platina 110");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPlatina110.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-platina-100")]
        public IActionResult BajajPlatina100()
        {
            var bikeDetails = GetBikeDetails("Bajaj Platina 100");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajPlatina100.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-ct-125x")]
        public IActionResult BajajCT125X()
        {
            var bikeDetails = GetBikeDetails("Bajaj CT 125X");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajCT125X.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-ct-110x")]
        public IActionResult BajajCT110X()
        {
            var bikeDetails = GetBikeDetails("Bajaj CT 110X");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajCT110X.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-chetak-3501")]
        public IActionResult BajajChetak3501()
        {
            var bikeDetails = GetBikeDetails("Bajaj Chetak 3501");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajChetak3501.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-chetak-3502")]
        public IActionResult BajajChetak3502()
        {
            var bikeDetails = GetBikeDetails("Bajaj Chetak 3502");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajChetak3502.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-chetak-2903")]
        public IActionResult BajajChetak2903()
        {
            var bikeDetails = GetBikeDetails("Bajaj Chetak 2903");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajChetak2903.cshtml", bikeDetails);
        }
        [Route("bajaj/bajaj-chetak-3202")]
        public IActionResult BajajChetak3202()
        {
            var bikeDetails = GetBikeDetails("Bajaj Chetak 3202");
            return View("~/Views/TwoWheeler/Brand/Bajaj/BajajChetak3202.cshtml", bikeDetails);
        }
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
        //[HttpGet]
        //public JsonResult GetTWSpec(int varientId)
        //{
        //    var specs = _context.TWSpec.Include(s => s.TwoWheeler).Where(s => s.TWVarientId == varientId).ToList();

        //    return Json(specs);
        //}
        //public async Task<IActionResult> GetTWSpec(int variantId)
        //{
        //    var spec = await _context.TWSpec
        //        .FirstOrDefaultAsync(s => s.TWVarientId == variantId);

        //    if (spec == null)
        //    {
        //        return NotFound();
        //    }

        //    return Json(spec);
        //}
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
