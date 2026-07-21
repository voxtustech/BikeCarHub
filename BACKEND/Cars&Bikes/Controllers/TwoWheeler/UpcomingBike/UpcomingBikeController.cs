using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.UpcomingBike
{
    public class UpcomingBikeController : Controller
    {
        private readonly TwoWheelerDB _context;
        public UpcomingBikeController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var upcomingBikes = _context.UpcomingBikes.ToList();
            ViewBag.upcomingBikes = upcomingBikes;
            return View();
        }
        public IActionResult TWUpcomingBikeDetails(int id)
        {
            var upcomingbike = _context.UpcomingBikes.Where(m => m.UpcomingBikeId == id).ToList();
            ViewBag.upcomingbike = upcomingbike;
            var allupcomingbike = _context.UpcomingBikes.OrderByDescending(m => m.FilterLaunchDate).Take(10).ToList();
            ViewBag.allupcomingbike = allupcomingbike;
            return View("~/Views/TwoWheeler/UpcomingBike/TWUpcomingBikeDetails.cshtml");
        }
        [Route("upcoming-bike/bsa-goldstar-650")]
        public IActionResult Aug2024UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("BSA GoldStar 650");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Aug2024UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/triumph-daytona-660")]
        public IActionResult Aug2024UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Triumph Daytona 660");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Aug2024UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yezdi-streetfighter")]
        public IActionResult Aug2024UpcomingBikeDetails3()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yezdi Streetfighter");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Aug2024UpcomingBikeDetails3.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yezdi-roadking")]
        public IActionResult Aug2024UpcomingBikeDetails4()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yezdi Roadking");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Aug2024UpcomingBikeDetails4.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/husqvarna-vitpilen-401")]
        public IActionResult Sep2024UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Husqvarna Vitpilen 401");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Sep2024UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/suzuki-gsx-8r")]
        public IActionResult Sep2024UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Suzuki GSX-8R");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Sep2024UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/bmw-f900-gs")]
        public IActionResult Sep2024UpcomingBikeDetails3()
        {
            var upcomingDetails = GetUpcomingBikeDetails("BMW F900 GS");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Sep2024UpcomingBikeDetails3.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/kawasaki-versys-x-300")]
        public IActionResult Sep2024UpcomingBikeDetails4()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Kawasaki Versys-X 300");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Sep2024UpcomingBikeDetails4.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/suzuki-burgman-street-electric")]
        public IActionResult Sep2024UpcomingBikeDetails5()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Suzuki Burgman Street Electric");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Sep2024UpcomingBikeDetails5.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yamaha-nmax-155")]
        public IActionResult Sep2024UpcomingBikeDetails6()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yamaha Nmax 155");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Sep2024UpcomingBikeDetails6.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/hero-xoom-160")]
        public IActionResult Nov2024UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Hero Xoom 160");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Nov2024UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/oben-rorr-ez")]
        public IActionResult Nov2024UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Oben Rorr EZ");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2024/Nov2024UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/hero-vida-vX2")]
        public IActionResult May2025UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Hero Vida VX2");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/May2025UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yezdi-adventure")]
        public IActionResult May2025UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yezdi Adventure");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/May2025UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/husqvarna-vitpilen")]
        public IActionResult May2025UpcomingBikeDetails3()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Husqvarna Vitpilen 401");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/May2025UpcomingBikeDetails3.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/benelli-tNT600i")]
        public IActionResult Sept2025UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Benelli TNT600i");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Sept2025UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/triumph-speed-400-tracker")]
        public IActionResult Sept2025UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Triumph Speed 400 Tracker");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Sept2025UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/new-yamaha-mt-09")]
        public IActionResult Oct2025UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("New Yamaha MT-09");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/the-yezdi-streetfighter")]
        public IActionResult Oct2025UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("The Yezdi Streetfighter");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/benelli-752s")]
        public IActionResult Oct2025UpcomingBikeDetails3()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Benelli 752S");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails3.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/brixton-crossfire-500")]
        public IActionResult Oct2025UpcomingBikeDetails4()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Brixton Crossfire 500");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails4.cshtml", upcomingDetails);
        }

        [Route("upcoming-bike/honda-cB500F")]
        public IActionResult Oct2025UpcomingBikeDetails5()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Honda CB500F");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails5.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/ola-adventure")]
        public IActionResult Oct2025UpcomingBikeDetails6()
        {
            var upcomingDetails = GetUpcomingBikeDetails("OLA Adventure");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails6.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/ktm-125-duke")]
        public IActionResult Oct2025UpcomingBikeDetails7()
        {
            var upcomingDetails = GetUpcomingBikeDetails("KTM 125 Duke");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails7.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/ktm-390-smc-r")]
        public IActionResult Oct2025UpcomingBikeDetails8()
        {
            var upcomingDetails = GetUpcomingBikeDetails("KTM 390 SMC R");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails8.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/suzuki-gSX-8S")]
        public IActionResult Oct2025UpcomingBikeDetails9()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Suzuki GSX-8S");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails9.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/suzuki-burgman-electric")]
        public IActionResult Oct2025UpcomingBikeDetails10()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Suzuki Burgman Electric");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails10.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/ola-diamondhead")]
        public IActionResult Oct2025UpcomingBikeDetails11()
        {
            var upcomingDetails = GetUpcomingBikeDetails("OLA Diamondhead");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails11.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/ola-cruiser")]
        public IActionResult Oct2025UpcomingBikeDetails12()
        {
            var upcomingDetails = GetUpcomingBikeDetails("OLA Cruiser");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Oct2025UpcomingBikeDetails12.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yamaha-xSR-155")]
        public IActionResult Nov2025UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yamaha XSR 155");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Nov2025UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yamaha-nmax155")]
        public IActionResult Nov2025UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yamaha NMax155");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Nov2025UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/ducati-panigale-v2-2025")]
        public IActionResult Nov2025UpcomingBikeDetails3()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Ducati Panigale V2 [2025]");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Nov2025UpcomingBikeDetails3.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/tvs-apache-rtx-300")]
        public IActionResult Nov2025UpcomingBikeDetails4()
        {
            var upcomingDetails = GetUpcomingBikeDetails("TVS Apache RTX 300");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Nov2025UpcomingBikeDetails4.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yamaha-mt07")]
        public IActionResult Nov2025UpcomingBikeDetails5()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yamaha MT-07");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Nov2025UpcomingBikeDetails5.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/norton-v4")]
        public IActionResult Nov2025UpcomingBikeDetails6()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Norton V4");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Nov2025UpcomingBikeDetails6.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/royal-enfield-scrambler-450")]
        public IActionResult Dec2025UpcomingBikeDetails1()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Royal Enfield Scrambler 450");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails1.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/kTM-390-adventureR")]
        public IActionResult Dec2025UpcomingBikeDetails2()
        {
            var upcomingDetails = GetUpcomingBikeDetails("KTM 390 Adventure R");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails2.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/cFMoto-450-mt")]
        public IActionResult Dec2025UpcomingBikeDetails3()
        {
            var upcomingDetails = GetUpcomingBikeDetails("CFMoto 450 MT");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails3.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/bsa-scrambler-650")]
        public IActionResult Dec2025UpcomingBikeDetails4()
        {
            var upcomingDetails = GetUpcomingBikeDetails("BSA Scrambler 650");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails4.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/brixton-crossfire-500-december2025")]
        public IActionResult Dec2025UpcomingBikeDetails5()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Brixton Crossfire 500 December2025");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails5.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/bmw-r-1300R")]
        public IActionResult Dec2025UpcomingBikeDetails6()
        {
            var upcomingDetails = GetUpcomingBikeDetails("BMW R 1300 R");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails6.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/bmw-f-450GS")]
        public IActionResult Dec2025UpcomingBikeDetails7()
        {
            var upcomingDetails = GetUpcomingBikeDetails("BMW F 450 GS");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails7.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/benelli-leoncino-800")]
        public IActionResult Dec2025UpcomingBikeDetails8()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Benelli Leoncino 800");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails8.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/ducati-multistrada-v2")]
        public IActionResult Dec2025UpcomingBikeDetails9()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Ducati Multistrada V2");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails9.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/hero-karizma-xMR-250")]
        public IActionResult Dec2025UpcomingBikeDetails10()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Hero Karizma XMR 250");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails10.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/hero-mavrick-440")]
        public IActionResult Dec2025UpcomingBikeDetails11()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Hero Mavrick 440");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails11.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/honda-cBR500R")]
        public IActionResult Dec2025UpcomingBikeDetails12()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Honda CBR500R");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails12.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/indian-fTR-1200")]
        public IActionResult Dec2025UpcomingBikeDetails13()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Indian FTR 1200");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails13.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/tVS-xL-eV")]
        public IActionResult Dec2025UpcomingBikeDetails14()
        {
            var upcomingDetails = GetUpcomingBikeDetails("TVS XL EV");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails14.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/royal-enfield-himalayan-750")]
        public IActionResult Dec2025UpcomingBikeDetails15()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Royal Enfield Himalayan 750");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails15.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/triumph-tiger-sport-800")]
        public IActionResult Dec2025UpcomingBikeDetails16()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Triumph Tiger Sport 800");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails16.cshtml", upcomingDetails);
        }
        [Route("upcoming-bike/yamaha-yZF-r7")]
        public IActionResult Dec2025UpcomingBikeDetails17()
        {
            var upcomingDetails = GetUpcomingBikeDetails("Yamaha YZF-R7");
            if (upcomingDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/UpcomingBike/2025/Dec2025UpcomingBikeDetails17.cshtml", upcomingDetails);
        }
        private Cars_Bikes.Models.UpcomingBike GetUpcomingBikeDetails(string upcomingBikeName)
        {
            var upcomingItem = _context.UpcomingBikes
                .FirstOrDefault(n => n.UpcomingBikeName == upcomingBikeName);
            if (upcomingItem == null)
            {
                // Handle the case where the bike is not found
                return null;
            }
            var allupcomingbike = _context.UpcomingBikes.OrderByDescending(m => m.FilterLaunchDate).Take(8).ToList();
            ViewBag.allupcomingbike = allupcomingbike;
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.AllBrand = Allbrand;
            return upcomingItem;
        }
    }
}
