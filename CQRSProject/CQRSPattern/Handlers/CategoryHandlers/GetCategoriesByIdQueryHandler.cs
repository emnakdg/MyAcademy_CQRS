using CQRSProject.Context;
using CQRSProject.CQRSPattern.Queries.CategoryQueries;
using CQRSProject.CQRSPattern.Results.CategoryResults;

namespace CQRSProject.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetCategoriesByIdQueryHandler
    {
        private readonly AppDbContext _contnext;

        public GetCategoriesByIdQueryHandler(AppDbContext contnext)
        {
            _contnext = contnext;
        }

        public async Task<GetCategoriesByIdQueryResult> Handle(GetCategoriesByIdQuery query)
        {
            var category = await _contnext.Categories.FindAsync(query.Id);
            return new GetCategoriesByIdQueryResult
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
