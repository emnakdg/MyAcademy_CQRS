using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.ProductResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductsQueryHandler(AppDbContext _context, IMapper _mapper)
    {
        public async Task<List<GetProductsQueryResult>> Handle()
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync();
            return _mapper.Map<List<GetProductsQueryResult>>(products);

        }
    }
}
