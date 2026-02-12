using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.CampaignCommands;

namespace CQRSProject.CQRSPattern.Handlers.CampaignHandlers
{
    public class UpdateCampaignCommandHandler
    {
        private readonly AppDbContext _context;
        public UpdateCampaignCommandHandler(AppDbContext context) { _context = context; }

        public async Task Handle(UpdateCampaignCommand command)
        {
            var campaign = await _context.Campaigns.FindAsync(command.Id);
            if (campaign != null)
            {
                campaign.Title = command.Title; campaign.Description = command.Description;
                campaign.ImageUrl = command.ImageUrl; campaign.StartDate = command.StartDate;
                campaign.EndDate = command.EndDate; campaign.IsActive = command.IsActive;
                await _context.SaveChangesAsync();
            }
        }
    }
}
