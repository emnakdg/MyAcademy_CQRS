namespace CQRSProject.Patterns.Observer
{
    public class EventPublisher : IEventPublisher
    {
        private readonly Dictionary<Type, List<object>> _handlers = new();

        public void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<object>();
            }
            _handlers[eventType].Add(handler);
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (_handlers.TryGetValue(eventType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    if (handler is IEventHandler<TEvent> typedHandler)
                    {
                        await typedHandler.HandleAsync(@event);
                    }
                }
            }
        }
    }
}
