using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly TwoWheelerDB _context;
        public AboutUsController(TwoWheelerDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Models.TWOrFWContactUs obj)
        {
            _context.TWOrFWContactUs.Add(obj);
            _context.SaveChanges();
             TempData["success"] = "Your message has been sent. Thank you!";
             return RedirectToAction("Index", "AboutUs");
        }
    }
}
