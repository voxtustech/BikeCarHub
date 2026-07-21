using Cars_Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cars_Bikes.Data;
using System.Xml.Linq;
using System.Linq;
using System.Net;

namespace Cars_Bikes.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly TwoWheelerDB _context;
        private readonly FourWheelerDB _fourwheeler;

        public HomeController(ILogger<HomeController> logger, TwoWheelerDB context, FourWheelerDB fourWheeler)
        {
            _logger = logger;
            _context = context;
            _fourwheeler = fourWheeler;
        }
        public IActionResult Index()
        {
            var TWList = _context.TwowheelerBrands.OrderBy(tw => tw.BrandName).ToList();
            ViewBag.TWLists = new SelectList(TWList, "TWBrandId", "BrandName");
            var MList = _context.Twowheelers.Select(t => t.Type)
                                            .Distinct().ToList();
            ViewBag.Mlists = new SelectList(MList);
            //var TWName = _twowheeler.TwoWheelers.ToList();
            //ViewBag.TWNames = new SelectList(TWName,"Id", "TwoWheelerName");
            //var Models = new List<TwoWheeler>();
            //ViewBag.ModelNames = new SelectList(Models, "Company", "TwoWheelerName");
            //var FourWheelerBrand = _fourwheeler.FourWheelerBrands.ToList();
            //ViewBag.FourwheelerName = new SelectList(FourWheelerBrand, "Id", "FourWheelerBrandName");
            var TWNews = _context.TWLatestNews.OrderByDescending(m => m.Date).Take(5).ToList();
            ViewBag.TWNews = TWNews;
            //var FWNews = _fourwheeler.FWLatestNews.OrderByDescending(m => m.FWLatestNewsId).Take(5).ToList();
            //ViewBag.FWNews = FWNews;
            var UpcomingBike = _context.UpcomingBikes.OrderByDescending(m => m.FilterLaunchDate).Take(5).ToList();
            ViewBag.Upcomingbike = UpcomingBike;
            var Blogs = _context.Blogs.OrderByDescending(m => m.Date).Take(10).ToList();
            ViewBag.Blogs = Blogs;
            var VFM = _context.ValueForMoney.OrderByDescending(m => m.Date).Take(10).ToList();
            ViewBag.VFM = VFM;
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.AllBrand = Allbrand;


            return View();
        }
        [HttpGet]
        public JsonResult GetModelsByBrand(int Id)
        {
            var ListModel = _context.Twowheelers.Where(u => u.TwoWBrandId == Id).Select(u => new
            {
                u.TwoWheelerId,
                u.TwoWheelerName
            }).OrderBy(tw => tw.TwoWheelerName).ToList();
            return Json(ListModel);
        }
        public IActionResult TWBrandDetails(int brandId,int modelId)
        {
            var brand = _context.Twowheelers
                                .Where(b => b.TwoWheelerBrands.TWBrandId == brandId)
                                //.FirstOrDefault();
                                .ToList();
            var twoWheelers = _context.Twowheelers
                                      .Where(t => t.TwoWheelerBrands.TWBrandId == brandId && t.TwoWheelerId == modelId)
                                      .ToList();
            ViewBag.TwoWheelers = twoWheelers;
            var Allbrand = _context.TwowheelerBrands.ToList();
            ViewBag.Brand = Allbrand;
            var tag = _context.TwowheelerBrands.Where(t => t.TWBrandId == brandId).ToList();
            ViewBag.Tag = tag;
            //var twDetails = _context.Twowheelers.Where(t=> t.TwoWheelerId == modelId).ToList();
            //ViewBag.twDetails = twDetails;
            return View("TWBrandDetails",brand);
        }
        [HttpGet]
        public JsonResult GetTWSpecByVarients(int varientId)
        {
            var specs = _context.TWSpec.Include(s => s.TwoWheeler).Where(s => s.TWVarientId == varientId).ToList();
            var features = _context.TWFeatures.Where(t => t.TWVarientId == varientId).ToList();
            //Item4
            var safety = _context.TWSafety.Where(t => t.TWVarientId == varientId).ToList();
            //Item5
            var mileageAndPerformance = _context.TWMileageAndPerformances.Where(t => t.TWVarientId == varientId).ToList();
            //Item6
            var engine = _context.TWEngineAndTransmissions.Where(t => t.TWVarientId == varientId).ToList();
            //Item7
            //var chassisAndSuspension = _context.TWChassisAndSuspensions.Where(t => t.TWVarientId == varientId).ToList();
            //Item8
            var dimensionsAndCapacity = _context.TWDimensionsAndCapacities.Where(t => t.TWVarientId == varientId).ToList();
            //Item9
            var electricals = _context.TWElectricals.Where(t => t.TWVarientId == varientId).ToList();
            //Item10
            var tyresAndBrakes = _context.TWTyresAndBrakes.Where(t => t.TWVarientId == varientId).ToList();
            //Item11
            var motorAndBattery = _context.TWMotorAndBatteries.Where(t => t.TWVarientId == varientId).ToList();
            //Item12
            var underpinning = _context.TWUnderpinnings.Where(t => t.TWVarientId == varientId).ToList();
            //Item13
            var charging = _context.TWChargings.Where(t => t.TWVarientId == varientId).ToList();
            var imageColor = _context.TWImageColorPrices.Include(s => s.TwoWheeler).Where(t => t.TWVarientId == varientId).ToList();

            return Json(new { specs, features, safety, mileageAndPerformance, engine, dimensionsAndCapacity, electricals, tyresAndBrakes, motorAndBattery, underpinning, charging, imageColor });
        }
        public ActionResult TwoWheelerDetails(int brandId, int modelId,int? varientId, string brandName, string twName )
        {
            //Item1
            var twoWheelers = _context.Twowheelers
                                      .Where(t => t.TwoWheelerBrands.TWBrandId == brandId && t.TwoWheelerId == modelId && t.Brand ==brandName && t.TwoWheelerName==twName)
                                      .ToList();
            var varient =_context.TWVarients.Where(t => t.TwoWheelerId == modelId).ToList();
            ViewBag.varient = new SelectList(varient, "TWVarientId", "Varients");
            //if (varientId == null && varient.Any())
            //{
            //    varientId = varient.First().TWVarientId;
            //}
            //ViewBag.SelectedVarientId = varientId;
            //var specs = _context.TWSpec.Where(t => t.TWVarientId == varientId && t.TwoWheelerId == modelId).ToList();
            //ViewBag.Specs = specs;
            //var features = _context.TWFeatures.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item4
            //var safety = _context.TWSafety.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item5
            //var mileageAndPerformance = _context.TWMileageAndPerformances.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item6
            //var engineAndTransmission = _context.TWEngineAndTransmissions.Where(t => t.TWVarientId == varientId).ToList();
            ////Item7
            //var chassisAndSuspension = _context.TWChassisAndSuspensions.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item8
            //var dimensionsAndCapacity = _context.TWDimensionsAndCapacities.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item9
            //var electricals = _context.TWElectricals.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item10
            //var tyresAndBrakes = _context.TWTyresAndBrakes.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item11
            //var motorAndBatteries = _context.TWMotorAndBatteries.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item12
            //var underpinnings = _context.TWUnderpinnings.Where(t => t.TwoWheelerId == modelId).ToList();
            ////Item13
            //var chargings = _context.TWChargings.Where(t => t.TwoWheelerId == modelId).ToList();
            ////var tuple = new Tuple<List<TwoWheeler>, List<TWSpec>, List<TWFeatures>, List<TWSafety>, List<TWMileageAndPerformance>, List<TWEngineAndTransmission>, List<TWChassisAndSuspension>, List<TWDimensionsAndCapacity>,List<TWTyresAndBrakes>>
            ////    (twoWheelers, spec, features, safety, mileageandperformance, engineandtransmission, chassisandsuspension, dimensionsandcapacity, tyresandbrakes);
            ////return View("TwoWheelerDetails", tuple);

            ViewBag.TwoWheelers = twoWheelers;
            ViewBag.TwoWheelerId = modelId;
            ////ViewBag.Specs = spec;
            //ViewBag.Features = features;
            //ViewBag.Safety = safety;
            //ViewBag.MileageAndPerformance = mileageAndPerformance;
            //ViewBag.EngineAndTransmission = engineAndTransmission;
            //ViewBag.ChassisAndSuspension = chassisAndSuspension;
            //ViewBag.DimensionsAndCapacity = dimensionsAndCapacity;
            //ViewBag.Electricals = electricals;
            //ViewBag.TyresAndBrakes = tyresAndBrakes;
            //ViewBag.MotorAndBatteries = motorAndBatteries;
            //ViewBag.Underpinnings = underpinnings;
            //ViewBag.Chargings = chargings;

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewsLetter(Models.NewsLetter obj)
        {
            if (ModelState.IsValid)
            {
                _context.NewsLetters.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Your message has been sent. Thank you!";
                // Redirect to avoid resubmission on refresh
                return Redirect(Request.Headers["Referer"].ToString());
            }
            // If model state is not valid, return the same view with the model to display validation errors
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [HttpGet]
        public JsonResult GetTwoWheelerNames(string term)
        {
            //var suggestions = _context.Twowheelers
                //.Where(tw => tw.TwoWheelerName.Contains(term) && tw.IsActive == true)
                //.Select(tw => tw.TwoWheelerName)
                //.Take(10) // limit results
                //.ToList();
            //return Json(suggestions);
            var twoWheelerSuggestions = _context.Twowheelers
           .Where(tw => tw.TwoWheelerName.Contains(term) && tw.IsActive == true)
           .Select(tw => new {
               Label = tw.TwoWheelerName,
               Type = "TwoWheeler"
           }).ToList();
            var compareSuggestions = _context.CompareItems
       .Where(ci => ci.Topic.Contains(term))
       .Select(ci => new {
           Label = ci.Topic,
           Type = "Compare"
       }).ToList();

            var combined = twoWheelerSuggestions
                .Concat(compareSuggestions)
                //.Union(compareSuggestions)
                .Take(20)
                .ToList();
            return Json(combined);
           
        }
        [HttpGet]
        public JsonResult GetTwoWheelerDetailsByName(string twoWheelerName)
        {
            var twoWheeler = _context.Twowheelers
                .Where(t => t.TwoWheelerName == twoWheelerName && t.IsActive == true)
                .Select(t => new
                {
                    brandId = t.TwoWheelerBrands.TWBrandId,
                    modelId = t.TwoWheelerId,
                    brandName = t.Brand.ToLower().Replace(" ", "-"), // Slugify brandName
                    twName = t.TwoWheelerName.ToLower().Replace(" ", "-") // Slugify twName
                })
                .FirstOrDefault();

            if (twoWheeler != null)
            {
                return Json(twoWheeler);
            }

            return Json(null); // Return null or handle not found case
        }

        public IActionResult TWCompare()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult BestBikeFinder(string budget, string typeFilter)
        {
            var bikes = _context.Twowheelers.AsQueryable();

            if (!string.IsNullOrEmpty(budget))
            {
                int maxBudget = int.Parse(budget);

                bikes = bikes.Where(x => x.BasePrice <= maxBudget);
            }

            if (!string.IsNullOrEmpty(typeFilter))
            {
                bikes = bikes.Where(x => x.Type == typeFilter);
            }

            return View(bikes.ToList());
        }
        public IActionResult Details(int id)
        {
            var bike = _context.Twowheelers
                .FirstOrDefault(x => x.TwoWheelerId == id);

            if (bike == null)
            {
                return NotFound();
            }

            var reviews = _context.Reviews
                .Where(r => r.TwoWheelerID == id)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            ViewBag.Reviews = reviews;

            ViewBag.ReviewCount = reviews.Count;

            ViewBag.AverageRating =
                reviews.Any()
                ? reviews.Average(r => r.Rating)
                : 0;

            return View(bike);
        }
    }
}