using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.PromotionCommands;

namespace CQRSProject.CQRSPattern.Handlers.PromotionHandlers
{
    public class UpdatePromotionCommandHandler
    {
        private readonly AppDbContext _context;
        public UpdatePromotionCommandHandler(AppDbContext context) { _context = context; }

        public async Task Handle(UpdatePromotionCommand command)
        {
            var promotion = await _context.Promotions.FindAsync(command.Id);
            if (promotion != null)
            {
                promotion.Title = command.Title; promotion.Description = command.Description;
                promotion.ImageUrl = command.ImageUrl; promotion.DiscountPercentage = command.DiscountPercentage;
                promotion.StartDate = command.StartDate; promotion.EndDate = command.EndDate;
                promotion.IsActive = command.IsActive;
                await _context.SaveChangesAsync();
            }
        }
    }
}
