using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.CampaignCommands;

namespace CQRSProject.CQRSPattern.Handlers.CampaignHandlers
{
    public class RemoveCampaignCommandHandler
    {
        private readonly AppDbContext _context;
        public RemoveCampaignCommandHandler(AppDbContext context) { _context = context; }

        public async Task Handle(RemoveCampaignCommand command)
        {
            var campaign = await _context.Campaigns.FindAsync(command.Id);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
                await _context.SaveChangesAsync();
            }
        }
    }
}
