using Microsoft.Extensions.Logging;

namespace CQRSProject.Patterns.Observer.Handlers
{
    public class ContactEventHandler : IEventHandler<Events.ContactCreatedEvent>
    {
        private readonly ILogger<ContactEventHandler> _logger;

        public ContactEventHandler(ILogger<ContactEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(Events.ContactCreatedEvent @event)
        {
            _logger.LogInformation(
                "Contact Message Received: ContactId={ContactId}, Name={Name}, Email={Email}, Subject={Subject}, Date={OccurredOn}",
                @event.Contact.Id,
                @event.Contact.Name,
                @event.Contact.Email,
                @event.Contact.Subject,
                @event.OccurredOn
            );
            return Task.CompletedTask;
        }
    }
}
