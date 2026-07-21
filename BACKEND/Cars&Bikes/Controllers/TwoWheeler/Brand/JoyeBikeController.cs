using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class JoyeBikeController : Controller
    {
        private readonly TwoWheelerDB _context;
        public JoyeBikeController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("joy-e-bike/mihos")]
        public IActionResult Mihos()
        {
            var bikeDetails = GetBikeDetails("Mihos");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/Mihos.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/gen-next-nanu-plus")]
        public IActionResult GenNextNanuPlus()
        {
            var bikeDetails = GetBikeDetails("Gen-Next Nanu Plus");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/GenNextNanuPlus.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/hurricane")]
        public IActionResult Hurricane()
        {
            var bikeDetails = GetBikeDetails("Hurricane");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/Hurricane.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/thunderbolt")]
        public IActionResult Thunderbolt()
        {
            var bikeDetails = GetBikeDetails("Thunderbolt");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/Thunderbolt.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/beast")]
        public IActionResult Beast()
        {
            var bikeDetails = GetBikeDetails("Beast");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/Beast.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/wolf-eco")]
        public IActionResult WolfEco()
        {
            var bikeDetails = GetBikeDetails("Wolf Eco");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/WolfEco.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/gen-next-nanu-eco")]
        public IActionResult GenNextNanuEco()
        {
            var bikeDetails = GetBikeDetails("Gen-Next Nanu Eco");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/GenNextNanuEco.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/wolf")]
        public IActionResult Wolf()
        {
            var bikeDetails = GetBikeDetails("Wolf");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/Wolf.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/gen-next-nanu")]
        public IActionResult GenNextNanu()
        {
            var bikeDetails = GetBikeDetails("Gen-Next Nanu");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/GenNextNanu.cshtml", bikeDetails);
        }
        [Route("joy-e-bike/glob")]
        public IActionResult Glob()
        {
            var bikeDetails = GetBikeDetails("Glob");
            return View("~/Views/TwoWheeler/Brand/JoyeBike/Glob.cshtml", bikeDetails);
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
            var engineAndTransmission = _context.TWEVEngineAndTransmissions
                .Where(e => e.TWVarientId == variantId)
                .Select(e => new
                {
                    e.NumOfBattries,
                    e.CoolingSystem,
                    e.MotorPower,
                    e.RangeEcoMode,
                    e.RangeNormalMode,
                    e.RangeSportsMode,
                    e.Starting,
                    e.MotorIPRating
                })
                .FirstOrDefault();

            var features = _context.TWEVFeatures
                .Where(f => f.TWVarientId == variantId)
                .Select(f => new
                {
                    f.InstrumentConsole,
                    f.BluetoothConnectivity,
                    f.Navigation,
                    f.CallSMSAlerts,
                    f.RoadsideAssistance,
                    f.AntiTheftAlarm,
                    f.USBChargingPort,
                    f.MusicControl,
                    f.OTA,
                    f.Speedometer,
                    f.Tripmeter,
                    f.Odometer,
                    f.AdditionalFeaturesOfVariant,
                    f.SeatType,
                    f.Clock,
                    f.PassengerFootrest,
                    f.CarryHook,
                    f.UnderseatStorage,
                    f.ChargerOutput,
                    f.RegenerativeBraking,
                    f.HillHold,
                    f.KeylessIgnition
                })
                .FirstOrDefault();

            var safety = _context.TWEVSafety
                .Where(s => s.TWVarientId == variantId)
                .Select(s => new
                {
                    s.BrakingType,
                    s.ChargingPoint,
                    s.FastCharging,
                    s.MobileApplication,
                    s.InternetConnectivity,
                    s.OperatingSystem,
                    s.Processor,
                    s.Gradeability,
                    s.ServiceDueIndicator,
                    s.RidingModes,
                    s.Display,
                    s.SwitchableABS,
                    s.EBS,
                    s.SeatOpeningSwitch
                })
                .FirstOrDefault();

            var chassisAndSuspension = _context.TWEVChassisAndSuspensions
                .Where(s => s.TWVarientId == variantId)
                .Select(s => new
                {
                    s.BodyType
                })
                .FirstOrDefault();

            var dimensionsAndCapacity = _context.TWEVDimensionsAndCapacities
                .Where(dc => dc.TWVarientId == variantId)
                .Select(dc => new
                {
                    dc.Width,
                    dc.Length,
                    dc.Height,
                    dc.SaddleHeight,
                    dc.GroundClearance,
                    dc.Wheelbase,
                    dc.KerbWeight,
                    dc.AdditionalStorage
                })
                .FirstOrDefault();

            var electricals = _context.TWEVElectricals
                .Where(e => e.TWVarientId == variantId)
                .Select(e => new
                {
                    e.Headlight,
                    e.TailLight,
                    e.TurnSignalLamp,
                    e.LEDTailLights,
                    e.LowBatteryIndicator
                })
                .FirstOrDefault();

            var tyresAndBrakes = _context.TWEVTyresAndBrakes
                .Where(tb => tb.TWVarientId == variantId)
                .Select(tb => new
                {
                    tb.FrontBrakeDiameter,
                    tb.RearBrakeDiameter,
                    tb.FrontTyrePressureRider,
                    tb.FrontTyrePressureRiderAndPillion,
                    tb.RearTyrePressureRider,
                    tb.RearTyrePressureRiderAndPillion
                })
                .FirstOrDefault();

            var performances = _context.TWEVPerformances
                .Where(p => p.TWVarientId == variantId)
                .Select(p => new
                {
                    p.ScooterSpeed,
                    p.ZeroTo40Kmphsec,
                    p.TopSpeed,
                    p.ZeroTo100Kmphsec
                })
                .FirstOrDefault();

            var motorAndBattery = _context.TWEVMotorAndBatteries
                .Where(mb => mb.TWVarientId == variantId)
                .Select(mb => new
                {
                    mb.MotorType,
                    mb.TorqueMotor,
                    mb.PeakPower,
                    mb.BatteryType,
                    mb.BatteryCapacity,
                    mb.BatteryWarranty,
                    mb.WaterProofRating,
                    mb.ReverseAssist,
                    mb.Transmission
                })
                .FirstOrDefault();

            var ranges = _context.TWEVRanges
                .Where(r => r.TWVarientId == variantId)
                .Select(r => new
                {
                    r.ClaimedRange
                })
                .FirstOrDefault();

            var underpinning = _context.TWEVUnderpinnings
                .Where(u => u.TWVarientId == variantId)
                .Select(u => new
                {
                    u.SuspensionFront,
                    u.SuspensionRear,
                    u.BrakesFront,
                    u.BrakesRear,
                    u.ABS,
                    u.TyreSize,
                    u.WheelSize,
                    u.WheelType,
                    u.Frame,
                    u.TubelessTyre
                })
                .FirstOrDefault();

            var charging = _context.TWEVChargings
                .Where(c => c.TWVarientId == variantId)
                .Select(c => new
                {
                    c.ChargingAtHome,
                    c.ChargingAtChargingStation,
                    c.ChargingTimeZeroTo80Percent,
                    c.ChargingTimeZeroTo100Percent,
                    c.ChargingNetworkBatterySwappingNetwork
                })
                .FirstOrDefault();

            var appfeatures = _context.TWEVAppFeatures
                .Where(af => af.TWVarientId == variantId)
                .Select(af => new
                {
                    af.ChargingStationLocate,
                    af.Geofencing,
                    af.AntiTheftAlarm,
                    af.CallsAndMessaging,
                    af.NavigationAssis,
                    af.LowBatteryAlert
                })
                .FirstOrDefault();

            return Json(new
            {
                engineAndTransmission,
                features,
                safety,
                chassisAndSuspension,
                dimensionsAndCapacity,
                electricals,
                tyresAndBrakes,
                performances,
                motorAndBattery,
                ranges,
                underpinning,
                charging,
                appfeatures
            });
        }
    }
}
