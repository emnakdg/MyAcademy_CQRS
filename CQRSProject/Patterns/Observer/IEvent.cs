namespace CQRSProject.Patterns.Observer
{
    public interface IEvent
    {
        DateTime OccurredOn { get; }
    }
}
