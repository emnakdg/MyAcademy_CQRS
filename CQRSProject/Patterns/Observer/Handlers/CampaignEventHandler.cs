using Microsoft.Extensions.Logging;

namespace CQRSProject.Patterns.Observer.Handlers
{
    public class CampaignEventHandler : IEventHandler<Events.CampaignCreatedEvent>
    {
        private readonly ILogger<CampaignEventHandler> _logger;

        public CampaignEventHandler(ILogger<CampaignEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(Events.CampaignCreatedEvent @event)
        {
            _logger.LogInformation(
                "Campaign Created: CampaignId={CampaignId}, Title={Title}, StartDate={StartDate}, EndDate={EndDate}, Date={OccurredOn}",
                @event.Campaign.Id,
                @event.Campaign.Title,
                @event.Campaign.StartDate,
                @event.Campaign.EndDate,
                @event.OccurredOn
            );
            return Task.CompletedTask;
        }
    }
}
