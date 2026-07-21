using Microsoft.AspNetCore.Mvc;

namespace Cars_Bikes.Controllers
{
    public class EMICalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("emi-calculator")]
        public IActionResult EmiCalculator()
        {
            
            return View();

                }
    }
}
