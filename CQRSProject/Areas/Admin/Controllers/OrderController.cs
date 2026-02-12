using CQRSProject.CQRSPattern.Handlers.OrderHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly GetOrdersQueryHandler _getOrdersQueryHandler;
        private readonly GetOrderByIdQueryHandler _getOrderByIdQueryHandler;

        public OrderController(GetOrdersQueryHandler getOrdersQueryHandler, GetOrderByIdQueryHandler getOrderByIdQueryHandler)
        {
            _getOrdersQueryHandler = getOrdersQueryHandler;
            _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getOrdersQueryHandler.Handle();
            return View(values);
        }

        public async Task<IActionResult> Details(int id)
        {
            var value = await _getOrderByIdQueryHandler.Handle(id);
            if (value == null) return NotFound();
            return View(value);
        }
    }
}
