using CQRSProject.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
            ViewBag.ProductCount = await _context.Products.CountAsync();
            ViewBag.CategoryCount = await _context.Categories.CountAsync();
            ViewBag.OrderCount = await _context.Orders.CountAsync();
            ViewBag.ContactCount = await _context.Contacts.CountAsync();
            ViewBag.TestimonialCount = await _context.Testimonials.CountAsync();
            ViewBag.CampaignCount = await _context.Campaigns.CountAsync();

            var recentOrders = await _context.Orders
                .OrderByDescending(x => x.CreatedAt)
                .Take(5)
                .ToListAsync();
            ViewBag.RecentOrders = recentOrders;

            var recentContacts = await _context.Contacts
                .OrderByDescending(x => x.Id)
                .Take(5)
                .ToListAsync();
            ViewBag.RecentContacts = recentContacts;

            return View();
        }
    }
}
