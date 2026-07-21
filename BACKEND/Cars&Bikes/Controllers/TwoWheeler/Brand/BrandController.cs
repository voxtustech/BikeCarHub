using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.Brand
{
    public class BrandController : Controller
    {
        private readonly TwoWheelerDB _context;
        public BrandController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("royal-enfield")]
        public IActionResult RoyalEnfield()
        {
            var brandDetails = GetBrandDetails("Royal Enfield");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Royal Enfield").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/RoyalEnfield.cshtml", brandDetails);
        }
        [Route("tvs")]
        public IActionResult TVS()
        {
            var brandDetails = GetBrandDetails("TVS");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "TVS").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/TVS.cshtml", brandDetails);
        }
        [Route("honda")]
        public IActionResult Honda()
        {
            var brandDetails = GetBrandDetails("Honda");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Honda").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Honda.cshtml", brandDetails);
        }
        [Route("hero")]
        public IActionResult Hero()
        {
            var brandDetails = GetBrandDetails("Hero");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Hero").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Hero.cshtml", brandDetails);
        }
        [Route("bajaj")]
        public IActionResult Bajaj()
        {
            var brandDetails = GetBrandDetails("Bajaj");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Bajaj").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Bajaj.cshtml", brandDetails);
        }
        [Route("ktm")]
        public IActionResult KTM()
        {
            var brandDetails = GetBrandDetails("KTM");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "KTM").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/KTM.cshtml", brandDetails);
        }
        [Route("yamaha")]
        public IActionResult Yamaha()
        {
            var brandDetails = GetBrandDetails("Yamaha");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Yamaha").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Yamaha.cshtml", brandDetails);
        }
        [Route("keeway")]
        public IActionResult Keeway()
        {
            var brandDetails = GetBrandDetails("Keeway");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Keeway").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Keeway.cshtml", brandDetails);
        }
        [Route("suzuki")]
        public IActionResult Suzuki()
        {
            var brandDetails = GetBrandDetails("Suzuki");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Suzuki").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Suzuki.cshtml", brandDetails);
        }
        [Route("aprilia")]
        public IActionResult Aprilia()
        {
            var brandDetails = GetBrandDetails("Aprilia");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Aprilia").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Aprilia.cshtml", brandDetails);
        }
        [Route("benelli")]
        public IActionResult Benelli()
        {
            var brandDetails = GetBrandDetails("Benelli");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Benelli").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Benelli.cshtml", brandDetails);
        }
        [Route("bmw")]
        public IActionResult BMW()
        {
            var brandDetails = GetBrandDetails("BMW");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "BMW").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/BMW.cshtml", brandDetails);
        }
        [Route("cf-moto")]
        public IActionResult CFMoto()
        {
            var brandDetails = GetBrandDetails("CF Moto");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "CF Moto").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/CFMoto.cshtml", brandDetails);
        }
        [Route("ducati")]
        public IActionResult Ducati()
        {
            var brandDetails = GetBrandDetails("Ducati");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Ducati").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Ducati.cshtml", brandDetails);
        }
        [Route("harley-davidson")]
        public IActionResult HarleyDavidson()
        {
            var brandDetails = GetBrandDetails("Harley Davidson");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Harley Davidson").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/HarleyDavidson.cshtml", brandDetails);
        }
        [Route("husqvarna")]
        public IActionResult Husqvarna()
        {
            var brandDetails = GetBrandDetails("Husqvarna");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Husqvarna").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Husqvarna.cshtml", brandDetails);
        }
        [Route("jawa")]
        public IActionResult Jawa()
        {
            var brandDetails = GetBrandDetails("Jawa");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Jawa").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Jawa.cshtml", brandDetails);
        }
        [Route("indian")]
        public IActionResult Indian()
        {
            var brandDetails = GetBrandDetails("Indian");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Indian").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Indian.cshtml", brandDetails);
        }
        [Route("moto-guzzi")]
        public IActionResult MotoGuzzi()
        {
            var brandDetails = GetBrandDetails("Moto Guzzi");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Moto Guzzi").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/MotoGuzzi.cshtml", brandDetails);
        }
        [Route("moto-morini")]
        public IActionResult MotoMorini()
        {
            var brandDetails = GetBrandDetails("Moto Morini");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Moto Morinih").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/MotoMorini.cshtml", brandDetails);
        }
        [Route("norton")]
        public IActionResult Norton()
        {
            var brandDetails = GetBrandDetails("Norton");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Norton").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Norton.cshtml", brandDetails);
        }
        [Route("triumph")]
        public IActionResult Triumph()
        {
            var brandDetails = GetBrandDetails("Triumph");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Triumph").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Triumph.cshtml", brandDetails);
        }
        [Route("yezdi")]
        public IActionResult Yezdi()
        {
            var brandDetails = GetBrandDetails("Yezdi");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Yezdi").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Yezdi.cshtml", brandDetails);
        }
        [Route("zontes")]
        public IActionResult Zontes()
        {
            var brandDetails = GetBrandDetails("Zontes");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Zontes").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Zontes.cshtml", brandDetails);
        }
        [Route("qj-motor")]
        public IActionResult QJMotor()
        {
            var brandDetails = GetBrandDetails("QJ Motor");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "QJ Motor").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/QJMotor.cshtml", brandDetails);
        }
        [Route("benda")]
        public IActionResult Benda()
        {
            var brandDetails = GetBrandDetails("Benda");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Benda").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Benda.cshtml", brandDetails);
        }
        [Route("bsa")]
        public IActionResult BSA()
        {
            var brandDetails = GetBrandDetails("BSA");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "BSA").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/BSA.cshtml", brandDetails);
        }
        [Route("kawasaki")]
        public IActionResult Kawasaki()
        {
            var brandDetails = GetBrandDetails("Kawasaki");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Kawasaki").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Kawasaki.cshtml", brandDetails);
        }
        [Route("ather-energy")]
        public IActionResult AtherEnergy()
        {
            var brandDetails = GetBrandDetails("Ather Energy");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Ather Energy").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/AtherEnergy.cshtml", brandDetails);
        }
        [Route("ola-electric")]
        public IActionResult OlaElectric()
        {
            var brandDetails = GetBrandDetails("Ola Electric");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Ola Electric").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/OlaElectric.cshtml", brandDetails);
        }
        [Route("revolt-motors")]
        public IActionResult RevoltMotors()
        {
            var brandDetails = GetBrandDetails("Revolt Motors");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Revolt Motors").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/RevoltMotors.cshtml", brandDetails);
        }
        [Route("simple-energy")]
        public IActionResult SimpleEnergy()
        {
            var brandDetails = GetBrandDetails("Simple Energy");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Simple Energy").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/SimpleEnergy.cshtml", brandDetails);
        }
        [Route("tork-motors")]
        public IActionResult TorkMotors()
        {
            var brandDetails = GetBrandDetails("Tork Motors");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Tork Motors").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/TorkMotors.cshtml", brandDetails);
        }
        [Route("bounce-infinity")]
        public IActionResult BounceInfinity()
        {
            var brandDetails = GetBrandDetails("Bounce Infinity");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Bounce Infinity").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/BounceInfinity.cshtml", brandDetails);
        }
        [Route("oben-electric")]
        public IActionResult ObenElectric()
        {
            var brandDetails = GetBrandDetails("Oben Electric");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Oben Electric").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/ObenElectric.cshtml", brandDetails);
        }
        [Route("pure-ev")]
        public IActionResult PUREEV()
        {
            var brandDetails = GetBrandDetails("PURE EV");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "PURE EV").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/PUREEV.cshtml", brandDetails);
        }
        [Route("ampere-vehicles")]
        public IActionResult AmpereVehicles()
        {
            var brandDetails = GetBrandDetails("Ampere Vehicles");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Ampere Vehicles").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/AmpereVehicles.cshtml", brandDetails);
        }
        [Route("okaya-ev")]
        public IActionResult OkayaEV()
        {
            var brandDetails = GetBrandDetails("Okaya EV");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Okaya EV").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/OkayaEV.cshtml", brandDetails);
        }
        [Route("kinetic-green")]
        public IActionResult KineticGreen()
        {
            var brandDetails = GetBrandDetails("Kinetic Green");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Kinetic Green").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/KineticGreen.cshtml", brandDetails);
        }
        [Route("evolet")]
        public IActionResult Evolet()
        {
            var brandDetails = GetBrandDetails("Evolet");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Evolet").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/Evolet.cshtml", brandDetails);
        }
        [Route("kabira-mobility")]
        public IActionResult KabiraMobility()
        {
            var brandDetails = GetBrandDetails("Kabira Mobility");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Kabira Mobility").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/KabiraMobility.cshtml", brandDetails);
        }
        [Route("detel-ev")]
        public IActionResult DetelEV()
        {
            var brandDetails = GetBrandDetails("Detel EV");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Detel EV").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/DetelEV.cshtml", brandDetails);
        }
        [Route("joy-e-bike")]
        public IActionResult JoyeBike()
        {
            var brandDetails = GetBrandDetails("Joy e-Bike");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Joy e-Bike").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/JoyeBike.cshtml", brandDetails);
        }
        [Route("ultraviolette-automotive")]
        public IActionResult UltravioletteAutomotive()
        {
            var brandDetails = GetBrandDetails("Ultraviolette Automotive");
            if (brandDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.BrandName == "Ultraviolette Automotive").ToList();
            ViewBag.Tag = tag;
            return View("~/Views/TwoWheeler/Brand/UltravioletteAutomotive.cshtml", brandDetails);
        }
        private IEnumerable<Cars_Bikes.Models.TwoWheeler> GetBrandDetails(string brandName)
        {
            
            return _context.Twowheelers
                .Where(n => n.TwoWheelerBrands.BrandName == brandName)
                .ToList();

        }
    }
}
