using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Cars_Bikes.Models;
using Cars_Bikes.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Cars_Bikes.Controllers
{
    public class TWBrandsController : Controller
    {
        private readonly TwoWheelerDB _context;
        public TWBrandsController(TwoWheelerDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        // Show the form
        public IActionResult Create()
        {
            return View();
        }

        // Handle the form POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TwoWheelerBrand brand)
        {
            Debug.WriteLine("Saving data");
            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    Debug.WriteLine($"Field: {state.Key} — Error: {state.Value.Errors[0].ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                Debug.WriteLine("Saving context and date");
                brand.CreatedDateTime = DateTime.Now; // Save creation time
                Debug.WriteLine("Saving date");
                _context.TwowheelerBrands.Add(brand);
                Debug.WriteLine("Saving brand");
                _context.SaveChanges();
                Debug.WriteLine("Saving to datbase");
                return RedirectToAction("Success"); // Redirect after success
            }
            Debug.WriteLine("Saving data failed ");
            return View(brand);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult ManageTwoWheelerData()
        {
            ViewBag.BrandList = _context.Twowheelers
                .Include(x => x.TwoWheelerBrands)
                .Select(x => new SelectListItem
                {
                    Value = x.TwoWheelerId.ToString(),
                    Text = $"{x.TwoWheelerBrands.BrandName} - {x.TwoWheelerName}"
                }).ToList();

            return View();
        }
        public IActionResult ManageTwoWheelerData1()
        {
            ViewBag.BrandList = _context.Twowheelers
                .Include(x => x.TwoWheelerBrands)
                .Select(x => new SelectListItem
                {
                    Value = x.TwoWheelerId.ToString(),
                    Text = $"{x.TwoWheelerBrands.BrandName} - {x.TwoWheelerName}"
                }).ToList();

            return View();
        }


        [HttpGet]
        public JsonResult GetVariants(int twoWheelerId)
        {
            var variants = _context.TWVarients
                .Where(v => v.TwoWheelerId == twoWheelerId)
                //.Select(v => new { v.TWVarientId, v.Varients })
                .Select(v => new { tWVarientId = v.TWVarientId, varients = v.Varients })
                .ToList();

            return Json(variants);
        }
        

        public IActionResult GetByVariant(int id)
        {
            //var spec = _context.TWSpec.FirstOrDefault(x => x.TWVarientId == id);
            //Console.WriteLine("GetVariants called with brandId: " + id);
            //Console.WriteLine("Spec:"+spec);
            //return PartialView("~/Views/Shared/_SpecPartial.cshtml", spec);
            try
            {
                Console.WriteLine("GetByVariant called with variantId: " + id);

                var spec = _context.TWSpec.FirstOrDefault(x => x.TWVarientId == id);

                if (spec == null)
                {
                    Console.WriteLine("No spec found for variantId: " + id);
                }

                return PartialView("EditTWSpec", spec);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetByVariant: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
        public IActionResult GetFeaturesByVariant(int id)
        {
            var feature = _context.TWFeatures.FirstOrDefault(x => x.TWVarientId == id);
            return PartialView("EditTWSpec", feature);
        }

        public IActionResult GetUnderpinningsByVariant(int id)
        {
            var perf = _context.TWUnderpinnings.FirstOrDefault(x => x.TWVarientId == id);
            return PartialView("_PerformancePartial", perf);
        }

    }
}
