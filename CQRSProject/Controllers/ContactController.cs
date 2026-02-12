using CQRSProject.CQRSPattern.Commands.ContactCommands;
using CQRSProject.CQRSPattern.Handlers.ContactHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly CreateContactCommandHandler _createContactHandler;

        public ContactController(CreateContactCommandHandler createContactHandler)
        {
            _createContactHandler = createContactHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CreateContactCommand command)
        {
            if (ModelState.IsValid)
            {
                await _createContactHandler.Handle(command);
                TempData["Success"] = "Mesajınız başarıyla gönderildi. En kısa sürede size dönüş yapacağız.";
                return RedirectToAction("Index");
            }

            return View(command);
        }
    }
}
