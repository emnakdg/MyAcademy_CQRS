using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.ProductCommands;

namespace CQRSProject.CQRSPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemoveProductCommand command)
        {
            var product = await context.Products.FindAsync(command.Id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
