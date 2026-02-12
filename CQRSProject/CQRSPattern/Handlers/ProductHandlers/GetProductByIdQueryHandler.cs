using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Queries.ProductQueries;
using CQRSProject.CQRSPattern.Results.ProductResults;
using CQRSProject.Entities;

namespace CQRSProject.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductsByIdQuery query)
        {
            var product = await context.Products.FindAsync(query.Id);
            return mapper.Map<GetProductByIdQueryResult>(product);
        }
    }
}
