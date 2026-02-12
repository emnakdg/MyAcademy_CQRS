using CQRSProject.Context;
using CQRSProject.CQRSPattern.Commands.CategoryComments;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoriesCommandHandler
    {
        private readonly AppDbContext _context;

        public UpdateCategoriesCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = new Category
            {
                Id = command.Id,
                Name = command.Name
            };
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
