using Cars_Bikes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly TwoWheelerDB _context;
        public ContactUsController(TwoWheelerDB context)
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
            //_context.ContactUs.Add(obj);
            //_context.SaveChanges();
            //TempData["success"] = "Your message has been sent. Thank you!";
            ////return RedirectToAction("Index", "ContactUs");
            //return View(obj);
            if (ModelState.IsValid)
            {
                _context.TWOrFWContactUs.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Your message has been sent. Thank you!";
                // Redirect to avoid resubmission on refresh
                return RedirectToAction("Index", "ContactUs");
            }
            // If model state is not valid, return the same view with the model to display validation errors
            return View(obj);
        }
    }
}
