using CQRSProject.Entities;

namespace CQRSProject.Patterns.Observer.Events
{
    public class CampaignCreatedEvent : IEvent
    {
        public Campaign Campaign { get; }
        public DateTime OccurredOn { get; }

        public CampaignCreatedEvent(Campaign campaign)
        {
            Campaign = campaign;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
