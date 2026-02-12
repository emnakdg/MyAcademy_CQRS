using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.ContactCommands;
using CQRSProject.Entities;
using CQRSProject.Patterns.Observer;
using CQRSProject.Patterns.Observer.Events;

namespace CQRSProject.CQRSPattern.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly AppDbContext _context;
        private readonly IEventPublisher _eventPublisher;

        public CreateContactCommandHandler(AppDbContext context, IEventPublisher eventPublisher)
        {
            _context = context;
            _eventPublisher = eventPublisher;
        }

        public async Task Handle(CreateContactCommand command)
        {
            var contact = new Contact
            {
                Name = command.Name,
                Email = command.Email,
                Phone = command.Phone,
                Subject = command.Subject,
                Message = command.Message,
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            await _eventPublisher.PublishAsync(new ContactCreatedEvent(contact));
        }
    }
}
