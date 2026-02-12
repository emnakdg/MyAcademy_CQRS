namespace CQRSProject.Patterns.Observer
{
    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
        void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
    }
}
