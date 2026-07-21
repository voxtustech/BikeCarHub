using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class HondaController : Controller
    {
        private readonly TwoWheelerDB _context;
        public HondaController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("honda/honda-shine-100")]
        public IActionResult HondaShine100()
        {
            var bikeDetails = GetBikeDetails("Honda Shine 100");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaShine100.cshtml", bikeDetails);
        }
        [Route("honda/honda-cb350")]
        public IActionResult HondaCB350()
        {
            var bikeDetails = GetBikeDetails("Honda CB350");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaCB350.cshtml", bikeDetails);
        }
        [Route("honda/honda-cb350-rs")]
        public IActionResult HondaCB350RS()
        {
            var bikeDetails = GetBikeDetails("Honda CB350 RS");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaCB350RS.cshtml", bikeDetails);
        }
        [Route("honda/honda-hornet-2.0")]
        public IActionResult HondaHornet()
        {
            var bikeDetails = GetBikeDetails("Honda Hornet 2.0");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaHornet.cshtml", bikeDetails);
        }
        [Route("honda/honda-unicorn")]
        public IActionResult HondaUnicorn()
        {
            var bikeDetails = GetBikeDetails("Honda Unicorn");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaUnicorn.cshtml", bikeDetails);
        }
        [Route("honda/honda-x-blade")]
        public IActionResult HondaXBlade()
        {
            var bikeDetails = GetBikeDetails("Honda X-Blade");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaXBlade.cshtml", bikeDetails);
        }
        [Route("honda/honda-sp-125")]
        public IActionResult HondaSP125()
        {
            var bikeDetails = GetBikeDetails("Honda SP 125");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaSP125.cshtml", bikeDetails);
        }
        [Route("honda/honda-livo")]
        public IActionResult HondaLivo()
        {
            var bikeDetails = GetBikeDetails("Honda Livo");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaLivo.cshtml", bikeDetails);
        }
        [Route("honda/honda-cd-110-dream")]
        public IActionResult HondaCD110Dream()
        {
            var bikeDetails = GetBikeDetails("Honda CD 110 Dream");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaCD110Dream.cshtml", bikeDetails);
        }
        [Route("honda/honda-shine-125")]
        public IActionResult HondaShine125()
        {
            var bikeDetails = GetBikeDetails("Honda Shine 125");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaShine125.cshtml", bikeDetails);
        }
        [Route("honda/honda-cb200x")]
        public IActionResult HondaCB200X()
        {
            var bikeDetails = GetBikeDetails("Honda CB200X");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaCB200X.cshtml", bikeDetails);
        }
        
        [Route("honda/honda-nx500")]
        public IActionResult HondaNX500()
        {
            var bikeDetails = GetBikeDetails("Honda NX500");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaNX500.cshtml", bikeDetails);
        }
        [Route("honda/honda-crf1100l-africa-twin")]
        public IActionResult HondaCRF1100LAfricaTwin()
        {
            var bikeDetails = GetBikeDetails("Honda CRF1100L Africa Twin");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaCRF1100LAfricaTwin.cshtml", bikeDetails);
        }
        [Route("honda/honda-xl750-transalp")]
        public IActionResult HondaXL750Transalp()
        {
            var bikeDetails = GetBikeDetails("Honda XL750 Transalp");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaXL750Transalp.cshtml", bikeDetails);
        }
        [Route("honda/honda-cb1000r-plus")]
        public IActionResult HondaCB1000RPlus()
        {
            var bikeDetails = GetBikeDetails("Honda CB1000R Plus");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaCB1000RPlus.cshtml", bikeDetails);
        }
        [Route("honda/honda-gold-wing")]
        public IActionResult HondaGoldWing()
        {
            var bikeDetails = GetBikeDetails("Honda Gold Wing");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaGoldWing.cshtml", bikeDetails);
        }
        [Route("honda/honda-activa-6g")]
        public IActionResult HondaActiva6G()
        {
            var bikeDetails = GetBikeDetails("Honda Activa 6G");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaActiva6G.cshtml", bikeDetails);
        }
        [Route("honda/honda-activa-125")]
        public IActionResult HondaActiva125()
        {
            var bikeDetails = GetBikeDetails("Honda Activa 125");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaActiva125.cshtml", bikeDetails);
        }
        [Route("honda/honda-dio")]
        public IActionResult HondaDio()
        {
            var bikeDetails = GetBikeDetails("Honda Dio");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaDio.cshtml", bikeDetails);
        }
        [Route("honda/honda-dio-125")]
        public IActionResult HondaDio125()
        {
            var bikeDetails = GetBikeDetails("Honda Dio 125");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaDio125.cshtml", bikeDetails);
        }
        [Route("honda/honda-activa-e")]
        public IActionResult HondaActivaE()
        {
            var bikeDetails = GetBikeDetails("Honda Activa E");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaActivaE.cshtml", bikeDetails);
        }
        [Route("honda/honda-qc1")]
        public IActionResult HondaQC1()
        {
            var bikeDetails = GetBikeDetails("Honda QC1");
            return View("~/Views/TwoWheeler/Brand/Honda/HondaQC1.cshtml", bikeDetails);
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
