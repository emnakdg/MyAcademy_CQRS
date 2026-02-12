using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.OrderResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.OrderHandlers
{
    public class GetOrderByIdQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetOrderByIdQueryResult> Handle(int id)
        {
            var value = await _context.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<GetOrderByIdQueryResult>(value);
        }
    }
}
