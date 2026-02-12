using CQRSProject.CQRSPattern.Commands.PhotoGalleryCommands;
using CQRSProject.CQRSPattern.Handlers.PhotoGalleryHandlers;
using CQRSProject.CQRSPattern.Handlers.CategoryHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhotoGalleryController : Controller
    {
        private readonly GetPhotoGalleriesQueryHandler _getAllHandler;
        private readonly GetPhotoGalleryByIdQueryHandler _getByIdHandler;
        private readonly CreatePhotoGalleryCommandHandler _createHandler;
        private readonly UpdatePhotoGalleryCommandHandler _updateHandler;
        private readonly RemovePhotoGalleryCommandHandler _removeHandler;
        private readonly GetCategoriesQueryHandler _getCategoriesHandler;

        public PhotoGalleryController(GetPhotoGalleriesQueryHandler getAllHandler, GetPhotoGalleryByIdQueryHandler getByIdHandler,
            CreatePhotoGalleryCommandHandler createHandler, UpdatePhotoGalleryCommandHandler updateHandler,
            RemovePhotoGalleryCommandHandler removeHandler, GetCategoriesQueryHandler getCategoriesHandler)
        {
            _getAllHandler = getAllHandler; _getByIdHandler = getByIdHandler;
            _createHandler = createHandler; _updateHandler = updateHandler;
            _removeHandler = removeHandler; _getCategoriesHandler = getCategoriesHandler;
        }

        private async Task LoadCategories()
        {
            var categories = await _getCategoriesHandler.Handle();
            ViewBag.Categories = categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
        }

        public async Task<IActionResult> Index() => View(await _getAllHandler.Handle());

        public async Task<IActionResult> Create() { await LoadCategories(); return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePhotoGalleryCommand command)
        {
            await _createHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            await LoadCategories();
            return View(await _getByIdHandler.Handle(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePhotoGalleryCommand command)
        {
            await _updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _removeHandler.Handle(new RemovePhotoGalleryCommand { Id = id });
            return RedirectToAction("Index");
        }
    }
}
