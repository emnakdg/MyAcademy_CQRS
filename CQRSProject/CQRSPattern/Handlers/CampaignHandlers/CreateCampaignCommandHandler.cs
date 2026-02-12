using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.CampaignCommands;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.CampaignHandlers
{
    public class CreateCampaignCommandHandler
    {
        private readonly AppDbContext _context;
        public CreateCampaignCommandHandler(AppDbContext context) { _context = context; }

        public async Task Handle(CreateCampaignCommand command)
        {
            var campaign = new Campaign
            {
                Title = command.Title, Description = command.Description,
                ImageUrl = command.ImageUrl, StartDate = command.StartDate,
                EndDate = command.EndDate, IsActive = command.IsActive
            };
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
        }
    }
}
