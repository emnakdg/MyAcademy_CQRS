using System.Diagnostics;
using CQRSProject.Context;
using CQRSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliderCount = await _context.Sliders.CountAsync();
            var testimonialsCount = await _context.Testimonials.CountAsync();
            var productsCount = await _context.Products.CountAsync();
            _logger.LogInformation($"DEBUG: Sliders={sliderCount}, Testimonials={testimonialsCount}, Products={productsCount}");

            var model = new HomeViewModel
            {
                Sliders = await _context.Sliders
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.Order)
                    .Select(x => new SliderViewModel
                    {
                        Id = x.Id,
                        Title = x.Title ?? "",
                        Description = x.Description ?? "",
                        ImageUrl = x.ImageUrl ?? "",
                        ButtonText = x.ButtonText ?? "",
                        ButtonUrl = x.ButtonUrl ?? "",
                        BackgroundColor = x.BackgroundColor ?? "#e8382e"
                    }).ToListAsync(),

                ThreeStepServices = await _context.ThreeStepServices
                    .OrderBy(x => x.StepNumber)
                    .Select(x => new ThreeStepServiceViewModel
                    {
                        StepNumber = x.StepNumber,
                        Title = x.Title ?? "",
                        Description = x.Description ?? ""
                    }).ToListAsync(),

                OurHistory = await GetOurHistoryAsync(),

                Products = await _context.Products
                    .Include(x => x.Category)
                    .Take(8)
                    .Select(x => new ProductViewModel
                    {
                        Id = x.Id,
                        Name = x.Name ?? "",
                        Description = x.Description ?? "",
                        Price = x.Price,
                        ImageUrl = x.ImageUrl ?? "",
                        CategoryName = x.Category != null ? x.Category.Name : ""
                    }).ToListAsync(),

                Services = await _context.Services
                    .OrderBy(x => x.Order)
                    .Select(x => new ServiceViewModel
                    {
                        Id = x.Id,
                        Title = x.Title ?? "",
                        Description = x.Description ?? "",
                        Icon = x.Icon ?? ""
                    }).ToListAsync(),

                PhotoGalleries = await _context.PhotoGalleries
                    .Include(x => x.Category)
                    .Take(6)
                    .Select(x => new PhotoGalleryViewModel
                    {
                        Id = x.Id,
                        Title = x.Title ?? "",
                        ImageUrl = x.ImageUrl ?? "",
                        CategoryName = x.Category != null ? x.Category.Name : ""
                    }).ToListAsync(),

                Promotions = await _context.Promotions
                    .Where(x => x.IsActive && x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now)
                    .Select(x => new PromotionViewModel
                    {
                        Id = x.Id,
                        Title = x.Title ?? "",
                        Description = x.Description ?? "",
                        ImageUrl = x.ImageUrl ?? "",
                        Price = 100,
                        DiscountPercentage = x.DiscountPercentage
                    }).ToListAsync(),

                Testimonials = await _context.Testimonials
                    .Select(x => new TestimonialViewModel
                    {
                        CustomerName = x.CustomerName ?? "",
                        CustomerTitle = x.CustomerTitle ?? "",
                        Comment = x.Comment ?? "",
                        ImageUrl = x.ImageUrl ?? "",
                        Rating = x.Rating
                    }).ToListAsync()
            };

            _logger.LogInformation($"MODEL: Sliders={model.Sliders.Count}, ThreeStepServices={model.ThreeStepServices.Count}, Products={model.Products.Count}, Services={model.Services.Count}, PhotoGalleries={model.PhotoGalleries.Count}, Promotions={model.Promotions.Count}, Testimonials={model.Testimonials.Count}");

            return View(model);
        }

        [Route("/api/debug")]
        public async Task<IActionResult> DebugData()
        {
            var data = new
            {
                Sliders = await _context.Sliders.CountAsync(),
                ThreeStepServices = await _context.ThreeStepServices.CountAsync(),
                OurHistories = await _context.OurHistories.CountAsync(),
                Products = await _context.Products.CountAsync(),
                Services = await _context.Services.CountAsync(),
                PhotoGalleries = await _context.PhotoGalleries.CountAsync(),
                Promotions = await _context.Promotions.CountAsync(),
                Testimonials = await _context.Testimonials.CountAsync(),
                Categories = await _context.Categories.CountAsync(),
                TestimonialsList = await _context.Testimonials.ToListAsync(),
                SlidersList = await _context.Sliders.ToListAsync()
            };
            return Json(data);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<OurHistoryViewModel?> GetOurHistoryAsync()
        {
            var history = await _context.OurHistories.FirstOrDefaultAsync();
            if (history == null) return null;

            return new OurHistoryViewModel
            {
                Title = history.Title ?? "",
                Description = history.Description ?? "",
                ImageUrl = history.ImageUrl ?? "",
                SignatureImageUrl = history.SignatureImageUrl ?? "",
                OverviewTitle = history.OverviewTitle ?? "",
                OverviewDescription = history.OverviewDescription ?? "",
                OverviewItems = string.IsNullOrEmpty(history.OverviewItems)
                    ? new List<string>()
                    : history.OverviewItems.Split('|').ToList()
            };
        }
    }
}
