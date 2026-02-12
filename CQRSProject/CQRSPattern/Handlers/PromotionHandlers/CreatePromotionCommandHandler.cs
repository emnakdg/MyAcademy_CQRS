using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.PromotionCommands;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.PromotionHandlers
{
    public class CreatePromotionCommandHandler
    {
        private readonly AppDbContext _context;
        public CreatePromotionCommandHandler(AppDbContext context) { _context = context; }

        public async Task Handle(CreatePromotionCommand command)
        {
            var promotion = new Promotion
            {
                Title = command.Title, Description = command.Description,
                ImageUrl = command.ImageUrl, DiscountPercentage = command.DiscountPercentage,
                StartDate = command.StartDate, EndDate = command.EndDate, IsActive = command.IsActive
            };
            await _context.Promotions.AddAsync(promotion);
            await _context.SaveChangesAsync();
        }
    }
}
