using CQRSProject.CQRSPattern.Commands.TestimonialCommands;
using CQRSProject.CQRSPattern.Handlers.TestimonialHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly GetTestimonialsQueryHandler _getAllHandler;
        private readonly GetTestimonialByIdQueryHandler _getByIdHandler;
        private readonly CreateTestimonialCommandHandler _createHandler;
        private readonly UpdateTestimonialCommandHandler _updateHandler;
        private readonly RemoveTestimonialCommandHandler _removeHandler;

        public TestimonialController(GetTestimonialsQueryHandler getAllHandler, GetTestimonialByIdQueryHandler getByIdHandler,
            CreateTestimonialCommandHandler createHandler, UpdateTestimonialCommandHandler updateHandler, RemoveTestimonialCommandHandler removeHandler)
        {
            _getAllHandler = getAllHandler; _getByIdHandler = getByIdHandler;
            _createHandler = createHandler; _updateHandler = updateHandler; _removeHandler = removeHandler;
        }

        public async Task<IActionResult> Index() => View(await _getAllHandler.Handle());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialCommand command)
        {
            await _createHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) => View(await _getByIdHandler.Handle(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialCommand command)
        {
            await _updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _removeHandler.Handle(new RemoveTestimonialCommand { Id = id });
            return RedirectToAction("Index");
        }
    }
}
