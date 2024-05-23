using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TheApartment.Extensions;
using TheApartment.Models;
using TheApartment.Models.ViewModels;

namespace TheApartment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, IEmailService emailService)
        {
            _logger = logger;
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ApartmentDetails(int id)
        {
            var model = new DetailsVM
            {
                Apartment = _context.Apartments.Include(a => a.ApartmentImages).Include(a => a.ApartmentFeatures).ThenInclude(af => af.Feature).FirstOrDefault(a => a.Id == id),
                ApartmentInfo = _context.ApartmentInfos.FirstOrDefault(x => x.Id > 0)
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailVM model)
        {
            await _emailService.SendEmailAsync(model.Email, model.Name, model.Message);
            return RedirectToAction("SendEmail");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
