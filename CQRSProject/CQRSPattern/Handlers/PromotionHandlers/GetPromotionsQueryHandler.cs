using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.PromotionResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionsQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetPromotionsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PromotionResult>> Handle()
        {
            var values = await _context.Promotions.ToListAsync();
            return _mapper.Map<List<PromotionResult>>(values);
        }
    }
}
