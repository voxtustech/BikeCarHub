using Cars_Bikes.Data;
using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars_Bikes.Controllers.TwoWheeler.LatestNews
{
    public class LatestNewsController : Controller
    {
        private readonly TwoWheelerDB _context;
        public LatestNewsController(TwoWheelerDB context)
        {
            _context = context;
        }
        [Route("LatestNews/Index")]
        public IActionResult Index()
        {
            
            var allLatestNews = _context.TWLatestNews.OrderByDescending(m => m.Date).Take(100).ToList();
            ViewBag.allLatestNews = allLatestNews;
            return View();
        }
        
        public IActionResult TWLatestNewsDetails(int id, string heading)
        {
            var newsItem = _context.TWLatestNews.FirstOrDefault(m => m.ImageURL == heading);
            if (newsItem == null)
            {
                return NotFound();
            }
            ViewBag.TWNews = newsItem;
            var allNews = _context.TWLatestNews.OrderByDescending(m => m.Date).Take(15).ToList();
            ViewBag.AllNews = allNews;
            var brand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = brand;
            return View("~/Views/TwoWheeler/LatestNews/TWLatestNewsDetails.cshtml");
        }
        //public IActionResult TWLatestNewsByBrand(int id)
        //{
        //    var newsbybrand = _context.TWLatestNews.Where(m => m.TwoWBrandId == id).ToList();
        //    ViewBag.newsbybrand = newsbybrand;
        //    return View("~/Views/TwoWheeler/LatestNews/TWLatestNewsByBrand.cshtml");
        //}
        //Single page for News
        [Route("latestnews/bajaj-freedom-125-cng")]
        public IActionResult Aug122024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Bajaj Freedom 125 CNG");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug122024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/new-royal-enfield-classic-350:price-expectation")]
        public IActionResult Aug122024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("New Royal Enfield Classic 350: Price Expectation");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug122024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/tata-curvv:upcoming-suv-coupe-set-to-shake-up-indian-auto-market")]
        public IActionResult Aug252024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Tata Curvv: Upcoming SUV Coupe Set to Shake Up Indian Auto Market");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug252024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/thar-roXX:new-variant-joins-the-iconic-Off-roader-lineup")]
        public IActionResult Aug252024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("Thar RoXX: New Variant Joins the Iconic Off-Roader Lineup");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug252024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/ola-electric-unveils-roadster:a-new-era-of-high-performance-electric-motorcycles")]
        public IActionResult Aug262024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Ola Electric Unveils Roadster: A New Era of High-Performance Electric Motorcycles");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug262024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/ola-electric-introduces-roadsterX:affordable-electric-motorcycle-with-impressive-range")]
        public IActionResult Aug262024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("Ola Electric Introduces Roadster X: Affordable Electric Motorcycle with Impressive Range");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug262024NewsDetails2.cshtml", newsDetails);
        }
        //[Route("latestnews/mg-car-discounts")]
        //public IActionResult Aug272024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("MG Car Discounts");
        //    //if (newsDetails == null)
        //    //{
        //    //    return NotFound(); // Return 404 if news item is not found
        //    //}
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug272024NewsDetails1.cshtml", newsDetails);
        //}
        [Route("latestnews/honda-unveils-affordable-shine:125-a-budget-friendly-commuter-under-₹1-lakh")]
        public IActionResult Aug282024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Honda Unveils Affordable Shine 125: A Budget-Friendly Commuter Under ₹1 Lakh");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found

            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug282024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/bajaj-introduces-two-affordable-bikes-under-₹1-lakh:platina-110-and-pulsar-125")]
        public IActionResult Aug292024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Bajaj Introduces Two Affordable Bikes Under ₹1 Lakh: Platina 110 and Pulsar 125");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found

            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug292024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/maserati-granTurismo-makes-its-debut-in-india-with-prices-starting-at-rs-2.72-crore")]
        public IActionResult Aug302024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Maserati GranTurismo Makes Its Debut in India with Prices Starting at Rs 2.72 Crore");
            if (newsDetails == null)
            {
                //return NotFound(); // Return 404 if news item is not found
                return RedirectToAction("Index", "Home");

            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Aug/Aug302024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/royal-enfield-classic-350-gets-a-fresh-update:new-model-launched-at-₹2-lakh")]
        public IActionResult Sep22024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Royal Enfield Classic 350 Gets a Fresh Update: New Model Launched at ₹2 Lakh");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep22024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/tata-motors-unveils-top-10-features-of-the-all-new-tata-curvv-2024")]
        public IActionResult Sep32024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Tata Motors Unveils Top 10 Features of the All-New Tata Curvv 2024");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep32024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/tvs-bajaj-and-hero-lead-august-sales-surpassing-ola-and-ather-in-august-month")]
        public IActionResult Sep32024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("TVS, Bajaj, and Hero Lead August Sales, Surpassing Ola and Ather in August month");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep32024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/jawa-42-fj-debuts-at-₹1.99-lakh:new-model-launched")]
        public IActionResult Sep52024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Jawa 42 FJ Debuts at ₹1.99 Lakh: New Model Launched");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep52024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/bajaj-freedom-125-achieves-5,000-sales-milestone-within-two-months-of-launch")]
        public IActionResult Sep62024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Bajaj Freedom 125 Achieves 5,000 Sales Milestone Within Two Months of Launch");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep62024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/hyundai-exter-s(o)-and-s-amt-introduced-in-india-with-new-sunroof-feature")]
        public IActionResult Sep92024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Hyundai Exter S(O)+ and S+ AMT Introduced in India with New Sunroof Feature");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep92024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/government-to-launch-fame-iii-scheme-to-further-boost-electric-mobility-initiatives")]
        public IActionResult Sep102024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Government to Launch FAME III Scheme to Further Boost Electric Mobility Initiatives");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep102024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/mg-windsor-ev-launches-in-india-today:key-features-and-expectations")]
        public IActionResult Sep112024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("MG Windsor EV Launches in India Today: Key Features and Expectations");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep112024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/demerits-of-the-hyundai-alcazar:a-closer-look-at-its-shortcomings")]
        public IActionResult Sep122024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Demerits of the Hyundai Alcazar: A Closer Look at Its Shortcomings");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep122024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/honda-set-to-launch-electric-scooter-in-india-by-march-2025")]
        public IActionResult Sep132024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Honda Set to Launch Electric Scooter in India by March 2025");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep132024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/jsw-mg-launches-mg-select-outlets-for-premium-vehicles-starting-2025")]
        public IActionResult Sep162024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("JSW MG Launches 'MG Select' Outlets for Premium Vehicles Starting 2025");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep162024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/kia-crnival-lunches-with-1,800-frst-day-bokings")]
        public IActionResult Sep182024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Kia Carnival Launches with 1,800+ First-Day Bookings");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep182024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/byd-emax-7-electric-mpv-set-to-launch-in-india-on-october-8")]
        public IActionResult Sep192024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("BYD eMAX 7 Electric MPV Set to Launch in India on October 8");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep192024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/tvs-unveils-new-variants-of-apache-rr-310:-a-fresh-take-on-performance-and-style")]
        public IActionResult Sep232024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("TVS Unveils New Variants of Apache RR 310: A Fresh Take on Performance and Style");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep232024NewsDetails1.cshtml", newsDetails);
        }
        //[Route("latestnews/best-indian-cars-under-₹8-lakh-on-road-price-(2024)")]
        //public IActionResult Sep232024NewsDetails2()
        //{
        //    var newsDetails = GetNewsDetails("Best Indian Cars Under ₹8 Lakh On-Road Price (2024)");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep232024NewsDetails2.cshtml", newsDetails);
        //}
        //[Route("latestnews/best-indian-cars-to-buy-under-₹10-lakh-on-road-price-(2024)")]
        //public IActionResult Sep242024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("Best Indian Cars to Buy Under ₹10 Lakh On-Road Price (2024)");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep242024NewsDetails1.cshtml", newsDetails);
        //}
        [Route("latestnews/tata-nexon-icng-debuts-in-india-at-₹8.99-lakh-promising-24-km/kg-mileage")]
        public IActionResult Sep252024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Tata Nexon iCNG Debuts in India at ₹8.99 Lakh, Promising 24 km/kg Mileage");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep252024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/top-5-indian-bikes-in-the-250cc-segment:-prices-specifications-&-features")]
        public IActionResult Sep262024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Top 5 Indian Bikes in the 250cc Segment: Prices, Specifications & Features");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep262024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/skoda-set-to-launch-elroq-electric-suv-on-october-1")]
        public IActionResult Sep272024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Skoda Set to Launch Elroq Electric SUV on October 1");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep272024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/2025-triumph-scrambler-400-x-set-to-debut-in-india-soon")]
        public IActionResult Sep302024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("2025 Triumph Scrambler 400 X Set to Debut in India Soon");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Sep/Sep302024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/bmw-m4-cs-set-to-launch-in-india-on-october-4")]
        public IActionResult Oct12024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("BMW M4 CS Set to Launch in India on October 4");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct12024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/bmw-set-to-unveil-all-new-x3-at-bharat-mobility-global-expo-2025")]
        public IActionResult Oct22024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("BMW Set to Unveil All-New X3 at Bharat Mobility Global Expo 2025");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct22024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/zelio-launches-eeva-zx-electric-scooter-in-india")]
        public IActionResult Oct32024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Zelio Launches Eeva ZX+ Electric Scooter in India");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct32024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/suzuki-unveils-gsx-8r-in-india-priced-at-₹9.25-lakh")]
        public IActionResult Oct42024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Suzuki Unveils GSX-8R in India Priced at ₹9.25 Lakh");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct42024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/exciting-october-2024-discounts-on-popular-indian-cars:maruti-hyundai-tata-and-more!")]
        public IActionResult Oct92024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Exciting October 2024 Discounts on Popular Indian Cars: Maruti, Hyundai, Tata, and More!");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct92024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/rolls-royce-ghost-series-ii-launched-with-fresh-design-and-enhanced-features")]
        public IActionResult Oct102024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Rolls-Royce Ghost Series II Launched with Fresh Design and Enhanced Features");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct102024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/ratan-tata's-legacy:the-architect-of-tata-group's-global-success")]
        public IActionResult Oct102024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("Ratan Tata's Legacy: The Architect of TATA Group's Global Success");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct102024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/yamaha-unveils-the-all-new-2025-yzf-r9:a-game-changer-in-the-supersport-segment")]
        public IActionResult Oct112024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Yamaha Unveils the All-New 2025 YZF-R9: A Game-Changer in the Supersport Segment");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct112024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/raptee-launches-hv-t-30-e-bike-at-₹2.39-lakh-with-ccs2-charging-capability")]
        public IActionResult Oct152024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Raptee Launches HV T 30 E-Bike at ₹2.39 Lakh with CCS2 Charging Capability");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct152024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/bajaj-prepares-to-unveil-new-pulsar-variant-likely-the-n125-by-tomorrow")]
        public IActionResult Oct162024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Bajaj Prepares to Unveil New Pulsar Variant, Likely the N125 By Tomorrow");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct162024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/diwali-bonanza-chennai-firm-presents-28-cars-including-mercedes-benz-to-employees-to-boost-morale")]
        public IActionResult Oct172024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Diwali Bonanza :-Chennai Firm Presents 28 Cars, Including Mercedes-Benz, to Employees to Boost Morale");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct172024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/tata-curvv-achieves-5-star-safety-rating-in-global-ncap-tests")]
        public IActionResult Oct182024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Tata Curvv Achieves 5-Star Safety Rating in Global NCAP Tests");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct182024NewsDetails1.cshtml", newsDetails);
        }
        //[Route("latestnews/here-are-the-best-indian-bikes-under-150cc-segments")]
        //public IActionResult Oct222024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("Here are the best Indian Bikes under 150cc segments.");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct222024NewsDetails1.cshtml", newsDetails);
        //}
        //[Route("latestnews/top-5-longest-range-electric-scooters-in-india-for-2024")]
        //public IActionResult Oct232024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("Top 5 Longest Range Electric Scooters in India for 2024");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct232024NewsDetails1.cshtml", newsDetails);
        //}
        //[Route("latestnews/news-best-cars-under-₹11-lakh-in-india-specific-variants-Offering-great-value-in-2024")]
        //public IActionResult Oct242024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("News: Best Cars Under ₹11 Lakh in India – Specific Variants Offering Great Value in 2024");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct242024NewsDetails1.cshtml", newsDetails);
        //}
        [Route("latestnews/kawasaki-klx-230-vs-hero-xpulse-200-4v—a-complete-specifications-features-and-cost-comparison-in-india")]
        public IActionResult Oct242024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("Kawasaki KLX 230 vs Hero Xpulse 200 4V — A Complete Specifications, Features, and Cost Comparison in India.");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct242024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/tvs-raider-igo-variant-launched:new-features-specifications-comparison-and-price-in-india")]
        public IActionResult Oct252024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("TVS Raider iGO Variant Launched: New Features, Specifications, Comparison, and Price in India.");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct252024NewsDetails1.cshtml", newsDetails);
        }
        //[Route("latestnews/top-5-best-selling-royal-enfield-bikes-in-india-(2024)")]
        //public IActionResult Oct282024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("Top 5 Best-Selling Royal Enfield Bikes in India (2024)");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct282024NewsDetails1.cshtml", newsDetails);
        //}
        [Route("latestnews/indian-government-mandates-isi-certified-helmets-and-promotes-biker-safety-gear-through-subsidies")]
        public IActionResult Oct292024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Indian Government Mandates ISI-Certified Helmets and Promotes Biker Safety Gear Through Subsidies");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Oct/Oct292024NewsDetails1.cshtml", newsDetails);
        }
        //[Route("latestnews/top-5-adventure-bikes-for-indian-terrain:specifications-features-and-costs-in-india")]
        //public IActionResult Nov12024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("Top 5 Adventure Bikes for Indian Terrain: Specifications, Features, and Costs in India");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov12024NewsDetails1.cshtml", newsDetails);
        //}
        [Route("latestnews/royal-enfield-bear-650-to-launch-tomorrow:price-specs-revealed")]
        public IActionResult Nov42024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Royal Enfield Bear 650 to Launch Tomorrow: Price & Specs Revealed");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov42024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/maruti-suzuki-unveils-the-all-new-2024-swift-dzire-with-advanced-features-and-enhanced-performance")]
        public IActionResult Nov42024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("Maruti Suzuki Unveils the All-New 2024 Swift Dzire with Advanced Features and Enhanced Performance");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov42024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/royal-enfield-unveils-flying-flea-c6-ev-brand-for-electric-bikes")]
        public IActionResult Nov52024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Royal Enfield Unveils 'Flying Flea C6' EV Brand for Electric Bikes");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov52024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/ktm-390-adventure-india-launch-anticipated-on-november-14")]
        public IActionResult Nov52024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("KTM 390 Adventure India Launch Anticipated on November 14");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov52024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/hero-maverick-440-unveiled-with-new-features-at-eicma-2024")]
        public IActionResult Nov72024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Hero Maverick 440 Unveiled with New Features at EICMA 2024");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov72024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/launching-an-all-new-suv-designed-for-indias-roads-and-lifestyles")]
        public IActionResult Nov72024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("Launching an All-New SUV Designed for India’s Roads and Lifestyles");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov72024NewsDetails2.cshtml", newsDetails);
        }
        //[Route("latestnews/top-5-bikes-under-2-lakh-in-india-for-performance-style-and-value")]
        //public IActionResult Nov82024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("Top 5 Bikes Under 2 Lakh in India for Performance, Style, and Value");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov82024NewsDetails1.cshtml", newsDetails);
        //}
        //[Route("latestnews/top-five-selling-bikes-in-india-november-2024-overview")]
        //public IActionResult Nov112024NewsDetails1()
        //{
        //    var newsDetails = GetNewsDetails("Top Five Selling Bikes in India: November 2024 Overview");
        //    if (newsDetails == null)
        //    {
        //        return NotFound(); // Return 404 if news item is not found
        //    }
        //    return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov112024NewsDetails1.cshtml", newsDetails);
        //}
        [Route("latestnews/hero-karizma-xmr-210-unveiled-at-eicma-2024-with-enhanced-specs-and-features")]
        public IActionResult Nov112024NewsDetails2()
        {
            var newsDetails = GetNewsDetails("Hero Karizma XMR 210 Unveiled at EICMA 2024 with Enhanced Specs and Features");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov112024NewsDetails2.cshtml", newsDetails);
        }
        [Route("latestnews/honda-gold-wing-recall-in-india")]
        public IActionResult Nov132024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Honda Gold Wing Recall in India");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov132024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/brixton-motorcycles-to-debut-in-india-on-november-18-key-details-revealed")]
        public IActionResult Nov142024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Brixton Motorcycles to Debut in India on November 18: Key Details Revealed");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov142024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/tvs-apache-rtr-160-4v-updated-with-usd-forks-and-new-features")]
        public IActionResult Nov192024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("TVS Apache RTR 160 4V Updated with USD Forks and New Features");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov192024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/royal-enfield-reveals-the-all-new-goan-classic-350-bobber")]
        public IActionResult Nov212024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Royal Enfield Reveals the All-New Goan Classic 350 Bobber");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov212024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/kawasaki-launches-2025-ninja-zx-4r-in-india-at-₹8.79-lakh")]
        public IActionResult Nov222024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Kawasaki Launches 2025 Ninja ZX-4R in India at ₹8.79 Lakh");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov222024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/suzuki-unveils-the-all-new-v-strom-800de-adventure-motorcycle")]
        public IActionResult Nov282024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Suzuki Unveils the All-New V-Strom 800DE Adventure Motorcycle");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov282024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/honda-unveils-activa-e-and-qc1-electric-scooters-in-india-details-on-range-features-and-pricing")]
        public IActionResult Nov292024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Honda Unveils Activa E and QC1 Electric Scooters in India: Details on Range, Features, and Pricing");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Nov/Nov292024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/ktm-250-duke-price-slashed-by-₹20,000-now-₹2.25-lakh")]
        public IActionResult Dec22024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("KTM 250 Duke Price Slashed by ₹20,000: Now ₹2.25 Lakh");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Dec/Dec22024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/bajaj-freedom-125-cng-sees-price-drop-new-affordable-pricing-announced")]
        public IActionResult Dec52024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Bajaj Freedom 125 CNG Sees Price Drop: New Affordable Pricing Announced");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Dec/Dec52024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/triumph-speed-t4-receives-₹18,000-discount-for-limited-time")]
        public IActionResult Dec162024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Triumph Speed T4 Receives ₹18,000 Discount for Limited Time");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Dec/Dec162024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/latest-updates-in-the-automotive-industry")]
        public IActionResult Dec192024NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Latest Updates in the Automotive Industry");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2024/Dec/Dec192024NewsDetails1.cshtml", newsDetails);
        }
        [Route("latestnews/upcoming-mg-cyberster-the-electric-convertible-revolution")]
        public IActionResult Jan62025NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Upcoming MG Cyberster: The Electric Convertible Revolution");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2025/Jan/Jan62025NewsDetails1.cshtml", newsDetails);
        }
    
        [Route("latestnews/exploring-the-future-the-all-new-hyundai-creta-ev")]
        public IActionResult Jan102025NewsDetails1()
        {
            var newsDetails = GetNewsDetails("Exploring the Future: The All-New Hyundai Creta EV");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2025/Jan/Jan102025NewsDetails1.cshtml", newsDetails);
        }

        [Route("latestnews/tvs-jupiter-cng-scooter-launched-with-140-mile-range")]
        public IActionResult Jan212025NewsDetails1()
        {
            var newsDetails = GetNewsDetails("TVS Jupiter CNG Scooter Launched with 140-Mile Range");
            if (newsDetails == null)
            {
                return NotFound(); // Return 404 if news item is not found
            }
            return View("~/Views/TwoWheeler/LatestNews/2025/Jan/Jan212025NewsDetails1.cshtml", newsDetails);
        }


        private Cars_Bikes.Models.TWLatestNews GetNewsDetails(string newsHeading)
        {
            var newsItem = _context.TWLatestNews
                .FirstOrDefault(n => n.NewsHeading == newsHeading);
            if (newsItem == null)
            {
                // Handle the case where the bike is not found
                return null;
            }
            //var newsItem = _context.TWLatestNews.Where(n => n.NewsHeading == newsHeading).ToList();
            var allNews = _context.TWLatestNews.OrderByDescending(m => m.Date).Take(20).ToList();
            ViewBag.AllNews = allNews;
            var brand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = brand;
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.AllBrand = Allbrand;
            return newsItem;
        }
    }
}
