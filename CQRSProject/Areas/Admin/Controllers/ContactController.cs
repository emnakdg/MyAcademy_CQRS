using CQRSProject.CQRSPattern.Handlers.ContactHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CQRSProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly GetContactsQueryHandler _getContactsQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

        public ContactController(GetContactsQueryHandler getContactsQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler)
        {
            _getContactsQueryHandler = getContactsQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getContactsQueryHandler.Handle();
            return View(values);
        }

        public async Task<IActionResult> Details(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(id);
            if (value == null) return NotFound();
            return View(value);
        }
    }
}
