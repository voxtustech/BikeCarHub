using Microsoft.AspNetCore.Mvc;
using Cars_Bikes.Models;
using System.Linq;
using Google;
using Cars_Bikes.Data;
namespace Cars_Bikes.ViewComponents
{
    public class LatestNewsViewComponent : ViewComponent
    {
        private readonly TwoWheelerDB _context;
        private readonly FourWheelerDB _fourwheeler;

        public LatestNewsViewComponent(TwoWheelerDB context, FourWheelerDB fourWheeler)
        {
            _context = context;
            _fourwheeler = fourWheeler;
        }

        public IViewComponentResult Invoke()
        {
            var latestNews = _context.TWLatestNews
                                .OrderByDescending(m => m.Date)
                                .Skip(1)
                                .Take(10)
                                .ToList();

            return View(latestNews);
        }
    }
}
