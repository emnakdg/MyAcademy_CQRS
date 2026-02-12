using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.OrderCommands;
using CQRSProject.CQRSPattern.Handlers.OrderHandlers;
using CQRSProject.Helpers;
using CQRSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CreateOrderCommandHandler _orderHandler;

        public CartController(AppDbContext context, CreateOrderCommandHandler orderHandler)
        {
            _context = context;
            _orderHandler = orderHandler;
        }

        public IActionResult Index()
        {
            var cart = CartHelper.GetCart(HttpContext.Session);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == productId);

            if (product == null)
                return Json(new { success = false, message = "Ürün bulunamadı." });

            var cartItem = new CartItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Quantity = quantity
            };

            CartHelper.AddToCart(HttpContext.Session, cartItem);

            return Json(new
            {
                success = true,
                message = $"{product.Name} sepete eklendi!",
                cartCount = CartHelper.GetCartCount(HttpContext.Session),
                cartTotal = CartHelper.GetCartTotal(HttpContext.Session)
            });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            CartHelper.RemoveFromCart(HttpContext.Session, productId);

            var cart = CartHelper.GetCart(HttpContext.Session);
            return Json(new
            {
                success = true,
                cartCount = CartHelper.GetCartCount(HttpContext.Session),
                cartTotal = CartHelper.GetCartTotal(HttpContext.Session),
                cartEmpty = !cart.Any()
            });
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            CartHelper.UpdateQuantity(HttpContext.Session, productId, quantity);

            var cart = CartHelper.GetCart(HttpContext.Session);
            var item = cart.FirstOrDefault(x => x.ProductId == productId);

            return Json(new
            {
                success = true,
                itemTotal = item?.Total ?? 0,
                cartCount = CartHelper.GetCartCount(HttpContext.Session),
                cartTotal = CartHelper.GetCartTotal(HttpContext.Session),
                cartEmpty = !cart.Any()
            });
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            return Json(new
            {
                count = CartHelper.GetCartCount(HttpContext.Session)
            });
        }

        public IActionResult Checkout()
        {
            var cart = CartHelper.GetCart(HttpContext.Session);
            if (!cart.Any())
                return RedirectToAction("Index", "Shop");

            var model = new CheckoutViewModel
            {
                CartItems = cart
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var cart = CartHelper.GetCart(HttpContext.Session);
            model.CartItems = cart;

            if (!cart.Any())
            {
                ModelState.AddModelError("", "Sepetiniz boş.");
                return View(model);
            }

            if (!ModelState.IsValid)
                return View(model);

            var command = new CreateOrderCommand
            {
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerPhone = model.CustomerPhone,
                ShippingAddress = model.ShippingAddress,
                OrderItems = cart.Select(x => new OrderItemDto
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.Price
                }).ToList()
            };

            var result = await _orderHandler.Handle(command);

            if (result.Success)
            {
                CartHelper.ClearCart(HttpContext.Session);
                return RedirectToAction("OrderConfirmation", new { orderId = result.OrderId });
            }

            ModelState.AddModelError("", result.ErrorMessage ?? "Sipariş oluşturulurken bir hata oluştu.");
            return View(model);
        }

        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            var order = await _context.Orders
                .Include(x => x.OrderItems)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
                return RedirectToAction("Index", "Shop");

            return View(order);
        }
    }
}
