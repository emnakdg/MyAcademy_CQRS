using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.PromotionResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.PromotionHandlers
{
    public class GetPromotionByIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetPromotionByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PromotionResult> Handle(int id)
        {
            var value = await _context.Promotions.FindAsync(id);
            return _mapper.Map<PromotionResult>(value);
        }
    }
}
