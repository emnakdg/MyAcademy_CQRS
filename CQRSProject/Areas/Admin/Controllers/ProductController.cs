using CQRSProject.CQRSPattern.Commands.CategoryCommands;
using CQRSProject.CQRSPattern.Commands.ProductCommands;
using CQRSProject.CQRSPattern.Handlers.CategoryHandlers;
using CQRSProject.CQRSPattern.Handlers.ProductHandlers;
using CQRSProject.CQRSPattern.Queries.ProductQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(GetProductsQueryHandler getProductsQueryHandler,
                                   GetCategoriesQueryHandler getCategoriesQueryHandler,
                                   CreateProductCommandHandler createProductCommandHandler,
                                   UpdateProductCommandHandler updateProductCommandHandler,
                                   RemoveProductCommandHandler removeProductCommandHandler,
                                   GetProductByIdQueryHandler getProductByIdQueryHandler) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await getCategoriesQueryHandler.Handle();
            ViewBag.categories = (from x in categories
                                  select new SelectListItem
                                  {
                                      Text = x.Name,
                                      Value = x.Id.ToString()
                                  }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var products = await getProductsQueryHandler.Handle();
            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await getProductByIdQueryHandler.Handle(new GetProductsByIdQuery(id));
            await GetCategoriesAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            await removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
    }
}
