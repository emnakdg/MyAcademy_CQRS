using AutoMapper;
using CQRSProject.Context;
using CQRSProject.CQRSPattern.Results.OrderResults;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.CQRSPattern.Handlers.OrderHandlers
{
    public class GetOrdersQueryHandler
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetOrderQueryResult>> Handle()
        {
            var values = await _context.Orders.OrderByDescending(x => x.CreatedAt).ToListAsync();
            return _mapper.Map<List<GetOrderQueryResult>>(values);
        }
    }
}
