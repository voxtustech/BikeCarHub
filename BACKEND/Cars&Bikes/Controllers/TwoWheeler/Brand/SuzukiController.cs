using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class SuzukiController : Controller
    {
        private readonly TwoWheelerDB _context;
        public SuzukiController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("suzuki/suzuki-access-125")]
        public IActionResult SuzukiAccess125()
        {
            var bikeDetails = GetBikeDetails("Suzuki Access 125");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiAccess125.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-burgman-street")]
        public IActionResult SuzukiBurgmanStreet()
        {
            var bikeDetails = GetBikeDetails("Suzuki Burgman Street");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiBurgmanStreet.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-burgman-street-ex")]
        public IActionResult SuzukiBurgmanStreetEX()
        {
            var bikeDetails = GetBikeDetails("Suzuki Burgman Street EX");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiBurgmanStreetEX.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-avenis-125")]
        public IActionResult SuzukiAvenis125()
        {
            var bikeDetails = GetBikeDetails("Suzuki Avenis 125");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiAvenis125.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-gixxer")]
        public IActionResult SuzukiGixxer()
        {
            var bikeDetails = GetBikeDetails("Suzuki Gixxer");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiGixxer.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-gixxer-sf")]
        public IActionResult SuzukiGixxerSF()
        {
            var bikeDetails = GetBikeDetails("Suzuki Gixxer SF");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiGixxerSF.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-gixxer-250")]
        public IActionResult SuzukiGixxer250()
        {
            var bikeDetails = GetBikeDetails("Suzuki Gixxer 250");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiGixxer250.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-gixxer-sf-250")]
        public IActionResult SuzukiGixxerSF250()
        {
            var bikeDetails = GetBikeDetails("Suzuki Gixxer SF 250");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiGixxerSF250.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-v-strom-sx")]
        public IActionResult SuzukiVStromSX()
        {
            var bikeDetails = GetBikeDetails("Suzuki V-Strom SX");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiVStromSX.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-v-strom-800de")]
        public IActionResult SuzukiVSTROM800DE()
        {
            var bikeDetails = GetBikeDetails("Suzuki V-STROM 800DE");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiVSTROM800DE.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-katana")]
        public IActionResult SuzukiKATANA()
        {
            var bikeDetails = GetBikeDetails("Suzuki KATANA");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiKATANA.cshtml", bikeDetails);
        }
        [Route("suzuki/suzuki-hayabusa")]
        public IActionResult SuzukiHayabusa()
        {
            var bikeDetails = GetBikeDetails("Suzuki Hayabusa");
            return View("~/Views/TwoWheeler/Brand/Suzuki/SuzukiHayabusa.cshtml", bikeDetails);
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
