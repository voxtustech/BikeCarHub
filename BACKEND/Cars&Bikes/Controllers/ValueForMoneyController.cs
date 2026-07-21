using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers
{
    public class ValueForMoneyController : Controller
    {
        private readonly TwoWheelerDB _context;
        public ValueForMoneyController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allVFM = _context.ValueForMoney.OrderByDescending(m => m.Date).Take(100).ToList();
            ViewBag.allVFM = allVFM;
            return View();
        }
        [Route("value-for-money/skoda-kylaq-value-for-money-variant")]
        public IActionResult SkodaKylaq1()
        {
            var vfmDetails = GetVFMDetails("Skoda Kylaq");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("skoda-kylaq-features-and-specifications")]
        public IActionResult SkodaKylaq2()
        {
            var vfmDetails = GetVFMDetails("Skoda Kylaq");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/alto-k10-value-for-money-varient")]
        public IActionResult AltoK10_1()
        {
            var vfmDetails = GetVFMDetails("Alto K10: Value for Money Varient");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("alto-k10-features-and-specifications")]
        public IActionResult AltoK10_2()
        {
            var vfmDetails = GetVFMDetails("Alto K10: Value for Money Varient");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/kia-syros-value-for-money-varient")]
        public IActionResult KiaSyros_1()
        {
            var vfmDetails = GetVFMDetails("Kia Syros : Value for Money Varient");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }

        [Route("kia-syros-features-and-specifications")]
        public IActionResult KiaSyros_2()
        {
            var vfmDetails = GetVFMDetails("Kia Syros : Value for Money Varient");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/maruti-suzuki-swift-2025-the-value-for-money-variant")]
        public IActionResult MarutiSuzukiSwift2025_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Swift 2025: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-swift-2025-features-and-specifications")]
        public IActionResult MarutiSuzukiSwift2025_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Swift 2025: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/maruti-suzuki-wagonR-2025-the-value-for-money-variant")]
        public IActionResult MarutiSuzukiWagonR2025_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki WagonR 2025: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-wagonR-2025-features-and-specifications")]
        public IActionResult MarutiSuzukiWagonR2025_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki WagonR 2025: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/maruti-suzuki-dzire-2025-the-value-for-money-variant")]
        public IActionResult MarutiSuzukiDzire2025_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Dzire 2025: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-dzire-2025-features-and-specifications")]
        public IActionResult MarutiSuzukiDzire2025_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Dzire 2025: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/maruti-suzuki-ertiga-zXIO-the-value-for-money-variant")]
        public IActionResult MarutiSuzukiErtigaZXIO_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Ertiga ZXIO: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-ertiga-zXIO-features-and-specifications")]
        public IActionResult MarutiSuzukiErtigaZXIO_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Ertiga ZXIO: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/maruti-suzuki-brezza-the-value-for-money-variant")]
        public IActionResult MarutiSuzukiBrezza_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Brezza: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-brezza-features-and-specifications")]
        public IActionResult MarutiSuzukiBrezza_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Brezza: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/maruti-suzuki-celerio-the-value-for-money-variant")]
        public IActionResult MarutiSuzukiCelerio_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Celerio: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-celerio-features-and-specifications")]
        public IActionResult MarutiSuzukiCelerio_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Celerio: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/best-value-for-money-variant-of-the-maruti-suzuki-s-presso")]
        public IActionResult MarutiSuzukiSPresso_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki S-Presso: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-s-presso-features-and-specifications")]
        public IActionResult MarutiSuzukiSPresso_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki S-Presso: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/best-value-for-money-variant-of-maruti-suzuki-nexa-ignis")]
        public IActionResult MarutiSuzukiNexaIgnis_1()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Nexa Ignis: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("maruti-suzuki-nexa-ignis-features-and-specifications")]
        public IActionResult MarutiSuzukiNexaIgnis_2()
        {
            var vfmDetails = GetVFMDetails("Maruti Suzuki Nexa Ignis: The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/best-value-for-money-variant-of-tata-altroz-facelift")]
        public IActionResult TataAltrozFacelift_1()
        {
            var vfmDetails = GetVFMDetails("Tata Altroz Facelift : The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("tata-altroz-facelift-features-and-specifications")]
        public IActionResult TataAltrozFacelift_2()
        {
            var vfmDetails = GetVFMDetails("Tata Altroz Facelift : The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/best-value-for-money-variant-of-tata-punch")]
        public IActionResult TataPunch_1()
        {
            var vfmDetails = GetVFMDetails("Tata Punch : The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        [Route("value-for-money/best-value-for-money-variant-of-tata-tiago")]
        public IActionResult TataTiago_1()
        {
            var vfmDetails = GetVFMDetails("Tata Tiago : The Value-for-Money Variant");
            if (vfmDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View(vfmDetails);
        }
        private Cars_Bikes.Models.ValueForMoney GetVFMDetails(string vfmHeading)
        {
            var vfmItem = _context.ValueForMoney
                .FirstOrDefault(n => n.VFMHeading == vfmHeading);
            if (vfmItem == null)
            {
                // Handle the case where the bike is not found
                return null;
            }
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.AllBrand = Allbrand;
            return vfmItem;
        }
    }
}
