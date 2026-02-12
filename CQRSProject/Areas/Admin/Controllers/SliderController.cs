using CQRSProject.CQRSPattern.Commands.SliderCommands;
using CQRSProject.CQRSPattern.Handlers.SliderHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly GetSlidersQueryHandler _getSlidersHandler;
        private readonly GetSliderByIdQueryHandler _getByIdHandler;
        private readonly CreateSliderCommandHandler _createHandler;
        private readonly UpdateSliderCommandHandler _updateHandler;
        private readonly RemoveSliderCommandHandler _removeHandler;

        public SliderController(GetSlidersQueryHandler getSlidersHandler, GetSliderByIdQueryHandler getByIdHandler,
            CreateSliderCommandHandler createHandler, UpdateSliderCommandHandler updateHandler, RemoveSliderCommandHandler removeHandler)
        {
            _getSlidersHandler = getSlidersHandler; _getByIdHandler = getByIdHandler;
            _createHandler = createHandler; _updateHandler = updateHandler; _removeHandler = removeHandler;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _getSlidersHandler.Handle();
            return View(sliders);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderCommand command)
        {
            await _createHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var slider = await _getByIdHandler.Handle(id);
            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderCommand command)
        {
            await _updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _removeHandler.Handle(new RemoveSliderCommand { Id = id });
            return RedirectToAction("Index");
        }
    }
}
