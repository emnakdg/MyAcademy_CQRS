using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.CategoryCommands;

namespace CQRSProject.CQRSPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoriesCommandHandler
    {
        private readonly AppDbContext _context;

        public RemoveCategoriesCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _context.Categories.FindAsync(command.Id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
