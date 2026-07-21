using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class BMWController : Controller
    {
        private readonly TwoWheelerDB _context;
        public BMWController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("bmw/bmw-g-310-r")]
        public IActionResult BMWG310R()
        {
            var bikeDetails = GetBikeDetails("BMW G 310 R");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWG310R.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-g-310-gs")]
        public IActionResult BMWG310GS()
        {
            var bikeDetails = GetBikeDetails("BMW G 310 GS");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWG310GS.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-g-310-rr")]
        public IActionResult BMWG310RR()
        {
            var bikeDetails = GetBikeDetails("BMW G 310 RR");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWG310RR.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-f-850-gs")]
        public IActionResult BMWF850GS()
        {
            var bikeDetails = GetBikeDetails("BMW F 850 GS");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWF850GS.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-f-850-gs-adventure")]
        public IActionResult BMWF850GSAdventure()
        {
            var bikeDetails = GetBikeDetails("BMW F 850 GS Adventure");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWF850GSAdventure.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-f-900-xr")]
        public IActionResult BMWF900XR()
        {
            var bikeDetails = GetBikeDetails("BMW F 900 XR");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWF900XR.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-s-1000-r")]
        public IActionResult BMWS1000R()
        {
            var bikeDetails = GetBikeDetails("BMW S 1000 R");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWS1000R.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-s-1000-rr")]
        public IActionResult BMWS1000RR()
        {
            var bikeDetails = GetBikeDetails("BMW S 1000 RR");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWS1000RR.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-s-1000-xr")]
        public IActionResult BMWS1000XR()
        {
            var bikeDetails = GetBikeDetails("BMW S 1000 XR");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWS1000XR.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-1250-gs")]
        public IActionResult BMWR1250GS()
        {
            var bikeDetails = GetBikeDetails("BMW R 1250 GS");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR1250GS.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-1250-gs-adventure")]
        public IActionResult BMWR1250GSAdventure()
        {
            var bikeDetails = GetBikeDetails("BMW R 1250 GS Adventure");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR1250GSAdventure.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-1250-rt")]
        public IActionResult BMWR1250RT()
        {
            var bikeDetails = GetBikeDetails("BMW R 1250 RT");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR1250RT.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-18")]
        public IActionResult BMWR18()
        {
            var bikeDetails = GetBikeDetails("BMW R 18");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR18.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-18-transcontinental")]
        public IActionResult BMWR18Transcontinental()
        {
            var bikeDetails = GetBikeDetails("BMW R 18 Transcontinental");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR18Transcontinental.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-k-1600-b")]
        public IActionResult BMWK1600B()
        {
            var bikeDetails = GetBikeDetails("BMW K 1600 B");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWK1600B.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-k-1600-grand-america")]
        public IActionResult BMWK1600GrandAmerica()
        {
            var bikeDetails = GetBikeDetails("BMW K 1600 Grand America");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWK1600GrandAmerica.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-k-1600-gtl")]
        public IActionResult BMWK1600GTL()
        {
            var bikeDetails = GetBikeDetails("BMW K 1600 GTL");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWK1600GTL.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-m-1000-rr")]
        public IActionResult BMWM1000RR()
        {
            var bikeDetails = GetBikeDetails("BMW M 1000 RR");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWM1000RR.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-m-1000-xr")]
        public IActionResult BMWM1000XR()
        {
            var bikeDetails = GetBikeDetails("BMW M 1000 XR");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWM1000XR.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-c-400-gt")]
        public IActionResult BMWC400GT()
        {
            var bikeDetails = GetBikeDetails("BMW C 400 GT");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWC400GT.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-1300-gs")]
        public IActionResult BMWR1300GS()
        {
            var bikeDetails = GetBikeDetails("BMW R 1300 GS");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR1300GS.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-12-nine-t")]
        public IActionResult BMWR12nineT()
        {
            var bikeDetails = GetBikeDetails("BMW R 12 nine T");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR12nineT.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-r-12")]
        public IActionResult BMWR12()
        {
            var bikeDetails = GetBikeDetails("BMW R 12");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWR12.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-f-900-gs")]
        public IActionResult BMWF900GS()
        {
            var bikeDetails = GetBikeDetails("BMW F 900 GS");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWF900GS.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-f-900-gs-adventure")]
        public IActionResult BMWF900GSAdventure()
        {
            var bikeDetails = GetBikeDetails("BMW F 900 GS Adventure");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWF900GSAdventure.cshtml", bikeDetails);
        }
        [Route("bmw/bmw-m-1000-r")]
        public IActionResult BMWM1000R()
        {
            var bikeDetails = GetBikeDetails("BMW M 1000 R");
            return View("~/Views/TwoWheeler/Brand/BMW/BMWM1000R.cshtml", bikeDetails);
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
