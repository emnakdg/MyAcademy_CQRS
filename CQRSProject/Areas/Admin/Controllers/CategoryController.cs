using CQRSProject.CQRSPattern.Commands.CategoryCommands;
using CQRSProject.CQRSPattern.Commands.CategoryComments;
using CQRSProject.CQRSPattern.Handlers.CategoryHandlers;
using CQRSProject.CQRSPattern.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly GetCategoriesQueryHandler _getCategoriesQueryHandler;
        private readonly GetCategoriesByIdQueryHandler _getCategoriesByIdQueryHandler;
        private readonly UpdateCategoriesCommandHandler _updateCategoriesCommandHandler;
        private readonly CreateCategoriesCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoriesCommandHandler _removeCategoriesCommandHandler;

        public CategoryController(GetCategoriesQueryHandler getCategoriesQueryHandler, GetCategoriesByIdQueryHandler getCategoriesByIdQueryHandler, UpdateCategoriesCommandHandler updateCategoriesCommandHandler, CreateCategoriesCommandHandler createCategoryCommandHandler, RemoveCategoriesCommandHandler removeCategoriesCommandHandler)
        {
            _getCategoriesQueryHandler = getCategoriesQueryHandler;
            _getCategoriesByIdQueryHandler = getCategoriesByIdQueryHandler;
            _updateCategoriesCommandHandler = updateCategoriesCommandHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _removeCategoriesCommandHandler = removeCategoriesCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _getCategoriesQueryHandler.Handle();
            return View(categories);
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _getCategoriesByIdQueryHandler.Handle(new GetCategoriesByIdQuery(id));
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoriesCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoriesCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("Index");
        }
    }
}
