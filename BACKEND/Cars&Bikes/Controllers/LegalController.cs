using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers
{
    public class LegalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("privacy-policy")]
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        [Route("terms-and-conditions")]
        public IActionResult TermsandConditions()
        {
            return View();
        }
        [Route("disclaimer")]
        public IActionResult Disclaimer()
        {
            return View();
        }
    }
}
