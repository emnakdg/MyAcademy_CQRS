using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.PromotionCommands;

namespace CQRSProject.CQRSPattern.Handlers.PromotionHandlers
{
    public class RemovePromotionCommandHandler
    {
        private readonly AppDbContext _context;
        public RemovePromotionCommandHandler(AppDbContext context) { _context = context; }

        public async Task Handle(RemovePromotionCommand command)
        {
            var promotion = await _context.Promotions.FindAsync(command.Id);
            if (promotion != null)
            {
                _context.Promotions.Remove(promotion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
