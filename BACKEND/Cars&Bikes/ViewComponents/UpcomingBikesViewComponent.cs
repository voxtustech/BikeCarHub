using Microsoft.AspNetCore.Mvc;
using Cars_Bikes.Models;
using System.Linq;
using Google;
using Cars_Bikes.Data;
namespace Cars_Bikes.ViewComponents
{
    public class UpcomingBikesViewComponent : ViewComponent
    {
        private readonly TwoWheelerDB _context;
        private readonly FourWheelerDB _fourwheeler;

        public UpcomingBikesViewComponent(TwoWheelerDB context, FourWheelerDB fourWheeler)
        {
            _context = context;
            _fourwheeler = fourWheeler;
        }

        public IViewComponentResult Invoke()
        {
            var upcomingBikes = _context.UpcomingBikes
                                        .OrderByDescending(b => b.FilterLaunchDate)
                                        .Take(5)
                                        .ToList();

            return View(upcomingBikes); 
        }
    }
}
