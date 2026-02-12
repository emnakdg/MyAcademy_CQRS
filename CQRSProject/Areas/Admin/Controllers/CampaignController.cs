using CQRSProject.CQRSPattern.Commands.CampaignCommands;
using CQRSProject.CQRSPattern.Handlers.CampaignHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampaignController : Controller
    {
        private readonly GetCampaignsQueryHandler _getAllHandler;
        private readonly GetCampaignByIdQueryHandler _getByIdHandler;
        private readonly CreateCampaignCommandHandler _createHandler;
        private readonly UpdateCampaignCommandHandler _updateHandler;
        private readonly RemoveCampaignCommandHandler _removeHandler;

        public CampaignController(GetCampaignsQueryHandler getAllHandler, GetCampaignByIdQueryHandler getByIdHandler,
            CreateCampaignCommandHandler createHandler, UpdateCampaignCommandHandler updateHandler, RemoveCampaignCommandHandler removeHandler)
        {
            _getAllHandler = getAllHandler; _getByIdHandler = getByIdHandler;
            _createHandler = createHandler; _updateHandler = updateHandler; _removeHandler = removeHandler;
        }

        public async Task<IActionResult> Index() => View(await _getAllHandler.Handle());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCampaignCommand command)
        {
            await _createHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) => View(await _getByIdHandler.Handle(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCampaignCommand command)
        {
            await _updateHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _removeHandler.Handle(new RemoveCampaignCommand { Id = id });
            return RedirectToAction("Index");
        }
    }
}
