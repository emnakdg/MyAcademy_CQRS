using CQRSProject.Entities;

namespace CQRSProject.Patterns.Observer.Events
{
    public class ContactCreatedEvent : IEvent
    {
        public Contact Contact { get; }
        public DateTime OccurredOn { get; }

        public ContactCreatedEvent(Contact contact)
        {
            Contact = contact;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
