using CQRSProject.Entities;

namespace CQRSProject.Patterns.Observer.Events
{
    public class OrderCreatedEvent : IEvent
    {
        public Order Order { get; }
        public DateTime OccurredOn { get; }

        public OrderCreatedEvent(Order order)
        {
            Order = order;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
