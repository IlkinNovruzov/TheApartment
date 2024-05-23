using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheApartment.Models;
using TheApartment.Models.DataModels;

namespace TheApartment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View(_context.ApartmentInfos.FirstOrDefault(x => x.Id > 0));
        }
        [HttpPost]
        public IActionResult Edit(ApartmentInfo info)
        {
            if (ModelState.IsValid)
            {
                var old = _context.ApartmentInfos.FirstOrDefault(x => x.Id == info.Id);
                if (old != null)
                {
                    old.Email = info.Email;
                    old.Rules = info.Rules;
                    old.Phone = info.Phone;
                    old.ExtraInfo = info.ExtraInfo;
                    old.City = info.City;
                    _context.SaveChanges();
                    return RedirectToAction("Info");
                }

            }
            return RedirectToAction("Info");
        }

    }
}

