using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.CategoryResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler
    {
        private readonly AppDbContext _context;

        public GetCategoriesQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoriesQueryResult>> Handle()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories.Select(c => new GetCategoriesQueryResult
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
