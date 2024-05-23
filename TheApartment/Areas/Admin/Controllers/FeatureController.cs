using Microsoft.AspNetCore.Mvc;
using TheApartment.Models;
using TheApartment.Models.DataModels;

namespace TheApartment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;
        public FeatureController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult FeatureList()
        {
            return Json(_context.Features.ToList());
        }
        [HttpPost]
        public JsonResult Add(Feature feature)
        {
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Json("Added.");
        }
        [HttpGet]
        public JsonResult Edit(int id)
        {
            var feature = _context.Features.FirstOrDefault(b => b.Id == id);
            return Json(feature);
        }
        [HttpPost]
        public JsonResult Update(Feature feature)
        {
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Json("Succesfully.");
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var feature = _context.Features.FirstOrDefault(f => f.Id == id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
                _context.SaveChanges();
                return Json("Succesfully.");
            }
            return Json("Not Found.");

        }
    }
}

