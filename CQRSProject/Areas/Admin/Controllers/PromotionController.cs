using CQRSProject.CQRSPattern.Commands.PromotionCommands;
using CQRSProject.CQRSPattern.Handlers.PromotionHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {
        private readonly GetPromotionsQueryHandler _getAllHandler;
        private readonly GetPromotionByIdQueryHandler _getByIdHandler;
        private readonly CreatePromotionCommandHandler _createHandler;
        private readonly UpdatePromotionCommandHandler _updateHandler;
        private readonly RemovePromotionCommandHandler _removeHandler;

        public PromotionController(GetPromotionsQueryHandler getAllHandler, GetPromotionByIdQueryHandler getByIdHandler,
            CreatePromotionCommandHandler createHandler, UpdatePromotionCommandHandler updateHandler, RemovePromotionCommandHandler removeHandler)
        {
            _getAllHandler = getAllHandler; _getByIdHandler = getByIdHandler;
            _createHandler = createHandler; _updateHandler = updateHandler; _removeHandler = removeHandler;
        }

        public async Task<IActionResult> Index() => View(await _getAllHandler.Handle());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePromotionCommand command)
        {
            await _createHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) => View(await _getByIdHandler.Handle(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePromotionCommand command)
        {
            await _updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _removeHandler.Handle(new RemovePromotionCommand { Id = id });
            return RedirectToAction("Index");
        }
    }
}
