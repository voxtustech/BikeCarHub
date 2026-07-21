using Microsoft.AspNetCore.Mvc;
using Cars_Bikes.Models; 
using System.Linq;
using Google;
using Cars_Bikes.Data;
namespace Cars_Bikes.ViewComponents
{
    public class AllBlogViewComponent : ViewComponent
    {
        private readonly TwoWheelerDB _context;
        private readonly FourWheelerDB _fourwheeler;

        public AllBlogViewComponent(TwoWheelerDB context, FourWheelerDB fourWheeler)
        {
            _context = context;
            _fourwheeler = fourWheeler;
        }

        public IViewComponentResult Invoke()
        {
            var blogs = _context.Blogs
                                .OrderByDescending(m => m.Date)
                                .Skip(1)
                                .Take(10)
                                .ToList();

            return View(blogs); 
        }
    }
}
