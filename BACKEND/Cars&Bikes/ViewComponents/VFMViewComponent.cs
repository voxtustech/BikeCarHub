using Microsoft.AspNetCore.Mvc;
using Cars_Bikes.Models;
using System.Linq;
using Google;
using Cars_Bikes.Data;
namespace Cars_Bikes.ViewComponents
{
    public class VFMViewComponent : ViewComponent
    {
        private readonly TwoWheelerDB _context;
        private readonly FourWheelerDB _fourwheeler;

        public VFMViewComponent(TwoWheelerDB context, FourWheelerDB fourWheeler)
        {
            _context = context;
            _fourwheeler = fourWheeler;
        }

        public IViewComponentResult Invoke()
        {
            var vfm = _context.ValueForMoney
                                        .OrderByDescending(m => m.Date)
                                        .Take(5)
                                        .ToList();

            return View(vfm);
        }
    }
}
