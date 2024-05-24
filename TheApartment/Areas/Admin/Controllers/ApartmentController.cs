using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheApartment.Areas.Admin.ViewModels;
using TheApartment.Extensions;
using TheApartment.Models;
using TheApartment.Models.DataModels;
using static System.Net.Mime.MediaTypeNames;

namespace TheApartment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApartmentController : Controller
    {
        private readonly AppDbContext _context;
        public ApartmentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ApartmentList()
        {
            return View(_context.Apartments.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Features = _context.Features.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApartmentVM model)
        {
            await _context.Apartments.AddAsync(model.Apartment);
            await _context.SaveChangesAsync();
            foreach (var colorId in model.FeatureIds)
            {
                var productColor = new ApartmentFeature
                {
                    ApartmentId = model.Apartment.Id,
                    FeatureId = colorId
                };
                _context.ApartmentFeatures.Add(productColor);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("ApartmentImages", new { id = model.Apartment.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Features = _context.Features.ToList();

            var a = await _context.Apartments.FirstOrDefaultAsync(p => p.Id == id);

            var ids = _context.ApartmentFeatures.Where(af => af.ApartmentId == id).Select(af => af.FeatureId).ToList();
            var model = new ApartmentVM()
            {
                Apartment = a,
                FeatureIds = ids,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApartmentVM model)
        {
            var apartment = await _context.Apartments.FirstOrDefaultAsync(a => a.Id == model.Apartment.Id);
            apartment.Name = model.Apartment.Name;
            apartment.MaxPeople = model.Apartment.MaxPeople;
            apartment.BathRooms = model.Apartment.BathRooms;
            apartment.BedRooms = model.Apartment.BedRooms;
            apartment.CheckInTime = model.Apartment.CheckInTime;
            apartment.CheckOutTime = model.Apartment.CheckOutTime;
            apartment.PricePerNight = model.Apartment.PricePerNight;
            apartment.IsActive = model.Apartment.IsActive;

            await _context.SaveChangesAsync();

            var oldIds = _context.ApartmentFeatures.Where(af => af.ApartmentId == model.Apartment.Id).ToList();
            _context.ApartmentFeatures.RemoveRange(oldIds);
            foreach (var id in model.FeatureIds)
            {
                var af = new ApartmentFeature
                {
                    ApartmentId = model.Apartment.Id,
                    FeatureId = id
                };
                _context.ApartmentFeatures.Add(af);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("ApartmentList");
        }
        public IActionResult Delete(int id)
        {
            var x = _context.Apartments.Find(id);
            if (x != null)
            {
                _context.Apartments.Remove(x);
            }
            _context.SaveChanges();
            return RedirectToAction("ApartmentList");
        }
        [HttpGet]
        public IActionResult ApartmentImages(int id)
        {
            var model = new ImageVM
            {
                ApartmentId = id,
                Images = _context.ApartmentImages.Where(x => x.ApartmentId == id).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddImage(ImageVM model)
        {
            if (FileExtensions.IsImage(model.ImgFile))
            {
                string nameImg = await FileExtensions.SaveAsync(model.ImgFile, "apartments");
                var productImage = new ApartmentImage
                {
                    ImageUrl = nameImg,
                    ApartmentId = model.ApartmentId,
                    IsActive = true
                };
                _context.ApartmentImages.Add(productImage);
                _context.SaveChanges();
            }
            return RedirectToAction("ApartmentImages", new { id = model.ApartmentId });

        }
        public async Task<IActionResult> DeleteImage(int id)
        {
            var img = await _context.ApartmentImages.FirstOrDefaultAsync(i => i.Id == id);

            if (img != null)
            {
                _context.ApartmentImages.Remove(img);
            }
            _context.SaveChanges();
            return RedirectToAction("ApartmentImages", new { id = img.ApartmentId });

        }

    }
}
