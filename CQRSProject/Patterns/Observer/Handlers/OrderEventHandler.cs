using Microsoft.Extensions.Logging;

namespace CQRSProject.Patterns.Observer.Handlers
{
    public class OrderEventHandler : IEventHandler<Events.OrderCreatedEvent>
    {
        private readonly ILogger<OrderEventHandler> _logger;

        public OrderEventHandler(ILogger<OrderEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(Events.OrderCreatedEvent @event)
        {
            _logger.LogInformation(
                "Order Created: OrderId={OrderId}, Customer={CustomerName}, Total={TotalAmount}, Date={OccurredOn}",
                @event.Order.Id,
                @event.Order.CustomerName,
                @event.Order.TotalAmount,
                @event.OccurredOn
            );
            return Task.CompletedTask;
        }
    }
}
