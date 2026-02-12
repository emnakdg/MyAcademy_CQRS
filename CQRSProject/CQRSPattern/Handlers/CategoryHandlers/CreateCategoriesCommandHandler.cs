using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.CategoryCommands;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.CategoryHandlers
{
    public class CreateCategoriesCommandHandler
    {
        private readonly AppDbContext _context;

        public CreateCategoriesCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            var category = new Category
            {
                Name = command.Name
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
    }
}
